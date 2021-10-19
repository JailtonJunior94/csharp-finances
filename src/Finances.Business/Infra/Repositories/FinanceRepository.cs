using Dapper;
using System.Linq;
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
        private readonly ILogger<FinanceRepository> _logger;

        public FinanceRepository(ILogger<FinanceRepository> logger,
                                 IConfiguration configuration) : base(configuration["ConnectionString"])
        {
            _logger = logger;
        }

        public async Task<ICollection<Finance>> GetAsync()
        {
            using var connection = _connectionDB;
            var finances = await connection.QueryAsync<Finance>(sql: FinaceQuery.GetFinance);

            return finances.ToList();
        }

        public async Task<Finance> InsertAsync(Finance entity)
        {
            using var connection = _connectionDB;

            await connection.ExecuteAsync(FinaceQuery.InsertFinance, new
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
    }
}
