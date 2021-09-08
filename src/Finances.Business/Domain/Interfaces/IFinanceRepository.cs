using System.Threading.Tasks;
using System.Collections.Generic;
using Finances.Business.Domain.Entities;

namespace Finances.Business.Domain.Interfaces
{
    public interface IFinanceRepository
    {
        Task<ICollection<Finance>> GetAsync();
        Task<Finance> InsertAsync(Finance entity);
    }
}
