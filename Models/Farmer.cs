using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class Farmer
    {
        public int FarmerID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int DistrictID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SoilType { get; set; }
        public string LandQty { get; set; }
        public string Status { get; set; }

        public int insert()
        {
            //string query = "INSERT INTO customer VALUES('" + this.Name + "', '" + this.Email + "', '" + this.Phone + "')";
            string query = "INSERT INTO Farmer VALUES(@Name, @Username, @Password, @Address, @City, @DistrictID, @Email, @Phone, @SoilType, @landQty, @Status)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));
            lstParams.Add(new SqlParameter("@Address", this.Address));
            lstParams.Add(new SqlParameter("@City", this.City));
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@SoilType", this.SoilType));
            lstParams.Add(new SqlParameter("@LandQty", this.LandQty));
            lstParams.Add(new SqlParameter("@Status", this.Status));

            return DataAccess.ModifyData(query, lstParams);
        }


        public int update()
        {
            string query = "UPDATE Farmer SET Name = @Name, Username = @Username, Password = @Password, Address = @Address, City = @City, DistrictID = @DistrictID, Email = @Email, Phone = @Phone, SoilType = @SoilType, LandQty = @LandQty, Status = @Status WHERE FarmerID = @FarmerID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FarmerID", this.FarmerID));

            lstParams.Add(new SqlParameter("@Name", this.Name));
            lstParams.Add(new SqlParameter("@Username", this.Username));
            lstParams.Add(new SqlParameter("@Password", this.Password));
            lstParams.Add(new SqlParameter("@Address", this.Address));
            lstParams.Add(new SqlParameter("@City", this.City));
            lstParams.Add(new SqlParameter("@DistrictID", this.DistrictID));
            lstParams.Add(new SqlParameter("@Email", this.Email));
            lstParams.Add(new SqlParameter("@Phone", this.Phone));
            lstParams.Add(new SqlParameter("@SoilType", this.SoilType));
            lstParams.Add(new SqlParameter("@LandQty", this.LandQty));
            lstParams.Add(new SqlParameter("@Status", this.Status));

            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE Farmer WHERE FarmerID = @FarmerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FarmerID", this.FarmerID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
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
                this.DistrictID = Convert.ToInt32(dt.Rows[0]["DistrictID"].ToString());
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

        }


        public bool AuthenticateFarmer()
        {
            String query = "select * from Farmer where Username = @Username AND Password = @Password";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@Username", this.Username));
            lstprms.Add(new SqlParameter("@Password", this.Password));
            DataTable dt = DataAccess.SelectData(query, lstprms);
            if (dt.Rows.Count > 0)
            {

                this.FarmerID = Convert.ToInt32( dt.Rows[0]["FarmerID"]);
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
                this.City = dt.Rows[0]["City"].ToString();
                this.DistrictID= Convert.ToInt32(dt.Rows[0]["DistrictID"].ToString());
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

        }

        public void MarkAllAsCheckedOut()
        {
            String q = "update PacketOrder set Status = 'SUBMITTED' where Status='PENDING' and FarmerID = @FarmerID ";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@FarmerID", this.FarmerID));
            DataAccess.ModifyData(q, lstprms);

        }

        public DataTable selectall()
        {
            String query = "Select * from Farmer";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }

        public DataTable SelectByFarmerID(int CatID)
        {
            String query = "Select * from Farmer WHERE FarmerID=@FarmerID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@FarmerID", CatID));

            return DataAccess.SelectData(query, lstprms);
        }

        public DataTable SelectByEmailID1()
        {
            String query = "Select * from Farmer WHERE Email=@Email";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@Email", this.Email));

            return DataAccess.SelectData(query, lstprms);
        }

        public bool SelectByEmailID()
        {
            string query = "SELECT * FROM Farmer WHERE Email=@Email";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Email", this.Email));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.FarmerID = Convert.ToInt32(dt.Rows[0]["FarmerID"]);
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.Address = dt.Rows[0]["Address"].ToString();
                this.City = dt.Rows[0]["City"].ToString();
                this.DistrictID = Convert.ToInt32(dt.Rows[0]["DistrictID"].ToString());
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

        }

        public DataTable Search(string Name)
        {
            String query = @"SELECT f.*, d.Name
                            FROM Farmer as f
                               INNER JOIN District d ON d.DistrictID=f.DistrictID
                                WHERE (f.Name LIKE '%'+@Name+'%')";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name",Name));

          
            DataTable dt = DataAccess.SelectData(query, lstParams);
            return (dt);

        }

    }
}