using RushTicketSoftware.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.DTO
{
    [Serializable]
    public class PassengerResponse : BaseTicketResponse
    {
        public PassengerData data { get; set; }
    }

    [Serializable]
    public class PassengerData
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public List<Passenger> datas { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public bool? flag { get; set; }

        /// <summary>
        /// 列表总页数
        /// </summary>
        public int? pageTotal { get; set; }
    }
}
