using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using travel_api.Models;

namespace travel_api.Controllers
{
    public class CoupanController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_coupan()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_coupan";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Coupan coupan = null;
            List<Coupan> coupan_list = new List<Coupan>();
            while (reader.Read())
            {
                coupan = new Coupan();
                coupan.coupan_code = Convert.ToInt32(reader.GetValue(0));
                coupan.coupan_name = reader.GetValue(1).ToString();
                coupan.start_date = reader.GetValue(2).ToString();
                coupan.end_date = reader.GetValue(3).ToString();
                coupan.coupan_amount = Convert.ToInt32(reader.GetValue(4));
                coupan.coupan_percentage = Convert.ToInt32(reader.GetValue(5)) ;
                coupan_list.Add(coupan);

            }
            return coupan_list;
            myConnection.Close();
        }
      

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object add_update_coupan(Coupan Coupan)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_update_coupan";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@coupan_code", Coupan.coupan_code);
                sqlCmd.Parameters.AddWithValue("@coupan_name", Coupan.coupan_name);
                sqlCmd.Parameters.AddWithValue("@start_date", Coupan.start_date);
                sqlCmd.Parameters.AddWithValue("@end_date", Coupan.end_date);
                sqlCmd.Parameters.AddWithValue("@coupan_amount", Coupan.coupan_amount);
                sqlCmd.Parameters.AddWithValue("@coupan_percentage", Coupan.coupan_percentage);

                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
                return rowInserted;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object deleteData(Coupan Coupan)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "delete_coupan";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@coupan_code", Coupan.coupan_code);

                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
                return rowInserted;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}