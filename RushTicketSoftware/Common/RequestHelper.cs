using Newtonsoft.Json;
using RushTicketSoftware.DTO;
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
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public static HttpWebRequest GetNewWebRequest(string url, string method, CookieContainer cookies, string referer = "https://kyfw.12306.cn/otn/login/init")
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.CookieContainer = cookies;
            webRequest.Method = method;
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36";
            webRequest.KeepAlive = true;
            webRequest.Accept = "*/*";
            webRequest.Referer = referer;
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            webRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            webRequest.Headers.Add("Origin", "https://kyfw.12306.cn");
            return webRequest;
        }

        public static bool CheckValidatePic(string points, CookieContainer cookies, Encoding charset)
        {
            try
            {
                var webRequest = GetNewWebRequest("https://kyfw.12306.cn/otn/passcodeNew/checkRandCodeAnsyn", "POST", cookies);
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
                var loginValiPicResponse = JsonConvert.DeserializeObject<LoginValiPicResponse>(result);
                if (loginValiPicResponse != null && loginValiPicResponse.status && loginValiPicResponse.data != null && loginValiPicResponse.data.msg)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                log.Error("CheckValidatePic: 出错", ex);
                return false;

            }
        }

        public static void GetCookie(CookieContainer cookies)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://kyfw.12306.cn/otn/login/init");
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36";
            webRequest.CookieContainer = cookies;
            HttpWebResponse httpResp = (HttpWebResponse)webRequest.GetResponse();
        }

        public static bool DoLogin(string points, string name, string password, CookieContainer cookies, Encoding charset)
        {
            try
            {
                var webRequest = GetNewWebRequest("https://kyfw.12306.cn/otn/login/loginAysnSuggest", "POST", cookies);
                //添加参数
                StringBuilder buffer = new StringBuilder();
                buffer.AppendFormat("loginUserDTO.user_name={0}&userDTO.password={1}&randCode={2}", name, password, points);
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
                var loginSuggestResponse = JsonConvert.DeserializeObject<LoginSuggestResponse>(result);
                if (loginSuggestResponse != null && loginSuggestResponse.status && loginSuggestResponse.data != null && loginSuggestResponse.data.loginCheck == "Y")
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                log.Error("DoLogin: 出错", ex);
                return false;

            }
        }

        public static string GetHttpWebResult(string url, string method, CookieContainer cookies, Encoding charset, Dictionary<string, string> paramaters = null, string referer = "https://kyfw.12306.cn/otn/passengers/init")
        {
            try
            {
                var webRequest = GetNewWebRequest(url, method, cookies, referer);
                //添加参数
                if (paramaters != null && paramaters.Count > 0)
                {
                    StringBuilder buffer = new StringBuilder();
                    string strParams = string.Empty;
                    foreach (var item in paramaters)
                    {
                        strParams += string.Format("{0}={1}&", item.Key, item.Value);
                    }
                    strParams = string.IsNullOrEmpty(strParams) ? string.Empty : strParams.Substring(0, strParams.Length - 1);
                    buffer.AppendFormat(strParams);
                    byte[] data = charset.GetBytes(buffer.ToString());
                    webRequest.ContentLength = data.Length;
                    using (Stream stream = webRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                HttpWebResponse httpResp = (HttpWebResponse)webRequest.GetResponse();

                //Stream respStream = httpResp.GetResponseStream();
                //StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                //string result = respStreamReader.ReadToEnd();
                string result = string.Empty;
                string AcceptEncoding = httpResp.ContentEncoding;
                if (AcceptEncoding.Contains("gzip"))
                {
                    System.IO.Compression.GZipStream responseStream
                    = new System.IO.Compression.GZipStream(httpResp.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                    StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                    result = streamReader.ReadToEnd();
                }
                //else if (AcceptEncoding.Contains("deflate"))
                //{
                //    System.IO.Compression.DeflateStream responseStream
                //    = new System.IO.Compression.DeflateStream(httpResp.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                //    StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                //    result = streamReader.ReadToEnd();
                //}
                else
                {
                    Stream respStream = httpResp.GetResponseStream();
                    StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                    result = respStreamReader.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {
                log.Error("GetHttpWebResult: 出错", ex);
            }
            return null;
        }
    }
}
