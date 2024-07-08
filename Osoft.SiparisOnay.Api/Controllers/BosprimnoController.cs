using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BosprimnoController : ControllerBase
    {

        private readonly IBosprimnoRepository _bosprimnoRepository;

        public BosprimnoController(IBosprimnoRepository bosprimnoRepository)
        {
            _bosprimnoRepository = bosprimnoRepository;
        }

        [HttpGet("{bos_tablo}/{bos_srk_no}/{bos_bcmno}")]
        public async Task<IActionResult> BosPrimno(string bos_tablo, int bos_srk_no, int bos_bcmno)
        {
            try
            {
                var result = await _bosprimnoRepository.GetPrimNo(bos_tablo, bos_srk_no, bos_bcmno);
                if (result == null)
                    return NotFound(new { statusCode = 404 });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }
    }
}
