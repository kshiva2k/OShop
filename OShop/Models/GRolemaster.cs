using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GRolemaster
    {
        public GRolemaster()
        {
            GUsermaster = new HashSet<GUsermaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<GUsermaster> GUsermaster { get; set; }
    }
}
