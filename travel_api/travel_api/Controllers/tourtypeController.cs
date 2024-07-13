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
    public class tourtypeController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_tourtype()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_tourtype";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            TourType TourType = null;
            List<TourType> coupan_list = new List<TourType>();
            while (reader.Read())
            {
                TourType = new TourType();
                TourType.tourtype_code = Convert.ToInt32(reader.GetValue(0));
                TourType.tourtype_name = reader.GetValue(1).ToString();
       
                coupan_list.Add(TourType);

            }
            return coupan_list;
            myConnection.Close();
        }


        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object add_update_tourtype(TourType TourType)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_update_tour_type";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@tourtype_code", TourType.tourtype_code);
                sqlCmd.Parameters.AddWithValue("@tourtype_name", TourType.tourtype_name);

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
        public object deleteData(TourType TourType)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "delete_tourtype";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@tourtype_code", TourType.tourtype_code);

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
        public object get_tourtype_help()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_tourtype_help";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            help help = null;
            List<help> TourType_list = new List<help>();
            while (reader.Read())
            {
                help = new help();
                help.id = Convert.ToInt32(reader.GetValue(0));
                help.name = reader.GetValue(1).ToString();
                TourType_list.Add(help);

            }
            return TourType_list;
            myConnection.Close();
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object getTourTypeListWithCount()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "getTourTypeListWithCount";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            TourTypeListWithCount TourTypeListWithCount = null;
            List<TourTypeListWithCount> TourType_list = new List<TourTypeListWithCount>();
            while (reader.Read())
            {
                TourTypeListWithCount = new TourTypeListWithCount();
                TourTypeListWithCount.id = Convert.ToInt32(reader.GetValue(0));
                TourTypeListWithCount.name = reader.GetValue(1).ToString();
                TourTypeListWithCount.tourCount = reader.GetValue(2).ToString();
                TourType_list.Add(TourTypeListWithCount);

            }
            return TourType_list;
            myConnection.Close();
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object getTourContryListWithCount()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "getTourContryListWithCount";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            TourContryListWithCount TourContryListWithCount = null;
            List<TourContryListWithCount> TourType_list = new List<TourContryListWithCount>();
            while (reader.Read())
            {
                TourContryListWithCount = new TourContryListWithCount();
                TourContryListWithCount.id = Convert.ToInt32(reader.GetValue(0));
                TourContryListWithCount.name = reader.GetValue(1).ToString();
                TourContryListWithCount.tourCount = reader.GetValue(2).ToString();
                TourType_list.Add(TourContryListWithCount);

            }
            return TourType_list;
            myConnection.Close();
        }
        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_Contrytype_help()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_Contrytype_help";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            help help = null;
            List<help> ContryType = new List<help>();
            while (reader.Read())
            {
                help = new help();
                help.id = Convert.ToInt32(reader.GetValue(0));
                help.name = reader.GetValue(1).ToString();
                ContryType.Add(help);

            }
            return ContryType;
            myConnection.Close();
        }
    }
}