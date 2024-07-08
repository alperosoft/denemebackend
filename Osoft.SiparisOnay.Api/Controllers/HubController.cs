using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {

        private readonly IHubRepository _hubRepository;

        public HubController(IHubRepository hubRepository)
        {
            _hubRepository = hubRepository;
        }

        public class KillJobBody
        {
            public string jobName { get; set; }
        }


        [HttpPost("startjob")]
        public IActionResult StartJob(Filter? filter)
        {
            try
            {
                RecurringJob.AddOrUpdate($"UserSpecificJob_{filter.filterValue21}", () => _hubRepository.RunUserSpecificJob(filter), "*/5 * * * *");
                RecurringJob.TriggerJob($"UserSpecificJob_{filter.filterValue21}");
                return Ok(new { statusCode = 200, message = $"Job successfully started UserSpecificJob_{filter.filterValue21}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost("killjob")]
        public IActionResult KillJob(Filter? filter)
        {
            try
            {
                RecurringJob.RemoveIfExists(filter.filterValue22);
                return Ok(new { statusCode = 200, message = $"Job {filter.filterValue22} successfully killed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }


    }
}
