using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Finances.Business.Domain.Dtos;
using Finances.Business.Domain.Enums;
using Finances.Business.Domain.Dtos.Base;
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
            var finance = await _repository.InsertAsync(new Finance(request.Title, request.Value, request.Type.GetDescription()));
            if (finance is null)
            {
                _logger.LogError($"[{nameof(FinanceService)}] [{nameof(CreateFinanceAsync)}] [{ErrorMessage.RegisterFinanceError}]");
                var financeError = new ApiResponse<object>(false, new NotificationsResponse(ErrorCode.RegisterFinanceError, ErrorMessage.RegisterFinanceError));

                return new ObjectResult(financeError) { StatusCode = StatusCodes.Status400BadRequest };
            }

            _logger.LogInformation($"[{nameof(FinanceService)}] [{nameof(CreateFinanceAsync)}] [Finance cadastrado com sucesso]");
            var response = new FinanceResponse(finance.ID, finance.Title, finance.Value, finance.Type, finance.CreatedAt);

            return new ObjectResult(new ApiResponse<object>(true, response)) { StatusCode = StatusCodes.Status201Created };
        }

        public async Task<ObjectResult> GetFinanceAsync()
        {
            var finances = await _repository.GetAsync();
            if (!finances.Any())
            {
                _logger.LogError($"[{nameof(FinanceService)}] [{nameof(GetFinanceAsync)}] [{ErrorMessage.FinanceNotFound}]");
                var financeNotFound = new ApiResponse<object>(false, new NotificationsResponse(ErrorCode.FinanceNotFound, ErrorMessage.FinanceNotFound));

                return new ObjectResult(financeNotFound) { StatusCode = StatusCodes.Status404NotFound };
            }

            _logger.LogInformation($"[{nameof(FinanceService)}] [{nameof(CreateFinanceAsync)}] [Finance recuperado com sucesso]");
            var response = finances.Select(j => new FinanceResponse(j.ID, j.Title, j.Value, j.Type, j.CreatedAt));

            return new ObjectResult(new ApiResponse<object>(true, response)) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
