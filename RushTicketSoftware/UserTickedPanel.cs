using RushTicketSoftware.Common;
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
        public UserTickedPanel()
        {
            InitializeComponent();
        }

        private void UserTickedPanel_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> paramters = new Dictionary<string, string>();
            paramters.Add("pageIndex", "1");
            paramters.Add("pageSize", "10");
            string userInfo = RequestHelper.GetHttpWebResult("https://kyfw.12306.cn/otn/passengers/query", "POST", LoginForm.cookieContainer, Encoding.UTF8, paramters, "https://kyfw.12306.cn/otn/passengers/init");

        }
    }
}
