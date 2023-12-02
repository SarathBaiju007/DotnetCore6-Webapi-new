using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TodoApp.Webapi.DataAccess;

namespace TodoApp.Webapi.Health_Checks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly TodoDbContext _dbContext;

        public DatabaseHealthCheck(TodoDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbContext.Todos.First();
                return Task.FromResult(HealthCheckResult.Healthy("Database server is up"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(ex.Message));
            }
        }
    }
}
