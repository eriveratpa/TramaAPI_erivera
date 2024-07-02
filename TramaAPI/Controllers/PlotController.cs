using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TramaAPI.Interfaces;
using TramaAPI.Models;

namespace TramaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotService _plotService;

        public PlotController(IPlotService plotService)
        {
            _plotService = plotService;
        }

        [HttpPost("trigger")]
        public async Task<IActionResult> triggerPlot([FromBody] PlotRequest request)
        {
            var validator = new Validators.PlotRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var csvData = await _plotService.GeneratePlotAsync(request);

            return File(csvData, "text/csv", "plot.csv");
        }

    }
}
