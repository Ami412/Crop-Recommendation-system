using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;
namespace myproject.Models
{
    public class Feedback
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string NatureOfFeedback { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }



        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO Feedback VALUES(@Name, @Email, @Phone, @Address, @NatureOfFeedback, @Subject, @Comment)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@Address", this.Address));
            lstParams.Add(new SqlParameter("@NatureOfFeedback", this.NatureOfFeedback));
            lstParams.Add(new SqlParameter("@Subject", this.Subject));
            lstParams.Add(new SqlParameter("@Comment", this.Comment));

            return DataAccess.ModifyData(query, lstParams);
        }
    }
}