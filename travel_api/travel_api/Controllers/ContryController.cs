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
    public class ContryController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_country()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_country";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            country country = null;
            List<country> country_list = new List<country>();
            while (reader.Read())
            {
                country = new country();
                country.country_code = Convert.ToInt32(reader.GetValue(0));
                country.country_name = reader.GetValue(1).ToString();

                country_list.Add(country);
            }
            return country_list;
            myConnection.Close();
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object add_update_country(country country)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_update_country";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@country_code", country.country_code);
                sqlCmd.Parameters.AddWithValue("@country_name", country.country_name);

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
        public object deleteData(country country)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "delete_country";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@country_code", country.country_code);

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