using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace travel_api.Models
{
    public class user
    {
        public int user_code { get; set; }
        public string user_name { get; set; }
   
        public string user_image { get; set; }
        public int user_type { get; set; }
        public string email { get; set; }
        public string type_name { get; set; }
        public string mobile_number   { get; set; }

        public bool is_locked { get; set; }

        public bool is_varified { get; set; }
        public string password { get; set; }
        public int TotalRows { get; set; }


    }
    public class login
    {
       
        public string user_name { get; set; }
        public string password { get; set; }

        public string email { get; set; }

        public string mobile_number { get; set; }

        public int code { get; set; }

        public string msg { get; set; }
        public int Usertype_code { get; set; }
        public int User_code { get; set; }







    }
    
    public class CustomerTour
    {
        public string code { get; set; }

        public string Usertype_code { get; set; }

    }

    public class result_sp
    {
        public string code { get; set; }
        public string msg { get; set; }


    }

    public class user_type
    {
        public int Usertype_code { get; set; }
        public string type_name { get; set; }
       

    }

    public class country
    {
        public int country_code { get; set; }
        public string country_name { get; set; }

      


    }
    
    public class dashbord_box
    {
        public int Count { get; set; }
        public string Title { get; set; }
    }

    public class TopFiveMostSellingTourModel
    {
    
        public string tour_name { get; set; }
        public int tour_count { get; set; }
        public int tour_price { get; set; }
        public int tour_day { get; set; }
        public int tour_night { get; set; }
        public int tour_rate { get; set; }


    }
    public class chartDisplay
    {

        public string name { get; set; }

        public int code { get; set; }
        public int value { get; set; }



    }

    public class TopFiveRecentlyAddedTour
    {

        public string tour_name { get; set; }
 
        public int tour_price { get; set; }
        public int tour_day { get; set; }
        public int tour_night { get; set; }
        public int tour_rate { get; set; }


    }
    public class tourbooking
    {
        public int booking_code { get; set; }
        public int user_code { get; set; }
        public int Tour_code { get; set; }
        public int parson { get; set; }
        public string Booking_for_person_name { get; set; }
        public string Booking_for_person_Email { get; set; }
        public string Booking_for_person_Mobile { get; set; }
        public int StatusCode { get; set; }



    }

    public class state
    {
        public int state_code { get; set; }

        public string state_name { get; set; }
        public int country_code { get; set; }
        public string country_name { get; set; }

    }
    public class Coupan
    {
        public int coupan_code { get; set; }

        public string coupan_name { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public int  coupan_amount { get; set; }

        public int coupan_percentage { get; set; }

    }

    public class TourType
    {
        
        public int tourtype_code { get; set; }

        public string tourtype_name { get; set; }
      

    }


    public class statuschange
    {

        public int StatusCode { get; set; }

        public string booking_id { get; set; }
        public int booking_code { get; set; }

        
    }
    public class TourFilter
    {

        public int filter_type { get; set; }
        public int type { get; set; }

        public string country_type { get; set; }

    }

    public class help
    {
        public int id { get; set; }

        public string name { get; set; }


    }

    public class status_help
    {
        public int id { get; set; }

        public string name { get; set; }


    }

    public class TourTypeListWithCount
    {
        public int id { get; set; }

        public string name { get; set; }
        public string tourCount { get; set; }

    }
    public class TourContryListWithCount
    {
        public int id { get; set; }

        public string name { get; set; }
        public string tourCount { get; set; }

    }

   

    public class Tour
    {
        public string tourCount { get; set; }

        public int tour_code { get; set; }
        public string tour_name { get; set; }
        public string tour_day { get; set; }
        public string tour_night { get; set; }
        public string tour_price { get; set; }
        public int tour_rate { get; set; }
        public string tour_type { get; set; }
        public string country_code { get; set; }
        public string discription { get; set; }
        public string overview { get; set; }
        public string included { get; set; }
        public string excluded { get; set; }
        public string tour_highlights { get; set; }
        public string tour_information { get; set; }
       
        //public bool is_varified { get; set; }
        public string booking_id { get; set; }
        public string user_name { get; set; }
        public string booking_code { get; set; }

        public string filename { get; set; }


    
        public string Booking_for_person_name { get; set; }
        public string Booking_for_person_Email { get; set; }
        public string Booking_for_person_Mobile { get; set; }

        public string status { get; set; }
        public string ticketname { get; set; }

        

    }


    public class pera {
        public string SearchColumn { get; set; }
        public string SearchValue { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
    }


}