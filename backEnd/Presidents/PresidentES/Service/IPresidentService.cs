using President.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PresidentES.Service
{
    public interface IPresidentService
    {
        Task<List<PresidentInfo>> GetListOfPresidents(string orderColumn, bool orderDescending);
    }
}
