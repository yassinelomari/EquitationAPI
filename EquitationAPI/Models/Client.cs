using System;
using System.Collections.Generic;

#nullable disable

namespace EquitationAPI.Models
{
    public partial class Client
    {
        public uint ClientId { get; set; }
        public string SessionToken { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public string IdentityDoc { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime InscriptionDate { get; set; }
        public DateTime EnsurenceValidity { get; set; }
        public DateTime LicenceValidity { get; set; }
        public string ClientEmail { get; set; }
        public string Passwd { get; set; }
        public string ClientPhone { get; set; }
        public ushort PriceRate { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }
    }
}
