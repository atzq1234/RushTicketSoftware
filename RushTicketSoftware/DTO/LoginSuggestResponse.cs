using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.DTO
{
    public class LoginSuggestResponse : BaseTicketResponse
    {
        /// <summary>
        /// 验证登录信息对象
        /// </summary>
        public LoginSuggestResponseData data { get; set; }
    }

    public class LoginSuggestResponseData
    {
        /// <summary>
        /// 登录验证结果 Y:成功
        /// </summary>
        public string loginCheck { get; set; }

        /// <summary>
        /// 验证吗验证信息
        /// </summary>
        public string otherMsg { get; set; }
    }
}
