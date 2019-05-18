using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using President.Data;
using President.Domain;
using System.Linq;

namespace PresidentES.Repository
{
    public class PresidentRepository : IPresidentRepository
    {
        private readonly PresidentContext _context;

        public PresidentRepository(DbContext context)
        {
            _context = (PresidentContext)context;
        }

        public async Task<List<PresidentInfo>> getListOfPresidents(bool orderDescending)
        {
            if (orderDescending)
            {
                return await _context.PresidentInfo.OrderByDescending(o => o.PresidentName).ToListAsync();
            }
            else
            {
                return await _context.PresidentInfo.OrderBy(o => o.PresidentName).ToListAsync();
            }

        }
    }
}
