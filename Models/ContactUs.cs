using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;
namespace myproject.Models
{
    public class ContactUs
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }


        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO ContactUs VALUES(@Name, @Email, @Message)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Message", this.Message));

            return DataAccess.ModifyData(query, lstParams);
        }
    }
}