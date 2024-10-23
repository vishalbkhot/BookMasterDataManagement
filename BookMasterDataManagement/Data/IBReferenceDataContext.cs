using BookMasterDataManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace BookMasterDataManagement.Data
{
    public class IBReferenceDataContext : DbContext
    {
        public IBReferenceDataContext(DbContextOptions<IBReferenceDataContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
