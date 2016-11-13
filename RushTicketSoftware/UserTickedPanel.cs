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
            this.dgvTicketList.AutoGenerateColumns = false;
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btTicketSearch_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> paramters = new Dictionary<string, string>();
            paramters.Add("leftTicketDTO.train_date", this.tbStartDate.Text);
            paramters.Add("leftTicketDTO.from_station", "BJP");
            paramters.Add("leftTicketDTO.to_station", "AYF");
            paramters.Add("purpose_codes", "ADULT");
            string ticketJson = RequestHelper.GetHttpWebResult(string.Format("https://kyfw.12306.cn/otn/leftTicket/queryX?leftTicketDTO.train_date=2016-11-14&leftTicketDTO.from_station=BJP&leftTicketDTO.to_station=AYF&purpose_codes=ADULT"), "GET", LoginForm.cookieContainer, Encoding.UTF8, null, "https://kyfw.12306.cn/otn/leftTicket/init");
            var trainTicketRespose = JsonHelper.JsonConvertToObject<TrainTicketRespose>(ticketJson);
            
            if (trainTicketRespose != null && trainTicketRespose.data != null && trainTicketRespose.data.Count > 0)
            {
                var sourceList = new List<TrainTicketBase>();
                foreach (var ticketData in trainTicketRespose.data)
                {
                    if (ticketData.queryLeftNewDTO == null)
                        continue;
                    sourceList.Add(ticketData.queryLeftNewDTO);
                }
                this.dgvTicketList.DataSource = sourceList;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
