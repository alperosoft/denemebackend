using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkfdtopController : ControllerBase
    {

        private readonly IStkfdTopRepository _stkfdTopRepository;

        public StkfdtopController(IStkfdTopRepository stkfdTopRepository)
        {
            this._stkfdTopRepository = stkfdTopRepository;
        }

        [HttpGet("find/{sfd_srk_no}/{sfd_bcmno}/{sfd_sf_primno}")]
        public async Task<IActionResult> Find(int sfd_srk_no, int sfd_bcmno, int sfd_sf_primno)
        {
            try
            {
                var result = _stkfdTopRepository.Find(sfd_srk_no, sfd_bcmno, sfd_sf_primno).Result;
                if (result != null)
                    return Ok(new { statusCode = 200, data = result });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(stkfdtop stkfdtop)
        {
            try
            {
                var modelData = await _stkfdTopRepository.AddAsync(stkfdtop);
                if (modelData > 0)
                    return Ok(new { statusCode = 200 });

                return NotFound(new { statusCode = 404 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(stkfdtop stkfdtop)
        {
            try
            {
                var result = _stkfdTopRepository.UpdateAsync(stkfdtop).Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Günceleme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpDelete("delete/{sfd_primno}")]
        public IActionResult Delete(int sfd_primno)
        {
            try
            {
                stkfdtop stkfdtop = new();
                var result = _stkfdTopRepository.DeleteAsync(stkfdtop, sfd_primno).Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Silme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }


        [HttpDelete("delete-all/{sf_primno}")]
        public IActionResult DeleteAll(int sf_primno)
        {
            try
            {
                stkfdtop stkfdtop = new();
                var result = _stkfdTopRepository.DeleteAllAsync(stkfdtop, sf_primno, "sfd_sf_primno").Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Silme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }
    }
}
