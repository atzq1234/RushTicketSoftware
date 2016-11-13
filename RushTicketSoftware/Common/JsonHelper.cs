using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.Common
{
    public class JsonHelper
    {
        public static T JsonConvertToObject<T>(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
                return default(T);
            try
            {
                var result = JsonConvert.DeserializeObject<T>(strJson);
                return result;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
