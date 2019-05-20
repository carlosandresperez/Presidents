using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using President.Data;
using President.Domain;
using PresidentES.Repository;

namespace PresidentES.Service
{
    public class PresidentService : IPresidentService
    {
        private readonly IPresidentRepository _repository;

        public PresidentService(PresidentContext context)
        {
            _repository = new PresidentRepository(context);
        }

        public async Task<List<PresidentInfo>> GetListOfPresidents(string orderColumn, bool orderDescending)
        {
            return await _repository.GetListOfPresidents(orderColumn, orderDescending);
        }
    }
}
