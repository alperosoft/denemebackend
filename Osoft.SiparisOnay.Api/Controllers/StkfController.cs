using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkfController : Controller
    {
        private readonly IStkfRepository _stkfRepository;
        public StkfController(IStkfRepository stkfRepository)
        {
            _stkfRepository = stkfRepository;
        }


        [HttpGet("tahsilat")]
        public async Task<IActionResult> GetTahsilat()
        {
            try
            {
                Stkf _stkf = new Stkf();
                _stkf.sf_srk_no = 1;
                _stkf.sf_bcmno = 650;
                _stkf.sf_yil = 2023;
                _stkf.sf_dp_no = 0;
                _stkf.sf_sft_tur = 1;
                _stkf.sf_ba = "B";

                var result = await _stkfRepository.GetTahsilat(_stkf);
                if (!result.Any())
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




        [HttpGet("next/{sf_srk_no}/{sf_bcmno}/{sf_no2}/{sf_fist_no}")]
        public async Task<IActionResult> Next(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no)
        {
            try
            {
                var stkfResult = await _stkfRepository.Next(sf_srk_no, sf_bcmno, sf_no2, sf_fist_no);

                var resultData = await _stkfRepository.GetList(stkfResult);

                return Ok(new { statusCode = 200, data = resultData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpGet("previous/{sf_srk_no}/{sf_bcmno}/{sf_no2}/{sf_fist_no}")]
        public async Task<IActionResult> Previous(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no)
        {
            try
            {
                var stkfResult = await _stkfRepository.Previous(sf_srk_no, sf_bcmno, sf_no2, sf_fist_no);

                var resultData = await _stkfRepository.GetList(stkfResult);

                return Ok(new { statusCode = 200, data = resultData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }


        [HttpGet("find/{sf_srk_no}/{sf_bcmno}/{sf_no2}/{sf_fist_no}")]
        public IActionResult Find(int sf_srk_no, int sf_bcmno, int sf_no2, int sf_fist_no)
        {
            try
            {
                var result = _stkfRepository.Find(sf_srk_no, sf_bcmno, sf_no2, sf_fist_no).Result;
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
        public IActionResult Post(Stkf stkf)
        {
            try
            {
                var postResult = _stkfRepository.AddAsync(stkf).Result;
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(Stkf stkf)
        {
            try
            {
                var result = _stkfRepository.UpdateAsync(stkf).Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Günceleme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpDelete("{sf_primno}")]
        public IActionResult Delete(int sf_primno)
        {
            try
            {
                Stkf stkf = new();
                var result = _stkfRepository.DeleteAsync(stkf, sf_primno).Result;
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
