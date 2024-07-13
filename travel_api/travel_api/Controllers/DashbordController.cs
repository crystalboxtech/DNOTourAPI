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
    public class DashbordController : ApiController
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object get_dashbord_box()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "dashbord_box";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            dashbord_box dashbord_box = null;
            List<dashbord_box> dashbord_box_list = new List<dashbord_box>();
            while (reader.Read())
            {
                dashbord_box = new dashbord_box();
                dashbord_box.Title = reader.GetValue(0).ToString();
                dashbord_box.Count = Convert.ToInt32(reader.GetValue(1));
              

                dashbord_box_list.Add(dashbord_box);
            }
            return dashbord_box_list;
            myConnection.Close();
        }


        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object getTopFiveMostSellingTour()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "getTopFiveMostSellingTour";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            TopFiveMostSellingTourModel TopFiveMostSellingTourModel = null;
            List<TopFiveMostSellingTourModel> TopFiveMostSellingTourModel_list = new List<TopFiveMostSellingTourModel>();
            while (reader.Read())
            {
                TopFiveMostSellingTourModel = new TopFiveMostSellingTourModel();
                TopFiveMostSellingTourModel.tour_name = reader.GetValue(0).ToString();
                TopFiveMostSellingTourModel.tour_count = Convert.ToInt32(reader.GetValue(1));
                TopFiveMostSellingTourModel.tour_price = Convert.ToInt32(reader.GetValue(2));
                TopFiveMostSellingTourModel.tour_day = Convert.ToInt32(reader.GetValue(3));
                TopFiveMostSellingTourModel.tour_night = Convert.ToInt32(reader.GetValue(4));
                TopFiveMostSellingTourModel.tour_rate = Convert.ToInt32(reader.GetValue(5));

                TopFiveMostSellingTourModel_list.Add(TopFiveMostSellingTourModel);
            }
            return TopFiveMostSellingTourModel_list;
            myConnection.Close();
        }

        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object getTopFiveRecentlyAddedTour()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = strcon;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "getTopFiveRecentlyAddedTour";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            TopFiveRecentlyAddedTour TopFiveRecentlyAddedTour = null;
            List<TopFiveRecentlyAddedTour> TopFiveRecentlyAddedTourModel_list = new List<TopFiveRecentlyAddedTour>();
            while (reader.Read())
            {
                TopFiveRecentlyAddedTour = new TopFiveRecentlyAddedTour();
                TopFiveRecentlyAddedTour.tour_name = reader.GetValue(0).ToString();
                TopFiveRecentlyAddedTour.tour_price = Convert.ToInt32(reader.GetValue(1));
                TopFiveRecentlyAddedTour.tour_day = Convert.ToInt32(reader.GetValue(2));
                TopFiveRecentlyAddedTour.tour_night = Convert.ToInt32(reader.GetValue(3));
                TopFiveRecentlyAddedTour.tour_rate = Convert.ToInt32(reader.GetValue(4));

                TopFiveRecentlyAddedTourModel_list.Add(TopFiveRecentlyAddedTour);
            }
            return TopFiveRecentlyAddedTourModel_list;
            myConnection.Close();
        }
        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
        public object getchartDisplay()
        {
            try {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = strcon;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "chartDisplay";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                chartDisplay chartDisplay = null;
                List<chartDisplay> chartDisplay_list = new List<chartDisplay>();
                while (reader.Read())
                {
                    chartDisplay = new chartDisplay();
                    chartDisplay.name = reader.GetValue(0).ToString();
                    chartDisplay.value = Convert.ToInt32(reader.GetValue(2));


                    chartDisplay_list.Add(chartDisplay);
                }
                return chartDisplay_list;
                myConnection.Close();
            }
            catch(Exception ex)
            {
                return ex;
            }
                   }
    }
}