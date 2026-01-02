using EnterpriseOrderManager.Application.Contracts;
using EnterpriseOrderManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseOrderManager.Infrastructure.Services
{
    public class SqliteCustomerNumberGenerator : ICustomerNumberGenerator
    {
        private const string COUNTER_NAME = "CustomerNumber";
        private readonly AppDbContext _context;

        public SqliteCustomerNumberGenerator(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetNextAsync(CancellationToken ct = default)
        {
            // Important: run in a transaction to avoid race conditions
            await using var transaction = await _context.Database.BeginTransactionAsync(ct);

            // Increment
            int rows = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"UPDATE Counters SET Value = Value + 1 WHERE Name = {COUNTER_NAME};", ct);

            if (rows == 0)
                throw new InvalidOperationException($"Counter '{COUNTER_NAME}' is missing. Seed it first.");

            // Read new value
            int next = await _context.Counters
                .Where(x => x.Name == COUNTER_NAME)
                .Select(x => x.Value)
                .SingleAsync(ct);

            await transaction.CommitAsync(ct);
            return next;
        }
    }
}
