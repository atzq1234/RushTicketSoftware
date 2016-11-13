using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.Entites
{
    [Serializable]
    public class Passenger
    {
        public string address { get; set; }
        public DateTime? born_date { get; set; }
        public int? code { get; set; }
        public string country_code { get; set; }
        public string email { get; set; }
        public string first_letter { get; set; }
        public string isUserSelf { get; set; }
        public string mobile_no { get; set; }
        public int? passenger_flag { get; set; }
        public string passenger_id_no { get; set; }
        public int? passenger_id_type_code { get; set; }
        public string passenger_id_type_name { get; set; }
        public string passenger_name { get; set; }
        public int? passenger_type { get; set; }
        public string passenger_type_name { get; set; }
        public string phone_no { get; set; }

        public string postalcode { get; set; }
        public int? recordCount { get; set; }

        public string sex_code { get; set; }
        public string sex_name { get; set; }
        public int? total_times { get; set; }
    }
}
