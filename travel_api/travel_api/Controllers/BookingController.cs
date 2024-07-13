using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using travel_api.Models;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Web.Configuration;
using System.Web;
using Newtonsoft.Json.Linq;

namespace travel_api.Controllers
{
    public class BookingController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object add_booking(tourbooking tourbooking)
        {
            try
            {
             

                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_tourbooking";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@booking_code", tourbooking.booking_code);
                sqlCmd.Parameters.AddWithValue("@parson", tourbooking.parson);
                sqlCmd.Parameters.AddWithValue("@Tour_code", tourbooking.Tour_code);
                sqlCmd.Parameters.AddWithValue("@user_code", tourbooking.user_code);
                sqlCmd.Parameters.AddWithValue("@Booking_for_person_name", tourbooking.Booking_for_person_name);

                sqlCmd.Parameters.AddWithValue("@Booking_for_person_Email", tourbooking.Booking_for_person_Email);

                sqlCmd.Parameters.AddWithValue("@Booking_for_person_Mobile", tourbooking.Booking_for_person_Mobile);

                sqlCmd.Parameters.AddWithValue("@StatusCode", tourbooking.StatusCode);

            



                myConnection.Open();

                SqlDataReader reader = null;
                reader = sqlCmd.ExecuteReader();
                result_sp result_sp = null;

                List<result_sp> result_splist = new List<result_sp>();
                //while (reader.Read())
                //{
                //    result_sp result_Sp  = new result_sp();
                //    result_sp.msg = reader.GetValue(0).ToString();
                //    result_sp.code = reader.GetValue(1).ToString();

                //    result_splist.Add(result_sp);

                //}
                myConnection.Close();
                return result_splist;


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object getCustomerTourData(CustomerTour CustomerTour)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "get_customer_date";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@user_code", CustomerTour.code);
                sqlCmd.Parameters.AddWithValue("@Usertype", CustomerTour.Usertype_code);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<Tour> Tour_list = new List<Tour>();
                Tour Tour = new Tour();
                while (reader.Read())
                {
                    Tour = new Tour();
                    Tour.tour_code = Convert.ToInt32(reader.GetValue(0));
                    Tour.tour_name = reader.GetValue(1).ToString();
                    Tour.tour_day = reader.GetValue(2).ToString();
                    Tour.tour_night = reader.GetValue(3).ToString();
                    Tour.tour_price = reader.GetValue(4).ToString();
                    Tour.user_name = reader.GetValue(5).ToString();
                    Tour.booking_id = reader.GetValue(6).ToString();
                    Tour.booking_code = reader.GetValue(7).ToString();
                    Tour.Booking_for_person_name = reader.GetValue(8).ToString();
                    Tour.Booking_for_person_Email = reader.GetValue(9).ToString();
                    Tour.Booking_for_person_Mobile = reader.GetValue(10).ToString();
                    Tour.status = reader.GetValue(11).ToString();
                    Tour.ticketname = reader.GetValue(12).ToString();

                    Tour_list.Add(Tour);

                }
                myConnection.Close();
                return Tour_list;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }


        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage imagesave(int BookingCode)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            foreach (string file in httpRequest.Files)
            {
                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999);
                var postedFile = httpRequest.Files[file];



                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "add_update_ticket_name";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@booking_code", BookingCode);
                sqlCmd.Parameters.AddWithValue("@ticket_name", myRandomNo + ".pdf");
                myConnection.Open();

                SqlDataReader reader = null;
                reader = sqlCmd.ExecuteReader();
               
               
              
                myConnection.Close();

                var filePath = HttpContext.Current.Server.MapPath("~/ticket/" + myRandomNo+ ".pdf");
                postedFile.SaveAs(filePath);
             
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }



        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public object statusHelp()
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "status_help";
                sqlCmd.Connection = myConnection;
            
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<status_help> status_help_list = new List<status_help>();

                while (reader.Read())
                {
                   var status_help = new status_help
                   {
                        id = Convert.ToInt32(reader.GetValue(0)),
                        name = reader.GetValue(1).ToString(),
                   
                    };
                    status_help_list.Add(status_help);

                }
                myConnection.Close();
                return status_help_list;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }



        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object statusChange(statuschange statuschange)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "change_status";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@StatusCode", statuschange.StatusCode);
          
                sqlCmd.Parameters.AddWithValue("@booking_code", statuschange.booking_code);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
               
         
                myConnection.Close();
                return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

    }
}