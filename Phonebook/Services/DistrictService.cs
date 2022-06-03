using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DistrictService
    {
        public async Task<IEnumerable<District>> GetAll()
        {
            using (var db = new vladDBContext())
                return await db.District.ToListAsync();
        }
        public async Task<District> GetById(int id)
        {
            using (var db = new vladDBContext())
                return await db.District.FirstOrDefaultAsync(d => d.DistrictId == id);
        }
    }
}
