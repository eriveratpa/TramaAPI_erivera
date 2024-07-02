namespace TramaAPI.Models
{
    public class DailyCollectionDetail
    {
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public int RequesterUserId { get; set; }
    }
}
