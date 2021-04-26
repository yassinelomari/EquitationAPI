using System;
using System.Collections.Generic;

#nullable disable

namespace EquitationAPI.Models
{
    public partial class Task
    {
        public uint TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public byte DurationMinut { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime IsDone { get; set; }
        public ushort UserFk { get; set; }
    }
}
