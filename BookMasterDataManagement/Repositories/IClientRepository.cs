using BookMasterDataManagement.Model;

namespace BookMasterDataManagement.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}
