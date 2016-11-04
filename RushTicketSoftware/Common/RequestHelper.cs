using RushTicketSoftware.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RushTicketSoftware.Common
{
    public class RequestHelper
    {
        public static HttpWebResponse GetWebResponse(string url, CookieContainer cookies)
        {
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.KeepAlive = true;
            webRequest.CookieContainer = cookies;
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
            HttpWebResponse httpResp = (HttpWebResponse)webRequest.GetResponse();
            return httpResp;
        }

        public static bool CheckValidatePic(string points, CookieContainer cookies, Encoding charset)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://kyfw.12306.cn/otn/passcodeNew/checkRandCodeAnsyn");
            webRequest.CookieContainer = cookies;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36";
            webRequest.KeepAlive = true;
            webRequest.Accept = "*/*";
            webRequest.Referer = "https://kyfw.12306.cn/otn/login/init";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            webRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            webRequest.Headers.Add("Origin", "https://kyfw.12306.cn");
            //添加参数
            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat("randCode={0}&rand=sjrand", points);
            byte[] data = charset.GetBytes(buffer.ToString());
            webRequest.ContentLength = data.Length;
            using (Stream stream = webRequest.GetRequestStream())  
            {  
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse httpResp = (HttpWebResponse)webRequest.GetResponse();

            Stream respStream = httpResp.GetResponseStream(); 
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            string result = respStreamReader.ReadToEnd();
            return false;
        }

        public static void GetCookie(CookieContainer cookies)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://kyfw.12306.cn/otn/login/init");
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36";
            webRequest.CookieContainer = cookies;
            HttpWebResponse httpResp = (HttpWebResponse)webRequest.GetResponse();
        }
    }
}
