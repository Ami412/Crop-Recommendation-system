using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myproject.Models;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace myproject.Controllers
{
    public class FarmerController : Controller
    {

        // GET: farmer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FarmerForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FarmerEmail(FormCollection col)
        {
            Farmer f = new Farmer();
            f.Email = col["email"];

            f.SelectByEmailID();

            f.Password = "eb1f2s45d";
            SendEmail(f.Email, "Password changed!", "Your password has been changed to eb1f2s45d. You can change your password as per your need by login into your account.");
            f.update();
            return RedirectToAction("FarmerLogin", "Guest");
            
        }


        public ActionResult FarmerEdit()
        {
            District CT = new Models.District();
            ViewBag.dtCT = CT.selectall();
            return View();
        }

        [HttpPost]
        public ActionResult FarmerUpdate(FormCollection collection)
        {
            Farmer c = (Farmer)Session["Farmer"];
            c.FarmerID = Convert.ToInt32(collection["FarmerID"]);
            c.SelectByID();
            c.Name = collection["Name"];
            c.Username = collection["Username"];
            c.Password = collection["Password"];
            c.Address = collection["Address"];
            c.City = collection["City"];

            c.DistrictID = Convert.ToInt32(collection["DistrictID"]);
            c.Email = collection["Email"];

            c.Phone = collection["Phone"];
            c.SoilType = collection["SoilType"];
            c.LandQty = collection["LandQty"];
            c.Status = "";

            c.update();
            Session["Farmer"] = c;
            return RedirectToAction("HomePage1", "Guest");
        }

        public ActionResult PacketOrder(int id)
        {

            Packet P = new Packet();
            DataTable dtProd = P.selectByPacketID(id);
            return View(dtProd);



        }
        [HttpPost]
        public ActionResult PacketOrderInsert(FormCollection collection)
        {
            if (Session["Farmer"] != null)
            {
                Farmer f = (Farmer)Session["Farmer"];
                PacketOrder p = new PacketOrder();
                p.PacketID = Convert.ToInt16(collection["PacketID"]);
                Packet pkt = new Packet();
                pkt.PacketID = p.PacketID;
                pkt.SelectByID();

                p.FarmerID = f.FarmerID;
                p.RetailerID = pkt.RetailerID;
                p.OrderDate = Convert.ToDateTime(DateTime.Now.ToString());
                p.Status = "PENDING";
                p.Qty = Convert.ToInt32(collection["Qty"]);
                p.Price = pkt.Price;
                p.NetPrice = p.Price * p.Qty;
                p.PaymentStatus = "PENDING";
                p.PaymentType = "";
                p.Msg = "";
                p.Rating = "";
                
                p.insert();
                return RedirectToAction("OrderSummary", "Farmer");
            }
            else
            {
                return RedirectToAction("FarmerLogin", "Guest");

            }



        }
        public ActionResult OrderSummary()
        {

            Farmer f = (Farmer)Session["Farmer"];
            PacketOrder p = new PacketOrder();
            p.FarmerID = f.FarmerID;
            DataTable dt = p.selectByFarmerIDAndStatus("PENDING");

            return View(dt);


        }

        public ActionResult MyOrders()
        {

            Farmer f = (Farmer)Session["Farmer"];
            PacketOrder p = new PacketOrder();
            p.FarmerID = f.FarmerID;
            DataTable dt = p.selectByFarmerIDAndStatus("SUBMITTED");

            return View(dt);


        }
        public ActionResult PacketOrderDelete(int ID)
        {
            PacketOrder p = new PacketOrder();
            p.PacketOrderID = ID;
            p.delete();
            return RedirectToAction("OrderSummary");

        }
       

       
       
        
        private void SendEmail(string To, string Subject, string Body)
        {
            try
            {
                var fromAddress = new MailAddress("agristore2@gmail.com", "agristore2@gmail.com");
                var toAddress = new MailAddress(To, To);
                string fromPassword = "amiswati";

                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

                var message = new MailMessage();
                message.IsBodyHtml = true;
                message.To.Add(toAddress);
                message.From = fromAddress;
                message.Subject = Subject;
                message.Body = Body;
                smtp.Send(message);
            }
            catch { }
        }
        [HttpPost]
        public ActionResult Checkout()
        {
            if(Session["Farmer"]!=null)
            {
                Farmer f = (Farmer)Session["Farmer"];
                PacketOrder po = new PacketOrder();
                po.FarmerID = f.FarmerID;
                DataTable dt = po.selectByFarmerIDAndStatus("PENDING");
                String allpackets = "";
                double totalprice = 0;
                foreach(DataRow dr in dt.Rows)
                {
                    String packetname = dr["Title"].ToString();
                    String qty = dr["Qty"].ToString();
                    String netprice = dr["NetPrice"].ToString();
                    String farmername = f.Name;
                    String farmeremail = f.Email;
                    String retailername = dr["RetailerName"].ToString();
                    String retaileremail = dr["RetailerEmail"].ToString();
                    String PacketPhoto = dr["Photo"].ToString();

                    SendEmail(retaileremail, "New Order Received from Agri Store !!!", "Order from " + farmername + ", \n" +packetname +"(QTY: "+qty+")" +" = Rs. "+netprice);

                    allpackets += "\n" + packetname + "(QTY = " + qty + ")" + " = Rs. " + netprice;
                    totalprice += Convert.ToSingle(netprice);

                }
                





                // Email to 1 Farmer
                SendEmail(f.Email, "Thank you!", "Thank You " + f.Name + " for shopping with Agri Store!"+"\n"+allpackets+"\n\n\nTotal Price = "+totalprice);
                // Conbvert order to submitted
                f.MarkAllAsCheckedOut();


            }

           
         
            return RedirectToAction("MyOrders","Farmer");
        }
    }
}

