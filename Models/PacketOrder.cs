using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;


namespace myproject.Models
{
    public class PacketOrder
    {
        public int PacketOrderID { get; set; }
        public int PacketID { get; set; }
        public int FarmerID { get; set; }
        public int RetailerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public int Qty { get; set; }
        public float Price { get; set; }
        public float NetPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
      
        public string Msg { get; set; }
        public string Rating { get; set; }
      
        public int insert()
        {

            string query = "INSERT INTO PacketOrder VALUES(@PacketID, @FarmerID, @RetailerID, @OrderDate, @Status, @Qty, @Price, @NetPrice, @PaymentStatus, @PaymentType, @Msg, @Rating)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketID", this.PacketID));
            lstParams.Add(new SqlParameter("@FarmerID", this.FarmerID));
            lstParams.Add(new SqlParameter("@RetailerID", this.RetailerID));
            lstParams.Add(new SqlParameter("@OrderDate", this.OrderDate));
            lstParams.Add(new SqlParameter("@Status", Status));
            lstParams.Add(new SqlParameter("@Qty", this.Qty));
            lstParams.Add(new SqlParameter("@Price", this.Price));
            lstParams.Add(new SqlParameter("@NetPrice", this.NetPrice));
            lstParams.Add(new SqlParameter("@PaymentStatus", this.PaymentStatus));
            lstParams.Add(new SqlParameter("@PaymentType", this.PaymentType));
            lstParams.Add(new SqlParameter("@Msg", this.Msg));
            lstParams.Add(new SqlParameter("@Rating", this.Rating));
          

            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE PacketOrder SET OrderDate=@OrderDate, Status=@Status, Qty=@Qty, Price=@Price, NetPrice=@NetPrice, PaymentStatus=@PaymentStatus, PaymentType=@PaymentType, Msg=@Msg, Rating=@Rating";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@OrderDate", this.OrderDate));
            lstParams.Add(new SqlParameter("@Status", this.Status));
            lstParams.Add(new SqlParameter("@Qty", this.Qty));
            lstParams.Add(new SqlParameter("@Price", this.Price));
            lstParams.Add(new SqlParameter("@NetPrice", this.NetPrice));
            lstParams.Add(new SqlParameter("@PaymentStatus", this.PaymentStatus));
            lstParams.Add(new SqlParameter("@PaymentType", this.PaymentType));
            lstParams.Add(new SqlParameter("@Msg", this.Msg));
            lstParams.Add(new SqlParameter("@Rating", this.Rating));
           

            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE PacketOrder WHERE PacketOrderID = @PacketOrderID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketOrderID", this.PacketOrderID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM PacketOrder WHERE PacketOrderID = @PacketOrderID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketorderID", this.PacketOrderID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.OrderDate = Convert.ToDateTime(dt.Rows[0]["OrderDate"].ToString());
                this.Status = dt.Rows[0]["Status"].ToString();
                this.Qty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                this.Price = Convert.ToInt32(dt.Rows[0]["Price"].ToString());
                this.NetPrice = Convert.ToInt32(dt.Rows[0]["NetPrice"].ToString());
                this.PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                this.PaymentType = dt.Rows[0]["PaymentType"].ToString(); 
                this.Msg = dt.Rows[0]["Msg"].ToString();
                this.Rating =dt.Rows[0]["Rating"].ToString();
             
                return true;
            }
            else
            {
                return false;
            }

        }

    



        public DataTable selectByFarmerID()
        {
            String query = @"Select P.*, R.Photo, R.Title, R.PacketID, R.PacketSize

                                from PacketOrder as P
                                inner join Packet as R on R.PacketID = P.PacketID
                                where P.FarmerID  = @FarmerID     
        ";
          //  String query = "Select * from PacketOrder WHERE FarmerID=@FarmerID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@FarmerID", this.FarmerID));

            return DataAccess.SelectData(query, lstprms);
        }
        public DataTable selectByFarmerIDAndStatus(string status)
        {
            String query = @"Select P.*, Pa.Photo, Pa.Title, Pa.PacketID, Pa.PacketSize, R.Name as 'RetailerName', R.Email as 'RetailerEmail'

                                from PacketOrder as P
                                inner join Packet as Pa on Pa.PacketID = P.PacketID
                                   inner join Retailer as R on R.RetailerID = P.RetailerID
                                where P.FarmerID  = @FarmerID    and P.Status = @Status 
        ";
            //  String query = "Select * from PacketOrder WHERE FarmerID=@FarmerID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@FarmerID", this.FarmerID));

            lstprms.Add(new SqlParameter("@Status", status));

            return DataAccess.SelectData(query, lstprms);
        }

        public DataTable selectByRetailerIDAndStatus(string status)
        {
            String query = @"Select P.*, Pa.Photo, Pa.Title, Pa.PacketID, Pa.PacketSize, f.Name as 'FarmerName', f.Email as 'FarmerEmail', f.Address as 'FarmerAddress', f.City as 'FarmerCity'

                                from PacketOrder as P
                                inner join Packet as Pa on Pa.PacketID = P.PacketID
                                  inner join Farmer as f on f.FarmerID= p.FarmerID
                                where P.RetailerID  = @RetailerID    and P.Status = @Status 
        ";
            //  String query = "Select * from PacketOrder WHERE FarmerID=@FarmerID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@RetailerID", this.RetailerID));

            lstprms.Add(new SqlParameter("@Status", status));

            return DataAccess.SelectData(query, lstprms);
        }
    }
}