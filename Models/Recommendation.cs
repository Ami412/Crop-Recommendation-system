using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;
namespace myproject.Models

{
    public class Recommendation
    {
        public string SoilType { get; set; }
        public string CropName { get; set; }

        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO Recommendation VALUES(@SoilType, @CropName)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@SoilType", this.SoilType));
            lstParams.Add(new SqlParameter("@CropName", this.CropName));
           
            return DataAccess.ModifyData(query, lstParams);
        }
        public DataTable SelectBySoilType(string SoilType)
        {
            String query = @"SELECT * FROM Recommendation WHERE SoilType=@SoilType ";
          
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@SoilType", SoilType));


            DataTable dt = DataAccess.SelectData(query, lstParams);
            return (dt);

        }

       public DataTable selectall()
        {
            String query = "Select * from Recommendation WHERE Id=@Id";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        } 
    }
}







       
 