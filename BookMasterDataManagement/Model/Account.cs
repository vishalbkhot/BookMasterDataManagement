namespace BookMasterDataManagement.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
