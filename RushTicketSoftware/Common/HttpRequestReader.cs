using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RushTicketSoftware.Common
{
    public class HttpRequestReader
    {
        //网络请求对象
        private HttpWebRequest _httpReq;

        //要请求的URL
        private string _url = string.Empty;

        //http标头DATE信息
        public DateTime HttpHeadDate;

        public string strXML;

        public HttpRequestReader(string url)
        {
            _url = url;
            Uri httpURL = new Uri(url);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
            _httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
        }

        #region 获取请求
        /// <summary>  
        /// 获取url的返回值  
        /// </summary>  
        public string GetInfo()
        {
            string strBuff = "";
            try
            {
                ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
                HttpWebResponse httpResp = (HttpWebResponse)_httpReq.GetResponse();

                DateTime.TryParse(httpResp.Headers.Get("Date"), out HttpHeadDate);
                ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
                ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
                Stream respStream = httpResp.GetResponseStream();
                ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以   
                //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8）   
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                strBuff = respStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                //_logger.Error(string.Format("请求{0}出错:GetInfo", _url), ex);
            }
            return strBuff;
        }

        /// <summary>
        /// 保存验证码图片
        /// </summary>
        /// <returns></returns>
        public Stream GetResponseStream()
        {
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
            HttpWebResponse httpResp = (HttpWebResponse)_httpReq.GetResponse();

            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
            Stream respStream = httpResp.GetResponseStream();
            return respStream;
        }
        #endregion


        #region 序列化
        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetXMLObject<T>()
        {
            strXML = GetInfo();
            if (string.IsNullOrEmpty(strXML))
                return default(T);
            using (StringReader sr = new StringReader(strXML))
            {
                try
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                    T result = (T)xmlSer.Deserialize(sr);
                    return result;
                }
                catch (Exception ex)
                {
                    //_logger.Error(string.Format("反序列化XML出错{0}:GetXMLObject", _url), ex);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetSerializerString<T>(T obj)
        {
            string result = null;
            try
            {
                MemoryStream Stream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(Stream, obj);
                Stream.Position = 0;
                StreamReader sr = new StreamReader(Stream);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                //_logger.Error(string.Format("序列化出错{0}:GetSerializerString", _url), ex);
            }
            return result;
        }
        #endregion
    }
}
