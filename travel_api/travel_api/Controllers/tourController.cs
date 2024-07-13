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
using Newtonsoft.Json.Linq;
using System.Web;
using Newtonsoft.Json;

namespace travel_api.Controllers
{
    public class tourController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public Tour Tour { get; private set; }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object get_tour(Tour Tour)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "get_tour";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@tour_code", Tour.tour_code);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<Tour> Tour_list = new List<Tour>();
                while (reader.Read())
                {
                    Tour = new Tour();
                    Tour.tour_code = Convert.ToInt32(reader.GetValue(0));
                    Tour.tour_name = reader.GetValue(1).ToString();
                    Tour.tour_day = reader.GetValue(2).ToString();
                    Tour.tour_night = reader.GetValue(3).ToString();
                    Tour.tour_price = reader.GetValue(4).ToString();
                    Tour.tour_rate = Convert.ToInt32(reader.GetValue(5));
                    Tour.tour_type = reader.GetValue(6).ToString();
                    Tour.country_code = reader.GetValue(7).ToString();
                    Tour.discription = reader.GetValue(8).ToString();
                    Tour.overview = reader.GetValue(9).ToString();
                    Tour.included = reader.GetValue(10).ToString();
                    Tour.excluded = reader.GetValue(11).ToString();
                    Tour.tour_highlights = reader.GetValue(12).ToString();
                    Tour.tour_information = reader.GetValue(13).ToString();
                    //Tour.filename = HttpContext.Current.Server.MapPath("~/tourimg" + reader.GetValue(14).ToString());
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
        public object get_All_tour(pera pera)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "get_all_tour";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@SearchColumn", pera.SearchColumn);
                sqlCmd.Parameters.AddWithValue("@SearchValue", pera.SearchValue);
                sqlCmd.Parameters.AddWithValue("@PageNo", pera.PageNo);
                sqlCmd.Parameters.AddWithValue("@PageSize", pera.PageSize);
                sqlCmd.Parameters.AddWithValue("@SortColumn", pera.SortColumn);
                sqlCmd.Parameters.AddWithValue("@SortOrder", pera.SortOrder);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<Tour> Tour_list = new List<Tour>();



                while (reader.Read())
                {
                    Tour = new Tour();
                    Tour.tour_code = Convert.ToInt32(reader.GetValue(0));
                    Tour.tour_name = reader.GetValue(1).ToString();
                    Tour.tour_day = reader.GetValue(2).ToString();
                    Tour.tour_night = reader.GetValue(3).ToString();
                    Tour.tour_price = reader.GetValue(4).ToString();
                    Tour.tour_rate = Convert.ToInt32(reader.GetValue(5));
                    Tour.tour_type = reader.GetValue(6).ToString();
                    Tour.country_code = reader.GetValue(7).ToString();
                    Tour.discription = reader.GetValue(8).ToString();
                    Tour.overview = reader.GetValue(9).ToString();
                    Tour.included = reader.GetValue(10).ToString();
                    Tour.excluded = reader.GetValue(11).ToString();
                    Tour.tour_highlights = reader.GetValue(12).ToString();
                    Tour.tour_information = reader.GetValue(13).ToString();
                    Tour.tourCount = reader.GetValue(14).ToString();
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
        public object add_update_tour([FromBody] JObject tour)
        {
            try
            {

                var Tour = JsonConvert.SerializeObject(tour);




                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "insert_update_tour";
                sqlCmd.Connection = myConnection;





                sqlCmd.Parameters.AddWithValue("@tour_code", Convert.ToInt32(tour["tour_code"]));
                sqlCmd.Parameters.AddWithValue("@tour_name", tour["tour_name"].ToString());
                sqlCmd.Parameters.AddWithValue("@tour_day", tour["tour_day"].ToString());
                sqlCmd.Parameters.AddWithValue("@tour_night", tour["tour_night"].ToString());
                sqlCmd.Parameters.AddWithValue("@tour_price", tour["tour_price"].ToString());
                sqlCmd.Parameters.AddWithValue("@tour_rate", tour["tour_rate"].ToString());

                sqlCmd.Parameters.AddWithValue("@tour_type", tour["tour_type"].ToString());
                sqlCmd.Parameters.AddWithValue("@country_code", tour["country_code"].ToString());
                sqlCmd.Parameters.AddWithValue("@discription", tour["discription"].ToString());
                sqlCmd.Parameters.AddWithValue("@overview", tour["overview"].ToString());
                sqlCmd.Parameters.AddWithValue("@included", tour["included"].ToString());
                sqlCmd.Parameters.AddWithValue("@excluded", tour["excluded"].ToString());
                sqlCmd.Parameters.AddWithValue("@tour_highlights", tour["tour_highlights"].ToString());
                sqlCmd.Parameters.AddWithValue("@tour_information", tour["tour_information"].ToString());
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
        [HttpPost]

        public HttpResponseMessage imagesave(string Tourname)
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
                sqlCmd.CommandText = "add_update_image_name";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@tour_name", Tourname);
                sqlCmd.Parameters.AddWithValue("@ticket_name", postedFile.FileName);
                myConnection.Open();

                SqlDataReader reader = null;
                reader = sqlCmd.ExecuteReader();



                myConnection.Close();

                var filePath = HttpContext.Current.Server.MapPath("~/tourimg/" + postedFile.FileName);
                postedFile.SaveAs(filePath);

            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }



        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public object getSubtypeourData(TourFilter TourFilter)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "getSubtypeourData";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@filter_type", TourFilter.filter_type);
                sqlCmd.Parameters.AddWithValue("@type", TourFilter.type);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<Tour> Tour_list = new List<Tour>();

                while (reader.Read())
                {
                    Tour = new Tour
                    {
                        tour_code = Convert.ToInt32(reader.GetValue(0)),
                        tour_name = reader.GetValue(1).ToString(),
                        tour_day = reader.GetValue(2).ToString(),
                        tour_night = reader.GetValue(3).ToString(),
                        tour_price = reader.GetValue(4).ToString(),
                        tour_rate = Convert.ToInt32(reader.GetValue(5)),
                        tour_type = reader.GetValue(6).ToString(),
                        country_code = reader.GetValue(7).ToString(),
                        discription = reader.GetValue(8).ToString(),
                        overview = reader.GetValue(9).ToString(),
                        included = reader.GetValue(10).ToString(),
                        excluded = reader.GetValue(11).ToString(),
                        tour_highlights = reader.GetValue(12).ToString(),
                        tour_information = reader.GetValue(13).ToString(),
                        filename = reader.GetValue(14).ToString()
                    };
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
        public object getSubcountryourData(TourFilter TourFilter)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "getSubcountryourData";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@filter_type", TourFilter.filter_type);
                sqlCmd.Parameters.AddWithValue("@country_type", TourFilter.country_type);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<Tour> Tour_list = new List<Tour>();

                while (reader.Read())
                {
                    Tour = new Tour
                    {
                        tour_code = Convert.ToInt32(reader.GetValue(0)),
                        tour_name = reader.GetValue(1).ToString(),
                        tour_day = reader.GetValue(2).ToString(),
                        tour_night = reader.GetValue(3).ToString(),
                        tour_price = reader.GetValue(4).ToString(),
                        tour_rate = Convert.ToInt32(reader.GetValue(5)),
                        tour_type = reader.GetValue(6).ToString(),
                        country_code = reader.GetValue(7).ToString(),
                        discription = reader.GetValue(8).ToString(),
                        overview = reader.GetValue(9).ToString(),
                        included = reader.GetValue(10).ToString(),
                        excluded = reader.GetValue(11).ToString(),
                        tour_highlights = reader.GetValue(12).ToString(),
                        tour_information = reader.GetValue(13).ToString(),
                        filename = reader.GetValue(14).ToString()
                    };
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
        public object getAllTypeSummary(Tour Tour)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "allTypeSummary";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@tour_type", Tour.tour_type);
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                List<Tour> Tour_list = new List<Tour>();
                while (reader.Read())
                {
                    Tour = new Tour();
                    Tour.tour_code = Convert.ToInt32(reader.GetValue(0));
                    Tour.tour_name = reader.GetValue(1).ToString();
                    Tour.tour_day = reader.GetValue(2).ToString();
                    Tour.tour_night = reader.GetValue(3).ToString();
                    Tour.tour_price = reader.GetValue(4).ToString();
                    Tour.tour_rate = Convert.ToInt32(reader.GetValue(5));
                    Tour.tour_type = reader.GetValue(6).ToString();
                    Tour.country_code = reader.GetValue(7).ToString();
                    Tour.discription = reader.GetValue(8).ToString();
                    Tour.overview = reader.GetValue(9).ToString();
                    Tour.included = reader.GetValue(10).ToString();
                    Tour.excluded = reader.GetValue(11).ToString();
                    Tour.tour_highlights = reader.GetValue(12).ToString();
                    Tour.tour_information = reader.GetValue(13).ToString();
               
                    Tour.filename = reader.GetValue(14).ToString();
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


    }


}