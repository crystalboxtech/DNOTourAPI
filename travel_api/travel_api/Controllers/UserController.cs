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
using System.Runtime.Remoting.Messaging;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;

namespace travel_api.Controllers
{

    public class UserController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        [System.Web.Http.Cors.EnableCors(origins:"*", headers: "*", methods: "*")]
        [HttpPost]
        public object get_user(pera pera)
        {
            try { 

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "get_user";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@SearchColumn", pera.SearchColumn);
            sqlCmd.Parameters.AddWithValue("@SearchValue", pera.SearchValue);
            sqlCmd.Parameters.AddWithValue("@PageNo", pera.PageNo);
            sqlCmd.Parameters.AddWithValue("@PageSize", pera.PageSize);
            sqlCmd.Parameters.AddWithValue("@SortColumn", pera.SortColumn);
            sqlCmd.Parameters.AddWithValue("@SortOrder", pera.SortOrder);
            SqlDataReader reader = null;
     
            reader = sqlCmd.ExecuteReader();
            user user = null;
            List<user> user_list = new List<user>();
            while (reader.Read())
            {
                user = new user();
                user.user_code = Convert.ToInt32(reader.GetValue(0));
                user.user_name = reader.GetValue(1).ToString();
                user.user_type = Convert.ToInt32(reader.GetValue(2));
                user.email = reader.GetValue(3).ToString();
                user.user_image = reader.GetValue(4).ToString();
                user.mobile_number = reader.GetValue(5).ToString();
                user.type_name = reader.GetValue(6).ToString();
                user.TotalRows = Convert.ToInt32(reader.GetValue(9));
                user_list.Add(user);
            }
            myConnection.Close();
            return user_list;

        }
            catch (Exception ex)
            {
                return ex.Message;
            }




        }
        public object get_user_type()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_user_type";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            user_type user_type = null;
            List<user_type> user_type_list = new List<user_type>();
            while (reader.Read())
            {
                user_type = new user_type();
                user_type.Usertype_code = Convert.ToInt32(reader.GetValue(0));
                user_type.type_name = reader.GetValue(1).ToString();
                user_type_list.Add(user_type);
            }
            return user_type_list;
            myConnection.Close();
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object add_update_user(user user)
        {
            try {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_update_user";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@user_code", user.user_code);
                sqlCmd.Parameters.AddWithValue("@mobile_number", user.mobile_number);
                sqlCmd.Parameters.AddWithValue("@email", user.email);
                sqlCmd.Parameters.AddWithValue("@user_name", user.user_name);
                sqlCmd.Parameters.AddWithValue("@user_type", user.user_type);
                sqlCmd.Parameters.AddWithValue("@is_locked", 0);
                sqlCmd.Parameters.AddWithValue("@is_varified", user.is_varified);
                sqlCmd.Parameters.AddWithValue("@password", user.password);
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
        public object deleteData(user user)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "delete_user";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@user_code", user.user_code);
             
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
        public object login_user(user user)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "user_login";
                sqlCmd.Connection = myConnection;
               
               
                myConnection.Open();
                sqlCmd.Parameters.AddWithValue("@username", user.user_name);
                sqlCmd.Parameters.AddWithValue("@password", user.password);
                SqlDataReader reader = null;
                login login = null;
                reader = sqlCmd.ExecuteReader();
               List<login> user_list = new List<login>();
                while (reader.Read())
                {
                    login = new login();

                    login.user_name = reader.GetValue(0).ToString();
                    login.password = reader.GetValue(1).ToString();
                    login.email = reader.GetValue(2).ToString();
                    login.mobile_number = reader.GetValue(3).ToString();
                    login.code = Convert.ToInt32(reader.GetValue(4));
                    login.msg = reader.GetValue(5).ToString();
                    login.Usertype_code = Convert.ToInt32(reader.GetValue(6));
                    login.User_code = Convert.ToInt32(reader.GetValue(7));
                    user_list.Add(login);
                }
                myConnection.Close();
                return user_list;
            
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_tour_help()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_tour_help";
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

    }
}