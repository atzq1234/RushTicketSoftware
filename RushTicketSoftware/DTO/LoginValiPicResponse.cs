using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.DTO
{
    public class LoginValiPicResponse : BaseTicketResponse
    {
        /// <summary>
        /// 验证信息对象
        /// </summary>
        public LoginValiPicResponseData data { get; set; }
    }

    public class LoginValiPicResponseData
    {
        /// <summary>
        /// 验证码验证信息
        /// </summary>
        public bool msg { get; set; }

        /// <summary>
        /// 验证吗验证结果
        /// </summary>
        public string result { get; set; }
    }

}
