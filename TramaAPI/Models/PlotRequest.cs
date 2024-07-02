using TramaAPI.Enums;

namespace TramaAPI.Models
{
    public class PlotRequest
    {
        public DateTime startDate { get;  set; }
        public DateTime endDate { get;  set; }
        public PlotTypes plotTypes { get; set; }
    }
}
