using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Finances.Business.Domain.Dtos;
using Finances.Business.Domain.Entities;
using Finances.Business.Domain.Interfaces;
using Finances.Business.Shared.Extensions;
using Finances.Business.Application.Interfaces;

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
                var finance = await _repository.InsertAsync(new Finance(request.Title, request.Value, request.Type.GetDescription()));
                if (finance is null) return new ObjectResult(new MessageResponse("Não foi possível inserir registro")) { StatusCode = StatusCodes.Status400BadRequest };

                var response = new FinanceResponse(finance.ID, finance.Title, finance.Value, finance.Type, finance.CreatedAt);
                return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(FinanceService)}] [CreateFinanceAsync] [{exception?.Message ?? exception?.InnerException.Message}]");
                return new ObjectResult(new MessageResponse("Ocorreu um erro inesperado")) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        public async Task<ObjectResult> GetFinanceAsync()
        {
            try
            {
                var finances = await _repository.GetAsync();
                if (!finances.Any()) return new ObjectResult(new MessageResponse("Não foi encontrado nenhum registro")) { StatusCode = StatusCodes.Status404NotFound };

                var response = finances.Select(j => new FinanceResponse(j.ID, j.Title, j.Value, j.Type, j.CreatedAt));
                return new ObjectResult(response) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(FinanceService)}] [GetFinanceAsync] [{exception?.Message ?? exception?.InnerException.Message}]");
                return new ObjectResult(new MessageResponse("Ocorreu um erro inesperado")) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
