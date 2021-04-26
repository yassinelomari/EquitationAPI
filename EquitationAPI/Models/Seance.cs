using System;
using System.Collections.Generic;

#nullable disable

namespace EquitationAPI.Models
{
    public partial class Seance
    {
        public uint SeanceId { get; set; }
        public uint SeanceGrpId { get; set; }
        public uint ClientId { get; set; }
        public ushort MonitorId { get; set; }
        public DateTime StartDate { get; set; }
        public byte DurationMinut { get; set; }
        public bool IsDone { get; set; }
        public uint? PaymentId { get; set; }
        public string Comments { get; set; }
    }
}
