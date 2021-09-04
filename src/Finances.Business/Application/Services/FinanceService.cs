using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Finances.Business.Domain.Dtos;
using Finances.Business.Domain.Interfaces;
using Finances.Business.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Finances.Business.Domain.Entities;

namespace Finances.Business.Application.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _repository;
        private readonly ILogger<FinanceService> _logger;

        public FinanceService(IFinanceRepository repository,
                              ILogger<FinanceService> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<ObjectResult> CreateFinanceAsync(FinanceRequest request)
        {
            try
            {
                var finance = await _repository.InsertAsync(new Finance("Internet", 150.15, "Entrada"));
                if (finance is null) return new ObjectResult("Não foi possível inserir registro") { StatusCode = StatusCodes.Status400BadRequest };

                return new ObjectResult(finance) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(FinanceService)}] [ObterEventosTagPorDocumentoAsync] [{exception?.Message ?? exception?.InnerException.Message}]");
                return new ObjectResult("Ocorreu um erro inesperado") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public Task<ObjectResult> GetFinanceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult> GetFinanceByIdAsync(Guid ID)
        {
            throw new NotImplementedException();
        }
    }
}
