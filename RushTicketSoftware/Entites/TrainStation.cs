using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.Entites
{
    [Serializable]
    public class TrainStation
    {
        /// <summary>
        /// 车站名称
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 车站代码
        /// </summary>
        public string StationCode { get; set; }
    }
}
