using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Finances.Business.Domain.Dtos;

namespace Finances.Business.Application.Interfaces
{
    public interface IFinanceService
    {
        Task<ObjectResult> GetFinanceAsync();
        Task<ObjectResult> GetFinanceByIdAsync(Guid ID);
        Task<ObjectResult> CreateFinanceAsync(FinanceRequest request);
    }
}
