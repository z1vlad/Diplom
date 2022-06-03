using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VillageService
    {
        public async Task<IEnumerable<Village>> GetAll()
        {
            using (var db = new vladDBContext())
                return await db.Village.ToListAsync();
        }
        public async Task<Village> GetById(int id)
        {
            using (var db = new vladDBContext())
                return db.Village.FirstOrDefault(v => v.VillageId == id);
        }
        public async Task<IEnumerable<Village>> GetByDistrictId(int id)
        {
            using (var db = new vladDBContext())
                return db.Village.Where(v => v.DistrictId == id).ToList();
        }
    }
}
