namespace TramaAPI.Models
{
    public class DailyCollectionSummary
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int Transactions { get; set; }
    }
}
