using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VardiyaController : Controller
    {
        private readonly IVardiyaRepository _vardiyaRepository;

        public VardiyaController(IVardiyaRepository vardiyaRepository)
        {
            _vardiyaRepository = vardiyaRepository;
        }

        [HttpGet("{srk_no}")]
        public async Task<IActionResult> GetVardiya(int srk_no)
        {
            try
            {
                var result = await _vardiyaRepository.GetVardiya(srk_no);
                if (result == null)
                {
                    return NoContent();
                }

                return Ok(new { statusCode = 200, rowCount = result.Count(), data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }
    }
}
