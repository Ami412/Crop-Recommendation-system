using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;
namespace myproject.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int insert()
        {

            string query = "INSERT INTO Staff VALUES(@Name, @Email, @Phone, @Username, @Password)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));
           
            return DataAccess.ModifyData(query, lstParams);
        }

        public DataTable selectall()
        {
            String query = "Select * from Staff";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }
        public bool SelectByID()
        {
            string query = "SELECT * FROM Staff WHERE StaffID = @StaffID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@StaffID", this.StaffID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();


                return true;
            }
            else
            {
                return false;
            }

        }
        public int update()
        {
            string query = "UPDATE Staff SET Name = @Name, Email= @Email, Phone=@Phone, Username=@Username, Password=@Password WHERE StaffID = @StaffID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@StaffID", this.StaffID));
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));


            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE Staff WHERE StaffID = @StaffID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@StaffID", this.StaffID));
            return DataAccess.ModifyData(query, lstParams);
        }


        public bool Authenticate()
        {
            string query = "SELECT * FROM Staff WHERE Username = @Username AND Password = @Password";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
               
                return true;
            }
            else
            {
                return false;
            }


        }



    }
}