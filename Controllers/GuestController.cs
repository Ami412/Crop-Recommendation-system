using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myproject.Models;
using System.Data;
namespace myproject.Controllers
{
    public class GuestController : Controller
    {



        //-------------------------------------------------------STAFF-------------------------------------------------//

        public ActionResult StaffLogin()
        {
            Session["Staff"] = null;
            return View();
        }


        public ActionResult Gallery()
        {
               return View();
        }
        public ActionResult gallery1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validation(FormCollection collection)
        {
            Staff S = new Staff();
            S.Username = collection["Username"];
            S.Password = collection["Password"];
            if (S.Authenticate())
            {
                Session["Staff"] = S;
                return RedirectToAction("WelcomePage", "Admin");
            }
            else
            {
                return RedirectToAction("StaffLogin");
            }
        }

        //-------------------------------------------------------RETAILER-------------------------------------------------//



        public ActionResult RetailerRegistration()
        {
            District CT = new Models.District();
            ViewBag.dtCT = CT.selectall();
            return View();

        }
        public ActionResult RetailerInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RetailerInsert(FormCollection collection)
        {
            Retailer r = new Retailer();
            r.Name = collection["Name"];
            r.Username = collection["Username"];
            r.Password = collection["Password"];
            r.Address = collection["Address"];
            r.City = collection["City"];
            r.DistrictID = Convert.ToInt16(collection["DistrictID"]);
            r.Email = collection["Email"];
            r.Phone = collection["Phone"];
            r.CompanyName = collection["CompanyName"];

            if (Request.Files["Certificate"] != null)
            {
                string path = "/RetailerCertificateIMG/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Certificate"].FileName;

                Request.Files["Certificate"].SaveAs(Server.MapPath(path));

                r.Certificate = path;
            }
            else
            {
                r.Certificate = "";
            }

            r.Status = "";
            r.insert();

            return RedirectToAction("HomePage1");

        }

        public ActionResult RetailerLogin()

        {
            Session["Retailer"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult RetailerAuthenticate(FormCollection collection)
        {
            Retailer C = new Retailer();
            C.Username = collection["Username"];
            C.Password = collection["Password"];
            if (C.AuthenticateRetailer())
            {
                Session["Retailer"] = C;
                return RedirectToAction("HomePage1", "Guest");
            }
            else
            {
                return RedirectToAction("RetailerLogin");
            }
        }









        //-------------------------------------------------------FARMER-------------------------------------------------//




        public ActionResult FarmerRegistration()
        {
            District CT = new Models.District();
            ViewBag.dtCT = CT.selectall();
            return View();
        }


        public ActionResult FarmerInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FarmerInsert(FormCollection collection)
        {
            Farmer r = new Farmer();
            r.Name = collection["Name"];
            r.Username = collection["Username"];
            r.Password = collection["Password"];
            r.Address = collection["Address"];
            r.City = collection["City"];
            r.DistrictID = Convert.ToInt32(collection["DistrictID"]);
            r.Email = collection["Email"];
            r.Phone = collection["Phone"];
            r.SoilType = collection["SoilType"];
            r.LandQty = collection["LandQty"];
            r.Status = "";
            r.insert();

            return RedirectToAction("HomePage1");

        }


        public ActionResult FarmerLogin()

        {
            Session["Farmer"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult FarmerAuthenticate(FormCollection collection)
        {
            Farmer C = new Farmer();
            C.Username = collection["Username"];
            C.Password = collection["Password"];
            if (C.AuthenticateFarmer())
            {
                Session["Farmer"] = C;
                return RedirectToAction("HomePage1", "Guest");
            }
            else
            {
                return RedirectToAction("FarmerLogin");
            }
        }


        //------------------------------------------------Crops Pages--------------------------------------------//
        public ActionResult Crops(int ID)
        {
            Crop P = new Crop();
            DataTable dtProd = P.selectbycroptypeid(ID);

            CropType C = new CropType();
            C.CropTypeID = ID;
            C.SelectCropTypeById();
            ViewBag.Cat = C;

            return View(dtProd);

        }
        public ActionResult AllPackets(int ID)
        {
            Packet P = new Packet();
            DataTable dtProd = P.selectAllByCropID(ID);



            return View(dtProd);

        }
        public ActionResult HomePage1()
        {
            return View();
        }


        public ActionResult TrainingVideos(int ID)
        {
            TrainingVideo P = new TrainingVideo();
            DataTable dtProd = P.selectbyvideocategoryid(ID);

            VideoCategory C = new VideoCategory();
            C.VideoCategoryID = ID;
            C.SelectVideoCategoryById();
            ViewBag.Cat = C;

            return View(dtProd);

        }

        public ActionResult Logout()
        {
            //Session["Retailer"] = null;
            //Session["Farmer"] = null;
            //Session["Staff"] = null;
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("HomePage1", "Guest");
        }


        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult ContactInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactInsert(FormCollection collection)
        {
            ContactUs cu = new ContactUs();
            cu.Name = collection["Name"];
            cu.Email = collection["Email"];
            cu.Message = collection["Message"];
            cu.insert();

            return RedirectToAction("HomePage1");

        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeedbackInsert(FormCollection collection)
        {
            Feedback f = new Feedback();
            f.Name = collection["Name"];
            f.Email = collection["Email"];
            f.Phone = collection["Phone"];
            f.Address = collection["Address"];
            f.NatureOfFeedback = collection["NatureOfFeedback"];
            f.Subject = collection["Subject"];

            f.Comment = collection["Comment"];
            f.insert();

            return RedirectToAction("HomePage1");
        }

        //------------------------------------------------Recommendation--------------------------------------------//

        public ActionResult Recommendation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecommendationInsert(FormCollection collection)
        {
            Recommendation r = new Recommendation();
            r.SoilType = collection["SoilType"];
            r.CropName = collection["CropName"];
            r.insert();

            return RedirectToAction("Recommendation");
        }


        public ActionResult GetRecommendation(string SoilType)
        {
            Recommendation CT = new Models.Recommendation();
            ViewBag.dtCT = CT.SelectBySoilType(SoilType);
            return View();
        }

        
    }


    

}