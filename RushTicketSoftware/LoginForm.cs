using RushTicketSoftware.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RushTicketSoftware
{
    public partial class LoginForm : Form
    {
        private static HttpRequestReader _webReader;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _webReader = new HttpRequestReader("https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=login&rand=sjrand&0.5294291462477324");
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string name = this.tbName.Text;
            string password = this.tbPassword.Text;
            MessageBox.Show(string.Format("账号：{0} 密码：{1}", name, password));
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btValiPic_Click(object sender, EventArgs e)
        {
            var picStream = _webReader.GetResponseStream();
            Bitmap sourcebm = new Bitmap(picStream);//初始化Bitmap图片
            this.pictureBox1.Image = sourcebm;
        }
    }
}
