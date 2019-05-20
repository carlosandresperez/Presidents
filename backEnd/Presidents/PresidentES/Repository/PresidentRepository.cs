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

        public async Task<List<PresidentInfo>> GetListOfPresidents(string orderColumn, bool orderDescending)
        {
            try
            {
                if (string.IsNullOrEmpty(orderColumn))
                {
                    orderColumn = "PresidentName";
                }
                string query = "select * from PresidentInfo order by " + orderColumn + (orderDescending ? " desc" : " asc");
                return await _context.PresidentInfo.FromSql(query).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
