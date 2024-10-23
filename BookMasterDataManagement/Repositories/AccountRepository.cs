using BookMasterDataManagement.Data;
using BookMasterDataManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace BookMasterDataManagement.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IBReferenceDataContext _context;

        public AccountRepository(IBReferenceDataContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync() => await _context.Accounts.Include(a => a.Client).ToListAsync();

        public async Task<Account> GetByIdAsync(int id) => await _context.Accounts.FindAsync(id);

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await GetByIdAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
