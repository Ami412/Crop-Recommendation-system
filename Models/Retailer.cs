using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using myproject.Controllers;

namespace myproject.Models
{
    public class Retailer
    {
        public int RetailerID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int DistrictID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Certificate { get; set; }
        public string Status { get; set; }


        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO Retailer VALUES(@Name, @Username, @Password, @Address, @City, @DistrictID, @Email, @Phone, @CompanyName, @Certificate, @Status)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));
            lstParams.Add(new SqlParameter("@Address", this.Address));
            lstParams.Add(new SqlParameter("@City", this.City));
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@CompanyName", this.CompanyName));
            lstParams.Add(new SqlParameter("@Certificate", this.Certificate));
            lstParams.Add(new SqlParameter("@Status", this.Status));

            return DataAccess.ModifyData(query, lstParams);
        }
        public int update()
        {
            string query = "UPDATE Retailer SET Name = @Name, Username = @Username, Password = @Password, Address=@Address, City=@City, DistrictID=@DistrictID, Email=@Email, Phone=@Phone, CompanyName=@CompanyName, Certificate=@Certificate, Status = @Status WHERE RetailerID = @RetailerID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RetailerID", this.RetailerID));
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));
            lstParams.Add(new SqlParameter("@Address", this.Address));
            lstParams.Add(new SqlParameter("@City", this.City));
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@CompanyName", this.CompanyName));
            lstParams.Add(new SqlParameter("@Certificate", this.Certificate));
            lstParams.Add(new SqlParameter("@Status", this.Status));

            return DataAccess.ModifyData(query, lstParams);
        }
        public int delete()
        {
            string query = "DELETE Retailer WHERE RetailerID = @RetailerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RetailerID", this.RetailerID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM Retailer WHERE RetailerID = @RetailerID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RetailerID", this.RetailerID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
                this.City = dt.Rows[0]["City"].ToString();
                this.DistrictID = Convert.ToInt16(dt.Rows[0]["DistrictID"].ToString());
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                this.Certificate = dt.Rows[0]["Certificate"].ToString();
                this.Status = dt.Rows[0]["Status"].ToString();

                return true;
            }
            else
            {
                return false;
            }

         }
      /*  public bool Authenticate()
        {
            string query = "SELECT * FROM Retailer WHERE Username = @Username AND Password = @Password AND IsActive = 1";

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


        } */

       public DataTable selectall()
        {
            String query = "Select * from Retailer";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }

        public bool AuthenticateRetailer()
        {
            String query = "select * from Retailer where Username = @Username AND Password = @Password";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@Username", this.Username));
            lstprms.Add(new SqlParameter("@Password", this.Password));
            DataTable dt = DataAccess.SelectData(query, lstprms);
            if (dt.Rows.Count > 0)
            {

                this.RetailerID = Convert.ToInt32(dt.Rows[0]["RetailerID"]);
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
                this.City = dt.Rows[0]["City"].ToString();
                this.DistrictID = Convert.ToInt32(dt.Rows[0]["DistrictID"].ToString());
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                this.Certificate = dt.Rows[0]["Certificate"].ToString();
                this.Status = dt.Rows[0]["Status"].ToString();


                return true;
            }
            else
            {
                return false;
            }


        }

        public bool SelectByEmailID()
        {
            string query = "SELECT * FROM Retailer WHERE Email=@Email";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Email", this.Email));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.RetailerID = Convert.ToInt32(dt.Rows[0]["RetailerID"]);
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
                this.City = dt.Rows[0]["City"].ToString();
                this.DistrictID = Convert.ToInt32(dt.Rows[0]["DistrictID"].ToString());
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                this.Certificate = dt.Rows[0]["Certificate"].ToString();
                this.Status = dt.Rows[0]["Status"].ToString();

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}



