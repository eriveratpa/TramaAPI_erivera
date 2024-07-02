using TramaAPI.Models;

namespace TramaAPI.Interfaces
{
    public interface IPlotService
    {
        Task<byte[]> GeneratePlotAsync(PlotRequest request);
        //Task<byte[]> UpdateStatus(PlotRequest request);
    }
}
