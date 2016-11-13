using RushTicketSoftware.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RushTicketSoftware.DTO
{
    [Serializable]
    public class TrainTicketRespose : BaseTicketResponse
    {
        public List<TrainTicket> data { get; set; }
    }
}
