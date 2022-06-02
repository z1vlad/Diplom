using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Models
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
        }

        public int UserId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Number { get; set; }

        public string FIO()
        {
            return string.Concat(Surname, " ", Name, " ", Patronymic);
        }
        public string FI()
        {
            return string.Concat(Surname, " ", Name);
        }
        public string IO()
        {
            return string.Concat(Name, " ", Patronymic);
        }

        public virtual ICollection<Address> Address { get; set; }
    }
}
