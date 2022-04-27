using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Report.Services;
using Services.Report.Services.RequestModel;

namespace Services.Report.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult MakeReportRequest([FromBody] ReportRequest model)
        {            
            var result = _reportService.ReportRequest(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetOrderReports()
        {
            var result = _reportService.GetLocationReports();
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]/{reportId}")]
        public IActionResult GetOrderReportDetail(Guid reportId)
        {
            var result = _reportService.GetLocationReportDetail(reportId);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
