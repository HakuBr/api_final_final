using APIsprint.Data;
using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIsprint.Services
{
    public class FinanceOperationService : IFinanceOperationService
    {
        private readonly AppDbContext _context;

        public FinanceOperationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FinanceOperation>> GetAllAsync()
        {
            return await _context.FinanceOperations
                .Include(f => f.Account)
                .ToListAsync();
        }

        public async Task DepositAsync(FinanceOperation operation)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.account_id == operation.account_id);

            if (account == null)
                throw new Exception("Conta não encontrada");

            if (operation.transation_value <= 0)
                throw new Exception("Valor inválido");

            account.balance += operation.transation_value;

            operation.created_at = DateTime.Now;

            _context.FinanceOperations.Add(operation);

            await _context.SaveChangesAsync();
        }

        public async Task WithdrawAsync(FinanceOperation operation)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.account_id == operation.account_id);

            if (account == null)
                throw new Exception("Conta não encontrada");

            if (account.balance < operation.transation_value)
                throw new Exception("Saldo insuficiente");

            account.balance -= operation.transation_value;

            operation.created_at = DateTime.Now;

            _context.FinanceOperations.Add(operation);

            await _context.SaveChangesAsync();
        }
    }
}   