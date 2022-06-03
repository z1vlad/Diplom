using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Models
{
    public partial class District
    {
        public District()
        {
            Address = new HashSet<Address>();
            Village = new HashSet<Village>();
        }

        public int DistrictId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Village> Village { get; set; }
    }
}
