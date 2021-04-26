using System;
using System.Collections.Generic;

#nullable disable

namespace EquitationAPI.Models
{
    public partial class User
    {
        public ushort UserId { get; set; }
        public string SessionToken { get; set; }
        public string UserEmail { get; set; }
        public string UserPasswd { get; set; }
        public byte? AdminLevel { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool? IsActive { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string Description { get; set; }
        public string UserType { get; set; }
        public string Userphoto { get; set; }
        public DateTime ContractDate { get; set; }
        public string UserPhone { get; set; }
        public string DisplayColor { get; set; }
    }
}
