using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GUsermaster
    {
        public int Id { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public string Mobileno { get; set; }
        public string Email { get; set; }
        public int Roleid { get; set; }
        public int? Agencyid { get; set; }
        public int? Active { get; set; }

        public virtual GAgencymaster Agency { get; set; }
        public virtual GRolemaster Role { get; set; }
    }
}
