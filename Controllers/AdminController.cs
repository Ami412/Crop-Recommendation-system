using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myproject.Models;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Controllers
{
    public class AdminController : Controller
    {
      
       

        //--------------------------------------------------CROP TYPE-------------------------------------------------------------//



        public ActionResult CropTypeDetail()
        {
            return View();

        }

        public ActionResult CropTypeInsert()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CropTypeInsert(FormCollection collection)

        {
            CropType ct = new CropType();
            ct.Name = collection["Name"];

            if (Request.Files["Photo"] != null)
            {
                string path = "/croptypeimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                Request.Files["Photo"].SaveAs(Server.MapPath(path));
                ct.Photo = path;
            }
            else
            {
                ct.Photo = "";
            }
            ct.insert();
            return RedirectToAction("CropTypeList");


        }
        public ActionResult CropTypeList()
        {
            CropType ct = new CropType();
            DataTable dt = ct.selectall();
            return View(dt);

        }

        public ActionResult CropTypeDelete(int ID)
        {
            CropType p = new CropType();
            p.CropTypeID = ID;
            p.delete();
            return RedirectToAction("CropTypeList");
        }


        public ActionResult CropTypeEdit(int id)
        {
            CropType c = new CropType();
            c.CropTypeID = id;
            c.SelectByID();

           // CropType CT = new Models.CropType();
            //ViewBag.dtCT = CT.selectall();

            return View(c);
        }

        [HttpPost]
        public ActionResult CropTypeUpdate(FormCollection collection)
        {
            CropType c = new CropType();
            c.CropTypeID = Convert.ToInt32(collection["CropTypeID"]);
            c.SelectByID();
            c.Name = collection["Name"];
            if (Request.Files["Photo"].ContentLength > 0)
            {
                string path = "/croptypeimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                Request.Files["Photo"].SaveAs(Server.MapPath(path));
                c.Photo = path;
            }

            c.update();

            return RedirectToAction("CropTypeList");
        }





        //------------------------------------------------CROP---------------------------------------------------------//
        



        public ActionResult CropDetail()
        {
            CropType CT = new Models.CropType();
             ViewBag.dtCT = CT.selectall();
            return View();
        }

        /*   public ActionResult CropInsert(int ID)
           {
               CropType ct = new CropType();
               DataTable dt = ct.selectall();
               ViewBag.CropType = dt;
               Crop c = new Crop();
               c.CropID = ID;
               c.SelectByID();
               return View(c);
           }*/

        [HttpPost]
        public ActionResult CropInsert(FormCollection collection)
        {
            Crop c = new Crop();
            /* c.CropID = Convert.ToInt32(collection["CropID"]);
             if (c.CropID > 0)
             {

                 c.SelectByID();
                 c.CropID = Convert.ToInt32(collection["CropID"]);
                 c.Name = collection["Name"];
                 if (Request.Files["Photo"] != null)
                 {
                     string path = "/cropimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                     Request.Files["Photo"].SaveAs(Server.MapPath(path));
                     c.Photo = path;
                 }

                 c.Details = collection["Details"];
                 c.Season = collection["Season"];
                 c.SoilType = collection["SoilType"];
                 c.update();
                 return RedirectToAction("CropList");


             }   
             else
             { */

            c.Name = collection["Name"];
            if (Request.Files["Photo"] != null)
            {
                string path = "/cropimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                Request.Files["Photo"].SaveAs(Server.MapPath(path));
                c.Photo = path;
            }
            else
            {
                c.Photo = "";
            }
            c.CropTypeID = Convert.ToInt32(collection["CropTypeID"]);
            c.Details = collection["Details"];
            c.Season = collection["Season"];
            c.SoilType = collection["SoilType"];
            c.insert();
            return RedirectToAction("CropList");
        }
        //  }



        public ActionResult CropList()
        {
            Crop c = new Crop();
            DataTable dt = c.selectall();
            return View(dt);

        }
        public ActionResult CropDelete(int ID)
        {
            Crop p = new Crop();
            p.CropID = ID;
            p.delete();
            return RedirectToAction("CropList");
        }
        public ActionResult CropEdit(int id)
        {
            Crop c = new Crop();
            c.CropID = id;
            c.SelectByID();

            CropType CT = new Models.CropType();
            ViewBag.dtCT = CT.selectall();

            return View(c);
        }

        /*public ActionResult Crops(int ID)
        {
            Crop c = new Crop();
            c.CropTypeID = ID;
            DataTable dt = c.selectbycroptypeid();
            return View(dt);
        }*/

        [HttpPost]
        public ActionResult Update(FormCollection collection)
        {
            Crop c = new Crop();
            c.CropID = Convert.ToInt32(collection["CropID"]);
            c.SelectByID();
            c.Name = collection["Name"];
            if (Request.Files["Photo"].ContentLength > 0)
            {
                string path = "/cropimgs/" + DateTime.Now.Ticks.ToString() + "_" + Request.Files["Photo"].FileName;
                Request.Files["Photo"].SaveAs(Server.MapPath(path));
                c.Photo = path;
            }
           
            c.CropTypeID= Convert.ToInt32(collection["CropTypeID"]);
            c.Details = collection["Details"];

            c.Season = collection["Season"];
            c.SoilType = collection["SoilType"];

            c.update();

            return RedirectToAction("CropList");
        }


        //---------------------------------------------------STAFF----------------------------------------------------------------//
       



        public ActionResult StaffDetail()
        {

            return View();
        }

        public ActionResult StaffInsert()
        {

            return View();
        }

        [HttpPost]
        public ActionResult StaffInsert(FormCollection collection)
        {
            Staff S = new Staff();

            S.Name = collection["Name"];
            S.Email = collection["Email"];
            S.Phone = collection["Phone"];
            S.Username = collection["Username"];
            S.Password = collection["Password"];


            S.insert();


            return RedirectToAction("StaffList");
            //return RedirectToAction("Edit/" + E.ID);
        }

        public ActionResult StaffList()
        {
           


               Staff s = new Staff();
              DataTable dt = s.selectall();
            return View(dt);

        }


        public ActionResult StaffEdit(int id)
        {
            Staff s = new Staff();
            s.StaffID = id;
            s.SelectByID();

            return View(s);

        }

        [HttpPost]
        public ActionResult StaffUpdate(FormCollection collection)
        {
            Staff d = new Staff();
            d.StaffID = Convert.ToInt32(collection["StaffID"]);
            d.Name = collection["Name"];
            d.Email = collection["Email"];
            d.Phone = collection["Phone"];
            d.Username = collection["Username"];
            d.Password = collection["Password"];
            d.update();

            return RedirectToAction("StaffList");
        }

        public ActionResult StaffDelete(int ID)
        {
            Staff d = new Staff();
            d.StaffID = ID;
            d.delete();
            return RedirectToAction("StaffList");
        }



        //----------------------------------------------------DISTRICT-----------------------------------------------------------//
      



        public ActionResult DistrictDetail()
        {
            return View();
        }

        public ActionResult DistrictInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DistrictInsert(FormCollection collection)
        {
            District d = new District();
            d.Name = collection["Name"];
            d.StateName = collection["StateName"];
            d.CountryName = collection["CountryName"];
            d.insert();
            return RedirectToAction("DistrictList");

        }

        public ActionResult DistrictList()
        {
            District d = new District();
            DataTable dt = d.selectall();
            return View(dt);

        }
        [HttpPost]
        public ActionResult DistrictUpdate(FormCollection collection)
        {
            District d = new District();
            d.DistrictID = Convert.ToInt32(collection["DistrictID"]);
            d.Name = collection["Name"];
            d.StateName = collection["StateName"];
            d.CountryName = collection["CountryName"];


            d.update();

            return RedirectToAction("DistrictList");

        }


        public ActionResult DistrictEdit(int id)
        {
            District d = new District();
            d.DistrictID = id;
            d.SelectByID();

            return View(d);


        }

        public ActionResult DistrictDelete(int ID)
        {
            District d = new District();
            d.DistrictID = ID;
            d.delete();
            return RedirectToAction("DistrictList");
        }



        //----------------------------------------------------VIDEO CATEGORY-----------------------------------------------------------//




        public ActionResult VideoCategoryDetail()
        {
            return View();
        }

        public ActionResult VideoCategoryInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VideoCategoryInsert(FormCollection collection)
        {
            VideoCategory d = new VideoCategory();
            d.CategoryName = collection["CategoryName"];
           
            d.insert();
            return RedirectToAction("VideoCategoryList");

        }

        public ActionResult VideoCategoryList()
        {
            VideoCategory d = new VideoCategory();
            DataTable dt = d.selectall();
            return View(dt);

        }


        public ActionResult VideoCategoryEdit(int id)
        {
            VideoCategory d = new VideoCategory();
            d.VideoCategoryID = id;
            d.SelectByID();

            return View(d);


        }


        [HttpPost]
        public ActionResult VideoCategoryUpdate(FormCollection collection)
        {
            VideoCategory d = new VideoCategory();
            d.VideoCategoryID = Convert.ToInt32(collection["VideoCategoryID"]);
           
            d.CategoryName = collection["CategoryName"];
           
             d.update();

            return RedirectToAction("VideoCategoryList");

        }


        public ActionResult VideoCategoryDelete(int ID)
        {
            VideoCategory d = new VideoCategory();
            d.VideoCategoryID = ID;
            d.delete();
            return RedirectToAction("VideoCategoryList");
        }


       //------------------------------------------------------TRAINING VIDEO----------------------------------------------------------//

        public ActionResult TrainingVideoDetail()
        {
            Staff s = new Models.Staff();
            ViewBag.dts = s.selectall();

            VideoCategory vc = new Models.VideoCategory();
            ViewBag.dtvc = vc.selectall();
            return View();
            
        }

        public ActionResult TrainingVideoInsert()
        {
            return View();
        }


        [HttpPost]
        public ActionResult TrainingVideoInsert(FormCollection collection)
        {
            TrainingVideo d = new TrainingVideo();
            d.UploadTime = Convert.ToDateTime(DateTime.Now.ToString()); //Convert.ToDateTime(DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss"));

            d.VideoTitle = collection["VideoTitle"];
            d.VideoURL = collection["VideoURL"];
            d.StaffID = Convert.ToInt32(collection["StaffID"]);
            d.VideoCategoryID = Convert.ToInt32(collection["VideoCategoryID"]);
            d.HelpfulCount = Convert.ToInt32(collection["HelpfulCount"]);
            d.TotalCount = Convert.ToInt32(collection["TotalCount"]);


            d.insert();
            return RedirectToAction("TrainingVideoDetail");

        }
        public ActionResult TrainingVideoList()
        {
           TrainingVideo d = new TrainingVideo();
            DataTable dt = d.selectall();
            return View(dt);

        }
        public ActionResult TrainingVideoEdit(int id)
        {
            TrainingVideo c = new TrainingVideo();
            c.TrainingVideoID = id;
            c.SelectByID();

         
            Staff s = new Models.Staff();
            ViewBag.dts = s.selectall();

            VideoCategory vc = new Models.VideoCategory();
            ViewBag.dtvc = vc.selectall();

            return View(c);
        }

        [HttpPost]
        public ActionResult TrainingVideoUpdate(FormCollection collection)
        {
            TrainingVideo d = new TrainingVideo();
            d.TrainingVideoID = Convert.ToInt32(collection["TrainingVideoID"]);
            d.SelectByID();
            d.UploadTime = Convert.ToDateTime(DateTime.Now.ToString());


            d.VideoTitle = collection["VideoTitle"];
            d.VideoURL = collection["VideoURL"];
            d.StaffID = Convert.ToInt32(collection["StaffID"]);
            d.VideoCategoryID = Convert.ToInt32(collection["VideoCategoryID"]);
            d.HelpfulCount = Convert.ToInt32(collection["HelpfulCount"]);
            d.TotalCount = Convert.ToInt32(collection["TotalCount"]);
            d.update();

            return RedirectToAction("TrainingVideoList");

        }


        public ActionResult TrainingVideoDelete(int ID)
        {
            TrainingVideo d = new TrainingVideo();
            d.TrainingVideoID = ID;
            d.delete();
            return RedirectToAction("TrainingVideoList");
        }
        //---------------------------------------------------------------------Staff Welcome Page-------------------------------------------------------------------//

        public ActionResult WelcomePage()
        {
            return View();
        }


        //---------------------------------------------------------------------Farmer----------------------------------------------------------//

        public ActionResult FarmerList()
        {
            Farmer d = new Farmer();
            DataTable dt = d.selectall();
            return View(dt);
        }


        public ActionResult FarmerDelete(int ID)
        {
            Farmer p = new Farmer();
            p.FarmerID = ID;
            p.delete();
            return RedirectToAction("FarmerList");
        }

        public ActionResult FarmerList1()
        {
            Farmer d = new Farmer();
            DataTable dt = d.selectall();
            return View(dt);
        }


        public ActionResult FarmerDelete1(int ID)
        {
            Farmer p = new Farmer();
            p.FarmerID = ID;
            p.delete();
            return RedirectToAction("FarmerList1");
        }
        [HttpPost]
        public ActionResult FarmerSearch(FormCollection collection)
        {
            string Name = collection["Name"];
          
            Farmer f = new Farmer();
            DataTable dt = f.Search(Name);
            return View(dt);

        }

        //---------------------------------------------------------------------Retailer----------------------------------//

        public ActionResult RetailerList()
        {
            Retailer d = new Retailer();
            DataTable dt = d.selectall();
            return View(dt);
        }

        public ActionResult RetailerDelete(int ID)
        {
            Retailer p = new Retailer();
            p.RetailerID = ID;
            p.delete();
            return RedirectToAction("RetailerList");
        }
    }

}