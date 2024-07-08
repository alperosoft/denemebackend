using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokPrtController : ControllerBase
    {
        private readonly IStokPrtRepository _stokPrtRepository;

        public StokPrtController(IStokPrtRepository stokPrtRepository)
        {
            _stokPrtRepository = stokPrtRepository;
        }

        [HttpGet("totalsum/{srk_no}/{bcmno}/{yil}/{dp_no}/{mm_primno}/{cl_primno}/{birim}")]
        public async Task<IActionResult> GetTotalSum(int srk_no, int bcmno, int yil, int dp_no, int mm_primno, int cl_primno, string birim)
        {
            try
            {
                var modelData = await _stokPrtRepository.GetTotalSum(srk_no, bcmno, yil, dp_no, mm_primno, cl_primno, birim);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(totalSum => new { total_sum = totalSum }) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }


        [HttpGet("maliyet/{srk_no}/{bcmno}/{yil}/{dp_no}")]
        public async Task<IActionResult> GetMamulGrupMaliyet(int srk_no, int bcmno, int yil, int dp_no)
        {
            try
            {
                var result = await _stokPrtRepository.GetMaliyet(srk_no, bcmno, yil, dp_no);
                if (result == null)
                {
                    return NoContent();
                }

                return Ok(new { statusCode = 200, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }
    }
}
