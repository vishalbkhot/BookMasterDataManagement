using BookMasterDataManagement.Model;

namespace BookMasterDataManagement.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int id);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int id);
    }
}
