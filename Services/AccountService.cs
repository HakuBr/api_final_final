using APIsprint.Data;
using APIsprint.Models;
using APIsprint.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIsprint.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                .Include(a => a.Person)
                .ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts
                .Include(a => a.Person)
                .FirstOrDefaultAsync(a => a.account_id == id);
        }

        public async Task<Account> CreateAsync(Account account)
        {
            var emailExists = await _context.Accounts
                .AnyAsync(a => a.email == account.email);

            if (emailExists)
                throw new Exception("Email já cadastrado");

            _context.Accounts.Add(account);

            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<bool> UpdateAsync(int id, Account account)
        {
            var existingAccount = await _context.Accounts
                .FirstOrDefaultAsync(a => a.account_id == id);

            if (existingAccount == null)
                return false;

            existingAccount.account_type = account.account_type;
            existingAccount.balance = account.balance;
            existingAccount.credit = account.credit;
            existingAccount.email = account.email;
            existingAccount.pass_word = account.pass_word;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.account_id == id);

            if (account == null)
                return false;

            _context.Accounts.Remove(account);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}