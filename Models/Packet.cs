using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class Packet
    {
        public int PacketID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int RetailerID { get; set; }
        public int CropID { get; set; }
        public string PacketSize { get; set; }

        public int insert()
        {

            string query = "INSERT INTO Packet VALUES(@Title, @Photo, @Price, @Description, @RetailerID, @CropID, @PacketSize)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Title", this.Title));
            lstParams.Add(new SqlParameter("@Photo", this.Photo));
            lstParams.Add(new SqlParameter("@Price", this.Price));
            lstParams.Add(new SqlParameter("@Description", this.Description));
            lstParams.Add(new SqlParameter("@RetailerID", this.RetailerID));
            lstParams.Add(new SqlParameter("@CropID", this.CropID));
            lstParams.Add(new SqlParameter("@PacketSize", this.PacketSize));

            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE Packet SET Title=@Title, Photo = @Photo, Price = @Price, Description=@Description, RetailerID=@RetailerID, CropID=@CropID, PacketSize=@PacketSize WHERE PacketID = @PacketID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketID", this.PacketID));
            lstParams.Add(new SqlParameter("@Title", this.Title));
            lstParams.Add(new SqlParameter("@Photo", this.Photo));
            lstParams.Add(new SqlParameter("@Price", this.Price));
            lstParams.Add(new SqlParameter("@Description", this.Description));
            lstParams.Add(new SqlParameter("@RetailerID", this.RetailerID));
            lstParams.Add(new SqlParameter("@CropID", this.CropID));  
            lstParams.Add(new SqlParameter("@PacketSize", this.PacketSize));
            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE Packet WHERE PacketID = @PacketID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketID", this.PacketID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM Packet WHERE PacketID = @PacketID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketID", this.PacketID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.Title = dt.Rows[0]["Title"].ToString();
                this.Photo = dt.Rows[0]["Photo"].ToString();
                this.Price = Convert.ToSingle(dt.Rows[0]["Price"].ToString());
                this.Description = dt.Rows[0]["Description"].ToString();
                this.RetailerID = Convert.ToInt32(dt.Rows[0]["RetailerID"].ToString());
                this.CropID = Convert.ToInt32(dt.Rows[0]["CropID"].ToString());

                this.PacketSize = dt.Rows[0]["PacketSize"].ToString();
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable selectall()
        {
            String query = "Select * from Packet";
            List<SqlParameter> lstParams = new List<SqlParameter>();
          
            DataTable dt = DataAccess.SelectData(query, lstParams);
            return dt;
        }
        public DataTable selectAllByCropID(int ID)
        {
            String query = @"Select P.*, R.Name, R.City, R.CompanyName

                                from Packet as P
                                inner join Retailer as R on R.RetailerID = P.RetailerID
                                where P.CropID  = @CropID     
        ";
            List<SqlParameter> lstprms = new List<SqlParameter>();

            lstprms.Add(new SqlParameter("@CropID", ID));

            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }

        public DataTable selectByPacketID(int id)
        {
            String query = @"Select P.*, R.Name, R.City, R.CompanyName, R.RetailerID

                                from Packet as P
                                inner join Retailer as R on R.RetailerID = P.RetailerID
                                where P.PacketID  = @PacketID     
        ";
           // String query = "Select * from Packet WHERE PacketID=@PacketID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@PacketID", id));

            return DataAccess.SelectData(query, lstprms);
        }

        public DataTable selectByRetailerID()
        {
            String query = "Select * from Packet WHERE RetailerID=@RetailerID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@RetailerID", this.RetailerID));

            return DataAccess.SelectData(query, lstprms);
        }

    }
}