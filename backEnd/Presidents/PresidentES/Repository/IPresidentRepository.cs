using President.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PresidentES.Repository
{
    public interface IPresidentRepository
    {
        Task<List<PresidentInfo>> getListOfPresidents(bool orderDescending);
    }
}
