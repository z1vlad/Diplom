using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AddressService
    {
        private UserService _userService;
        public AddressService()
        {
            _userService = new UserService();
        }
        public async Task<IEnumerable<Address>> GetAll()
        {
            using (var db = new vladDBContext())
                return db.Address.ToList();
        }
        public async Task<Address> GetById(int id)
        {
            using (var db = new vladDBContext())
                return await db.Address.FirstOrDefaultAsync(a => a.AddressId == id);
        }
        public async Task Create(Address address)
        {
            using (var db = new vladDBContext())
            {
                await db.Address.AddAsync(address);
                await db.SaveChangesAsync();
            }
        }
        public async Task Update(Address address)
        {
            using (var db = new vladDBContext())
            {
                db.Address.Update(address);
                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(Address address)
        {
            using (var db = new vladDBContext())
            {
                db.Address.Remove(address);
                await db.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Address>> Search(string number = "", string name = "", int DistrictId = -1, int VillageId = -1)
        {
            using (var db = new vladDBContext())
            {
                var addresses = db.Address.ToList();
                if (number != "")
                {
                    var selectNumber = (await _userService.GetByNumber(number)).UserId;
                    addresses = addresses.Where(a => a.UserId == selectNumber).ToList();
                }
                if (name != "")
                {
                    var selectName = (await _userService.GetByName(name)).Select(u => u.UserId);
                    addresses = addresses.Where(a => selectName.Contains(a.UserId)).ToList();
                }
                if (DistrictId != -1)
                {
                    var district = db.District.Where(d => d.DistrictId == DistrictId).Select(d => d.DistrictId).ToList();
                    addresses = addresses.Where(a => district.Contains(a.DistrictId)).ToList();
                }
                if (VillageId != -1)
                {
                    var village = db.Village.Where(v => v.VillageId == VillageId).Select(v => v.VillageId).ToList();
                    addresses = addresses.Where(a => village.Contains(a.VillageId.Value)).ToList();
                }
                return addresses;
            }
        }
    }
}
