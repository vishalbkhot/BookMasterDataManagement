namespace BookMasterDataManagement.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
