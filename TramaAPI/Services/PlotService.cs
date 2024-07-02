using System.Text;
using TramaAPI.Enums;
using TramaAPI.Interfaces;
using TramaAPI.Models;

namespace TramaAPI.Services
{
   
        public class PlotService : IPlotService
        {
            public async Task<byte[]> GeneratePlotAsync(PlotRequest request)
            {
                var csv = new StringBuilder();

                switch (request.plotTypes)
                {
                    case PlotTypes.DailyCollectionSummary:
                        csv = GenerateDailyCollectionSummary(request);
                        break;
                    case PlotTypes.DailyCollectionDetail:
                        csv = GenerateDailyCollectionDetail(request);
                        break;
                    case PlotTypes.DailyCollectionAccountDetail:
                        csv = GenerateDailyCollectionAccountDetail(request);
                        break;
                    default:
                        throw new ArgumentException("Unsupported plot type");
                }

                return Encoding.UTF8.GetBytes(csv.ToString());
            }

            private StringBuilder GenerateDailyCollectionSummary(PlotRequest request)
            {
                var summaries = GetDailyCollectionSummaries(request);
                var csv = new StringBuilder();
                csv.AppendLine("Date,TotalAmount,Transactions");

                foreach (var summary in summaries)
                {
                    csv.AppendLine($"{summary.Date:yyyy-MM-dd},{summary.TotalAmount},{summary.Transactions}");
                }

                return csv;
            }

            private List<DailyCollectionSummary> GetDailyCollectionSummaries(PlotRequest request)
            {
                var summaries = new List<DailyCollectionSummary>();
                for (int i = 0; i < 15; i++)
                {
                    summaries.Add(new DailyCollectionSummary
                    {
                        Date = request.startDate,
                        TotalAmount = new Random().Next(10000, 50000),
                        Transactions = new Random().Next(1, 10)
                    });
                }

                return summaries;
            }

            private StringBuilder GenerateDailyCollectionDetail(PlotRequest request)
            {
                var details = GetDailyCollectionDetails(request);
                var csv = new StringBuilder();
                csv.AppendLine("Date,ProductId,Amount,RequesterUserId");

                foreach (var detail in details)
                {
                    csv.AppendLine($"{detail.Date:yyyy-MM-dd},{detail.ProductId},{detail.Amount},{detail.RequesterUserId}");
                }

                return csv;
            }

            private List<DailyCollectionDetail> GetDailyCollectionDetails(PlotRequest request)
            {
                var details = new List<DailyCollectionDetail>();
                for (int i = 0; i < 15; i++)
                {
                    details.Add(new DailyCollectionDetail
                    {
                        Date = request.startDate.AddDays(i),
                        ProductId = new Random().Next(1, 5),
                        Amount = new Random().Next(1000, 10000),
                        RequesterUserId = new Random().Next(1, 3)
                    });
                }

                return details;
            }

            private StringBuilder GenerateDailyCollectionAccountDetail(PlotRequest request)
            {
                var details = GetDailyCollectionAccountDetails(request);
                var csv = new StringBuilder();
                csv.AppendLine("Date,AccountId,Amount,Description");

                foreach (var detail in details)
                {
                    csv.AppendLine($"{detail.Date:yyyy-MM-dd},{detail.AccountId},{detail.Amount},{detail.Description}");
                }

                return csv;
            }

            private List<DailyCollectionAccountDetail> GetDailyCollectionAccountDetails(PlotRequest request)
            {
                var details = new List<DailyCollectionAccountDetail>();
                for (int i = 0; i < 15; i++)
                {
                    details.Add(new DailyCollectionAccountDetail
                    {
                        Date = request.startDate,
                        AccountId = new Random().Next(1, 10),
                        Amount = new Random().Next(500, 5000),
                        Description = $"Description {i + 1}"
                    });
                }

                return details;
            }
    }
}

