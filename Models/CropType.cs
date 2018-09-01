using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class CropType
    {
        public int CropTypeID { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }


        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO CropType VALUES(@Name, @Photo)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Photo", this.Photo));

            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE CropType SET Name = @Name, Photo = @Photo WHERE CropTypeID = @CropTypeID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropTypeID", this.CropTypeID));

            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Photo", this.Photo));
            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE CropType WHERE CropTypeID = @CropTypeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropTypeID", this.CropTypeID));
            return DataAccess.ModifyData(query, lstParams);
        }


        public DataTable selectall()
        {
            String query = "Select * from CropType";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }




        public bool SelectByID()
        {
            string query = "SELECT * FROM CropType WHERE CropTypeID = @CropTypeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropTypeID", this.CropTypeID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Photo = dt.Rows[0]["Photo"].ToString();
               
                return true;
            }
            else
            {
                return false;
            }

        }


        /* public bool SelectByID()
         {
             string query = "SELECT * FROM Farmer WHERE FarmerID = @FarmerID";

             List<SqlParameter> lstParams = new List<SqlParameter>();
             lstParams.Add(new SqlParameter("@FarmerID", this.FarmerID));
             DataTable dt = DataAccess.SelectData(query, lstParams);

             if (dt.Rows.Count > 0)
             {
                 this.Name = dt.Rows[0]["Name"].ToString();
                 this.Username = dt.Rows[0]["Username"].ToString();
                 this.Password = dt.Rows[0]["Password"].ToString();
                 this.Address = dt.Rows[0]["Address"].ToString();
                 this.City = dt.Rows[0]["City"].ToString();
                 this.Email = dt.Rows[0]["Email"].ToString();
                 this.Phone = dt.Rows[0]["Phone"].ToString();
                 this.SoilType = dt.Rows[0]["SoilType"].ToString();
                 this.LandQty = dt.Rows[0]["LandQty"].ToString();
                 this.Status = dt.Rows[0]["Status"].ToString();

                 return true;
             }
             else
             {
                 return false;
             }

         } */


        public void SelectCropTypeById()
        {
            String query = "Select * from CropType where CropTypeID=@CropTypeID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@CropTypeID", this.CropTypeID));
            DataTable dt = DataAccess.SelectData(query, lstprms);
            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
               
            }
        }




    }
}