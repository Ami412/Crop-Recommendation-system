using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class VideoCategory
    {
        public int VideoCategoryID { get; set; }
        public string CategoryName { get; set; }

        public int insert()
        {

            string query = "INSERT INTO VideoCategory VALUES(@CategoryName)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CategoryName", this.CategoryName));
          

            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE VideoCategory SET CategoryName=@CategoryName WHERE VideoCategoryID=@VideoCategoryID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@VideoCategoryID", this.VideoCategoryID));
            lstParams.Add(new SqlParameter("@CategoryName", this.CategoryName));


            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE VideoCategory WHERE VideoCategoryID = @VideoCategoryID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@VideoCategoryID", this.VideoCategoryID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM VideoCategory WHERE VideoCategoryID = @VideoCategoryID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@VideoCategoryID", this.VideoCategoryID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.CategoryName = dt.Rows[0]["CategoryName"].ToString();
              
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable selectall()
        {
            String query = "Select * from VideoCategory";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }

        public void SelectVideoCategoryById()
        {
            String query = "Select * from VideoCategory where VideoCategoryID=@VideoCategoryID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@VideoCategoryID", this.VideoCategoryID));
            DataTable dt = DataAccess.SelectData(query, lstprms);
            if (dt.Rows.Count > 0)
            {
                this.CategoryName = dt.Rows[0]["CategoryName"].ToString();

            }
        }

    }
}