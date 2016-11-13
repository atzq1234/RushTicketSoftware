using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.Entites
{
    [Serializable]
    public class TrainTicket
    {
        public string buttonTextInfo { get; set; }

        public TrainTicketBase queryLeftNewDTO { get; set; }

        public string secretStr { get; set; }
    }

    /// <summary>
    /// 车票
    /// </summary>
    [Serializable]
    public class TrainTicketBase
    {
        public string arrive_time { get; set; }
        public string canWebBuy { get; set; }
        public int? control_day { get; set; }
        public string control_train_day { get; set; }
        public int? controlled_train_flag { get; set; }
        public string controlled_train_message { get; set; }
        public int? day_difference { get; set; }
        public string end_station_name { get; set; }
        public string end_station_telecode { get; set; }
        public string from_station_name { get; set; }
        public string from_station_no { get; set; }
        public string from_station_telecode { get; set; }
        public string gg_num { get; set; }
        public string gr_num { get; set; }
        public int? is_support_card { get; set; }
        public string lishi { get; set; }
        public int? lishiValue { get; set; }
        public string location_code { get; set; }
        public string qt_num { get; set; }
        public string rw_num { get; set; }
        public string rz_num { get; set; }
        public string sale_time { get; set; }
        public string seat_feature { get; set; }
        public string seat_types { get; set; }
        public string start_station_name { get; set; }
        public string start_station_telecode { get; set; }
        public string start_time { get; set; }
        public string start_train_date { get; set; }
        public string station_train_code { get; set; }
        public string swz_num { get; set; }
        public string to_station_name { get; set; }
        public int? to_station_no { get; set; }
        public string to_station_telecode { get; set; }
        public string train_class_name { get; set; }
        public string train_no { get; set; }
        public string train_seat_feature { get; set; }
        public string tz_num { get; set; }
        public string wz_num { get; set; }
        public string yb_num { get; set; }
        public string yp_ex { get; set; }
        public string yp_info { get; set; }
        public string yw_num { get; set; }
        public string yz_num { get; set; }
        public string ze_num { get; set; }
        public string zy_num { get; set; }
    }
}
