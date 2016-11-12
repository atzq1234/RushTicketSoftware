using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.DTO
{
    public class BaseTicketResponse
    {
        /// <summary>
        /// 返回状态码 200正常
        /// </summary>
        public int httpstatus { get; set; }
        
        /// <summary>
        /// 消息
        /// </summary>
        public List<string> messages { get; set; }

        /// <summary>
        /// 状态  true  false
        /// </summary>
        public bool status { get; set; }
    }
}
