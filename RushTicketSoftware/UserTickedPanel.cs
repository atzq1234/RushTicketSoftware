using RushTicketSoftware.Common;
using RushTicketSoftware.DTO;
using RushTicketSoftware.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RushTicketSoftware
{
    public partial class UserTickedPanel : Form
    {
        private Dictionary<string, string> cityDic = new Dictionary<string, string>
        {
            { "北京", "BJP"}
            , { "上海", "SHH"}
            , { "安阳", "AYF"}
        };

        public UserTickedPanel()
        {
            InitializeComponent();
        }

        private void UserTickedPanel_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            Dictionary<string, string> paramters = new Dictionary<string, string>();
            paramters.Add("pageIndex", "1");
            paramters.Add("pageSize", "10");
            string userInfo = RequestHelper.GetHttpWebResult("https://kyfw.12306.cn/otn/passengers/query", "POST", LoginForm.cookieContainer, Encoding.UTF8, paramters, "https://kyfw.12306.cn/otn/passengers/init");
            var passengerResponse = JsonHelper.JsonConvertToObject<PassengerResponse>(userInfo);
            if (passengerResponse != null && passengerResponse.data != null && passengerResponse.data.datas != null && passengerResponse.data.datas.Count > 0)
            {
                //foreach (var passenger in passengerResponse.data.datas)
                //{
                //    this.lbPassengers.Items.Add(passenger.passenger_name);
                //}
                this.lbPassengers.DataSource = passengerResponse.data.datas;
                this.lbPassengers.DisplayMember = "passenger_name";
            }
            var stations1 = new List<TrainStation>()
            {
                new TrainStation() { StationName = "北京", StationCode = "BJP"},
                new TrainStation() { StationName = "上海", StationCode = "SHH"},
                new TrainStation() { StationName = "安阳", StationCode = "AYF"},
            };
            var stations2 = new List<TrainStation>()
            {
                new TrainStation() { StationName = "北京", StationCode = "BJP"},
                new TrainStation() { StationName = "上海", StationCode = "SHH"},
                new TrainStation() { StationName = "安阳", StationCode = "AYF"},
            };
            this.cbArriveCity.DataSource = stations1;
            this.cbArriveCity.DisplayMember = "StationName";
            this.cbStartCity.DataSource = stations2;
            this.cbStartCity.DisplayMember = "StationName";
            this.tbStartDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
