using BookMasterDataManagement.Model;

namespace BookMasterDataManagement.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
