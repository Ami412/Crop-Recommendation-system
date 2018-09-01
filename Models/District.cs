using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;


namespace myproject.Models
{
    public class District
    {
        public int DistrictID { get; set; }
        public string Name { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }



        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO District VALUES(@Name, @StateName, @CountryName)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@StateName", this.StateName));
            lstParams.Add(new SqlParameter("@CountryName", this.CountryName));


            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE District SET Name = @Name, StateName = @StateName, CountryName=@CountryName WHERE DistrictID = @DistrictID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@StateName", this.StateName));
            lstParams.Add(new SqlParameter("@CountryName", this.CountryName));

            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE District WHERE DistrictID = @DistrictID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            return DataAccess.ModifyData(query, lstParams);
        }


        public DataTable selectall()
        {
            String query = "Select * from District";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM District WHERE DistrictID = @DistrictID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.StateName = dt.Rows[0]["StateName"].ToString();
                this.CountryName = dt.Rows[0]["CountryName"].ToString();
               
                return true;
            }
            else
            {
                return false;
            }

        }

        public void SelectDistrictById()
        {
            String query = "Select * from District where DistrictID=@DistrictID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@DistrictID", this.DistrictID));
            DataTable dt = DataAccess.SelectData(query, lstprms);
            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.StateName = dt.Rows[0]["StateName"].ToString();
                this.CountryName = dt.Rows[0]["CountryName"].ToString();



            }
        }


    }
}