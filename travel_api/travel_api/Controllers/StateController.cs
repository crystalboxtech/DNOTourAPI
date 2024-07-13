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
    public class StateController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_state()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "get_state";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            state state = null;
            List<state> state_list = new List<state>();
            while (reader.Read())
            {
                state = new state();
                state.state_code = Convert.ToInt32(reader.GetValue(0));
                state.country_code = Convert.ToInt32(reader.GetValue(1));
                state.country_name = reader.GetValue(2).ToString();
                state.state_name = reader.GetValue(3).ToString();
            
                state_list.Add(state);
            }
            return state_list;
            myConnection.Close();
        }
        [HttpGet]
        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object country_help()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "country_help";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            help help = null;
            List<help> help_list = new List<help>();
            while (reader.Read())
            {
                help = new help();
                help.id = Convert.ToInt32(reader.GetValue(0));
                help.name = reader.GetValue(1).ToString();
                help_list.Add(help);
            }
            return help_list;
            myConnection.Close();
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object add_update_state(state state)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_update_state";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@state_code", state.state_code);
                sqlCmd.Parameters.AddWithValue("@state_name", state.state_name);
                sqlCmd.Parameters.AddWithValue("@country_code", state.country_code);
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
        public object deleteData(state state)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "delete_state";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@state_code", state.state_code);

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