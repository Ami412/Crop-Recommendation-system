using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myproject.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace myproject.Models
{
    public class TrainingVideo
    {
        public int TrainingVideoID { get; set; }
        public DateTime? UploadTime { get; set; }
        public string VideoTitle { get; set; }
        public string VideoURL { get; set; }
        public int StaffID { get; set; }
        public int VideoCategoryID { get; set; }
        public int HelpfulCount { get; set; }
        public int TotalCount { get; set; }

        public int insert()
        {

            string query = "INSERT INTO TrainingVideo VALUES(@UploadTime, @VideoTitle,  @VideoURL, @StaffID, @VideoCategoryID, @HelpfulCount, @TotalCount)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@UploadTime", this.UploadTime));
            lstParams.Add(new SqlParameter("@VideoTitle", this.VideoTitle));
            lstParams.Add(new SqlParameter("@VideoURL", this.VideoURL));
            lstParams.Add(new SqlParameter("@StaffID", this.StaffID));
            lstParams.Add(new SqlParameter("@VideoCategoryID", this.VideoCategoryID));
            lstParams.Add(new SqlParameter("@HelpfulCount", this.HelpfulCount));
            lstParams.Add(new SqlParameter("@TotalCount", this.TotalCount));
          
            return DataAccess.ModifyData(query, lstParams);
        }

        public int update()
        {
            string query = "UPDATE TrainingVideo SET UploadTime=@UploadTime, VideoTitle=@VideoTitle, VideoURL=@VideoURL, StaffID=@StaffID, VideoCategoryID=@VideoCategoryID, HelpfulCount=@HelpfulCount, TotalCount=@TotalCount  WHERE TrainingVideoID=@TrainingVideoID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@TrainingVideoID", this.TrainingVideoID));
            lstParams.Add(new SqlParameter("@UploadTime", this.UploadTime));
            lstParams.Add(new SqlParameter("@VideoTitle", this.VideoTitle));
            lstParams.Add(new SqlParameter("@VideoURL", this.VideoURL));
            lstParams.Add(new SqlParameter("@StaffID", this.StaffID));
            lstParams.Add(new SqlParameter("@VideoCategoryID", this.VideoCategoryID));
            lstParams.Add(new SqlParameter("@HelpfulCount", this.HelpfulCount));
            lstParams.Add(new SqlParameter("@TotalCount", this.TotalCount));



            return DataAccess.ModifyData(query, lstParams);
        }

        public int delete()
        {
            string query = "DELETE TrainingVideo WHERE TrainingVideoID = @TrainingVideoID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@TrainingVideoID", this.TrainingVideoID));
            return DataAccess.ModifyData(query, lstParams);
        }

        public bool SelectByID()
        {
            string query = "SELECT * FROM TrainingVideo WHERE TrainingVideoID = @TrainingVideoID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@TrainingVideoID", this.TrainingVideoID));
            DataTable dt = DataAccess.SelectData(query, lstParams);

            if (dt.Rows.Count > 0)
            {
                this.UploadTime = Convert.ToDateTime(dt.Rows[0]["UploadTime"].ToString());
                this.VideoTitle = dt.Rows[0]["VideoTitle"].ToString();
                this.VideoURL = dt.Rows[0]["VideoURL"].ToString();
                this.StaffID = Convert.ToInt16(dt.Rows[0]["StaffID"].ToString());

                this.VideoCategoryID = Convert.ToInt16(dt.Rows[0]["VideoCategoryID"].ToString());

                this.HelpfulCount = Convert.ToInt32(dt.Rows[0]["HelpfulCount"].ToString());
                this.TotalCount = Convert.ToInt32(dt.Rows[0]["TotalCount"].ToString());


                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable selectall()
        {
            String query = "Select * from TrainingVideo";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            DataTable dt = DataAccess.SelectData(query, lstprms);
            return dt;
        }

        public DataTable selectbyvideocategoryid(int ctid)
        {
            String query = "Select * from TrainingVideo WHERE VideoCategoryID=@VideoCategoryID";
            List<SqlParameter> lstprms = new List<SqlParameter>();
            lstprms.Add(new SqlParameter("@VideoCategoryID", ctid));

            return DataAccess.SelectData(query, lstprms);
        }


    }
}