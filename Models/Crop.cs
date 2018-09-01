using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class Crop
    {
        public int CropID { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int CropTypeID { get; set; }
        public string Details { get; set; }
        public string Season { get; set; }
        public string SoilType { get; set; }

        public int insert()
        {

            string query = "INSERT INTO Crop VALUES(@Name, @Photo, @CropTypeID, @Details, @Season, @SoilType)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Photo", this.Photo));
            lstParams.Add(new SqlParameter("@CropTypeID", this.CropTypeID));
            lstParams.Add(new SqlParameter("@Details", this.Details));
            lstParams.Add(new SqlParameter("@Season", this.Season));
            lstParams.Add(new SqlParameter("@SoilType", this.SoilType));

            return DataAccess.ModifyData(query, lstParams);
        }
        public int update()
        {
            string query = "UPDATE Crop SET Name=@Name, Photo=@Photo,CropTypeID=@CropTypeID, Details=@Details, Season=@Season, SoilType=@SoilType WHERE CropID=@CropID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropID", this.CropID));
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Photo", this.Photo));
            lstParams.Add(new SqlParameter("@CropTypeID", this.CropTypeID));
            lstParams.Add(new SqlParameter("@Details", this.Details));
            lstParams.Add(new SqlParameter("@Season", this.Season));
            lstParams.Add(new SqlParameter("@SoilType", this.SoilType));
            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE Crop WHERE CropID = @CropID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropID", this.CropID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM Crop WHERE CropID = @CropID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropID", this.CropID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Photo = dt.Rows[0]["Photo"].ToString();
                this.CropTypeID = Convert.ToInt16(dt.Rows[0]["CropTypeID"].ToString());
                this.Details = dt.Rows[0]["Details"].ToString();
                this.Season = dt.Rows[0]["Season"].ToString();
                this.SoilType = dt.Rows[0]["SoilType"].ToString();
                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable selectall()
        {
            String query = "Select * from Crop";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }
      /*  public DataTable selectbycroptypeid()
        {
            string query = "SELECT * from Crop where CropTypeID = @CropTypeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CropTypeID", this.CropTypeID));
            DataTable dt = DataAccess.SelectData(query, lstParams);
            return dt;

        }*/
        public DataTable selectbycroptypeid(int ctid)
        {
            String query = "Select * from Crop WHERE CropTypeID=@CropTypeID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@CropTypeID", ctid));

            return DataAccess.SelectData(query, lstprms);
        }


    }
}