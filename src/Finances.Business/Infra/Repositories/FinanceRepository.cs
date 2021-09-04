using System;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Finances.Business.Infra.Queries;
using Finances.Business.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Finances.Business.Domain.Interfaces;

namespace Finances.Business.Infra.Repositories
{
    public class FinanceRepository : BaseRepository, IFinanceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<FinanceRepository> _logger;

        public FinanceRepository(ILogger<FinanceRepository> logger,
                                 IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Task<ICollection<Finance>> GetAsync(Finance entity)
        {
            throw new NotImplementedException();
        }

        public Task<Finance> GetByIdAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Finance> InsertAsync(Finance entity)
        {
            try
            {
                using var connection = GetSqlConnection(_configuration["ConnectionString"]);

                var result = await connection.ExecuteAsync(FinaceQuery.InsertFinance, new
                {
                    id = entity.ID,
                    title = entity.Title,
                    value = entity.Value,
                    type = entity.Type,
                    createdAt = entity.CreatedAt
                });

                _logger.LogInformation($"[{nameof(FinanceRepository)}] [InsertAsync] [Finance registrado com sucesso]");
                return entity;
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(FinanceRepository)}] [InsertAsync] [{exception?.Message ?? exception?.InnerException.Message}]");
                return null;
            }
        }
    }
}
