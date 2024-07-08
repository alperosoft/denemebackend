using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SirketController : ControllerBase
    {
        private readonly ISirketRepository _repository;

        public SirketController(ISirketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<IActionResult> SirketGet()
        {
            try
            {
                var modelData = await _repository.SirketGet();
                return Ok(new {statusCode = 200, rowCount = modelData.Count(), data = modelData});
            }
            catch(Exception ex)
            {
                return BadRequest(new {statusCode = 400, error=ex.Message});
            }
        }
    }
}
