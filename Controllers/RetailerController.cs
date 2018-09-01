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
    public class RetailerController : Controller
    {
        // GET: retailer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPasswordRetailer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RetailerEmail(FormCollection col)
        {
            Retailer f = new Retailer();
            f.Email = col["email"];

            f.SelectByEmailID();

            f.Password = "bn7h98g56d";
            SendEmail(f.Email, "Password changed!", "Your password has been changed to bn7h98g56d. You can change your password as per your need by login into your account.");
            f.update();
            return RedirectToAction("RetailerLogin", "Guest");

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
                message.To.Add(toAddress);
                message.From = fromAddress;
                message.Subject = Subject;
                message.Body = Body;
                smtp.Send(message);
            }
            catch { }
        }


        //----------------------------------------------------PACKET---------------------------------------------------------------------------//
        public ActionResult PacketDetail()
        {
            Crop C = new Models.Crop();
            ViewBag.dtC = C.selectall();
            Retailer R = new Models.Retailer();
            ViewBag.dtR = R.selectall();
            return View();
        }

        public ActionResult PacketDetail1()
        {
            Crop C = new Models.Crop();
            ViewBag.dtC = C.selectall();
          
            return View();
        }



        public ActionResult PacketInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PacketInsert(FormCollection collection)
        {
            Retailer R = (Retailer)Session["Retailer"];
            Packet p = new Packet();
            p.Title = collection["Title"];
           
            if (Request.Files["Photo"] != null)
            {
                string path = "/Packetimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                Request.Files["Photo"].SaveAs(Server.MapPath(path));
                p.Photo = path;
            }
            else
            {
                p.Photo = "";
            }
            p.Price = Convert.ToInt32(collection["Price"]);
            p.Description = collection["Description"];
            p.RetailerID = R.RetailerID;
            p.CropID = Convert.ToInt32(collection["CropID"]);
            p.PacketSize = collection["PacketSize"];
            p.insert();
            return RedirectToAction("PacketList");
        }

        public ActionResult PacketList()
        {

            Retailer f = (Retailer)Session["Retailer"];
            Packet p = new Packet();
            p.RetailerID = f.RetailerID;
            DataTable dt= p.selectByRetailerID();
             return View(dt);

        }

        public ActionResult PacketDelete(int ID)
        {
            Packet p = new Packet();
            p.PacketID = ID;
            p.delete();
            return RedirectToAction("PacketList");

        }

        public ActionResult PacketEdit(int id)
        {
            Packet p = new Packet();
            p.PacketID = id;
            p.SelectByID();
            return View(p);

           
        }

        [HttpPost]
        public ActionResult PacketUpdate(FormCollection collection)
        {
            Retailer R = (Retailer)Session["Retailer"];
            Packet p = new Packet();
                  
            p.PacketID = Convert.ToInt32(collection["PacketID"]);
            p.SelectByID();
            p.Title = collection["Title"];
            if (Request.Files["Photo"].ContentLength > 0)
            {
                string path = "/Packetimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                Request.Files["Photo"].SaveAs(Server.MapPath(path));
                p.Photo = path;
            }
            p.Price = Convert.ToInt32(collection["Price"]);
            p.Description = collection["Description"];
            p.RetailerID = R.RetailerID;
           // p.CropID = Convert.ToInt16(collection["CropID"]);
            p.PacketSize = collection["PacketSize"];
            p.update();
          //  Session["Retailer"] = p;

            return RedirectToAction("PacketList");
        }

        public ActionResult RetailerEdit()
        {

            District CT = new Models.District();
            ViewBag.dtCT = CT.selectall();
            return View();
        }

        [HttpPost]
        public ActionResult RetailerUpdate(FormCollection collection)
        {
            Retailer c = new Retailer();
            c.RetailerID = Convert.ToInt32(collection["RetailerID"]);
            c.SelectByID();
            c.Name = collection["Name"];
            c.Username = collection["Username"];
            c.Password = collection["Password"];
            c.Address = collection["Address"];
            c.City = collection["City"];

            c.DistrictID = Convert.ToInt32(collection["DistrictID"]);
            c.Email = collection["Email"];
            c.Phone = collection["Phone"];
            c.CompanyName = collection["CompanyName"];
            if (Request.Files["Certificate"].ContentLength > 0)
            {
                string path = "/RetailerCertificateIMG/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Certificate"].FileName;
                Request.Files["Certificate"].SaveAs(Server.MapPath(path));
                c.Certificate = path;
            }

            c.Status = "";

            c.update();
            Session["Retailer"] = c;

            return RedirectToAction("HomePage1", "Guest");
        }

        public ActionResult OrdersGot()
        {

            Retailer r = (Retailer)Session["Retailer"];
            PacketOrder p = new PacketOrder();
            p.RetailerID = r.RetailerID;
            DataTable dt = p.selectByRetailerIDAndStatus("SUBMITTED");

            return View(dt);


        }
    }
}