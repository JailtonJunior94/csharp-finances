using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Finances.Business.Domain.Entities;

namespace Finances.Business.Domain.Interfaces
{
    public interface IFinanceRepository
    {
        Task<Finance> GetByIdAsync(Guid ID);
        Task<Finance> InsertAsync(Finance entity);
        Task<ICollection<Finance>> GetAsync(Finance entity);
    }
}
