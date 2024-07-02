namespace TramaAPI.Models
{
    public class DailyCollectionAccountDetail
    {
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
