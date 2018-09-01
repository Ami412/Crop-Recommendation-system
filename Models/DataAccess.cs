using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace myproject.Models
{
    public class DataAccess
    {
        public static int ModifyData(string query, List<SqlParameter> lstParams)
        {
            SqlConnection connection1 = new SqlConnection();

            //  connection1.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename='C:\\USERS\\AMI\\DOCUMENTS\\VISUAL STUDIO 2015\\PROJECTS\\MYPROJECT\\MYPROJECT\\APP_DATA\\AGRIPRODUCTS.MDF';Integrated Security=True";
            //  connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\Visual Studio 2015\Projects\myproject\myproject\App_Data\agriproducts.mdf;Integrated Security=True";
            //   connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\patel\Desktop\project work\myproject\myproject\myproject\App_Data\agriproducts.mdf;Integrated Security=True";
            connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\PATEL\DESKTOP\4.4.2017\MYPROJECT\MYPROJECT\APP_DATA\AGRIPRODUCTS.MDF;Integrated Security=True";
          //  connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\FINAL-YEAR-PROJECT-BACKUP\4.4.2017\myproject\myproject\App_Data\agriproducts.mdf;Integrated Security=True";
           SqlCommand command1 = new SqlCommand();
            command1.CommandText = query;
            command1.Connection = connection1;
            for (int i = 0; i < lstParams.Count; i++)
            {
                command1.Parameters.Add(lstParams[i]);
            }

            connection1.Open();

            int x = command1.ExecuteNonQuery();

            connection1.Close();

            return x;
        }

        public static DataTable SelectData(string query, List<SqlParameter> lstParams)
        {
            SqlConnection connection1 = new SqlConnection();


            // connection1.ConnectionString= "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename='C:\\USERS\\AMI\\DOCUMENTS\\VISUAL STUDIO 2015\\PROJECTS\\MYPROJECT\\MYPROJECT\\APP_DATA\\AGRIPRODUCTS.MDF';Integrated Security=True";
            //  connection1.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Admin\\Documents\\Visual Studio 2015\\Projects\\myproject\\myproject\\App_Data\\agriproducts.mdf';Integrated Security=True;";
            //  connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\patel\Desktop\project work\myproject\myproject\myproject\App_Data\agriproducts.mdf;Integrated Security=True";

        //    connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\FINAL-YEAR-PROJECT-BACKUP\4.4.2017\myproject\myproject\App_Data\agriproducts.mdf;Integrated Security=True";
            connection1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\PATEL\DESKTOP\4.4.2017\MYPROJECT\MYPROJECT\APP_DATA\AGRIPRODUCTS.MDF;Integrated Security=True";
            SqlCommand command1 = new SqlCommand();
            command1.CommandText = query;
            command1.Connection = connection1;
            for (int i = 0; i < lstParams.Count; i++)
            {
                command1.Parameters.Add(lstParams[i]);
            }

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.SelectCommand = command1;

            DataTable dt = new DataTable();

            connection1.Open();

            adapter1.Fill(dt);

            connection1.Close();

            return dt;

        }
    }
}