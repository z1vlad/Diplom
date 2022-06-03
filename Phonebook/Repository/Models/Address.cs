using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int DistrictId { get; set; }
        public int? VillageId { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Entrance { get; set; }
        public string Apartment { get; set; }

        public virtual District District { get; set; }
        public virtual User User { get; set; }
        public virtual Village Village { get; set; }
        [NotMapped]
        public string DistrictStr
        {
            get
            {
                using (var db = new vladDBContext())
                {
                    return db.District.FirstOrDefault(d => d.DistrictId == DistrictId).Name;
                }
            }
        }
        [NotMapped]
        public string VillageStr
        {
            get
            {
                using (var db = new vladDBContext())
                {
                    var villageStr = db.Village.Where(v => v.VillageId == VillageId.Value).FirstOrDefault();
                    if (villageStr != null)
                        return villageStr.Name;
                    return "";
                }
            }
        }
        [NotMapped]
        public string UserStr
        {
            get
            {
                using (var db = new vladDBContext())
                {
                    var user = db.User.FirstOrDefault(u => u.UserId == UserId);
                    return $"{user.Surname} {user.Name} {user.Patronymic}";
                }
            }
        }
        [NotMapped]
        public string UserNumber
        {
            get
            {
                using (var db = new vladDBContext())
                {
                    return db.User.FirstOrDefault(u => u.UserId == UserId).Number;
                }
            }
        }
    }
}
