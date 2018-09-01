using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class ProductReview
    {
        public int ProductReviewID { get; set; }
        public string ReviewTime { get; set; }
        public string Msg { get; set; }
        public float Rating { get; set; }
        public int FarmerID { get; set; }
        public int ProductID { get; set; }

        public int insert()
        {

            string query = "INSERT INTO ProductReview VALUES(@ReviewTime, @Msg, @Rating)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ReviewTime", this.ReviewTime));
            lstParams.Add(new SqlParameter("@Msg", this.Msg));
            lstParams.Add(new SqlParameter("@Rating", this.Rating));
         
            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE PacketReview SET ReviewTime=@Reviewtime, Msg=@Msg, Rating=@Rating";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@reviewTime", this.ReviewTime));
            lstParams.Add(new SqlParameter("@Msg", this.Msg));
            lstParams.Add(new SqlParameter("@Rating", this.Rating));
         

            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE PacketReview WHERE PacketeviewID = @PacketReviewID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketReviewID", this.ProductReviewID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM PacketReview WHERE PacketReviewID = @PacketReviewID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@PacketReviewID", this.ProductReviewID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.ReviewTime = dt.Rows[0]["ReviewTime"].ToString();
                this.Msg = dt.Rows[0]["Msg"].ToString();
                this.Rating = Convert.ToInt32(dt.Rows[0]["Rating"].ToString());
               

                return true;
            }
            else
            {
                return false;
            }

        }




    }
}