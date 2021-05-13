using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquitationAPI.Models
{
    public class Group
    {

        public Group(uint seanceGrpId, DateTime startDate, string monitor)
        {
            SeanceGrpId = seanceGrpId;
            StartDate = startDate;
            Monitor = monitor;
        }

        public uint SeanceGrpId { get; set; }
        public DateTime StartDate { get; set; }
        public string Monitor { get; set; }
    }
}
