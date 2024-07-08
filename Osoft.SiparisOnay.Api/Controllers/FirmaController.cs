using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.Text.Json;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : CustomController
    {
        private readonly IFirmaRepository _repository;
        private readonly IMapper _mapper;

        public FirmaController(IFirmaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetFirmaAll(int srk_no, string? ktgr_kod, int frm_tur)
        {
            try
            {
                var modelData = await _repository.GetFirmaAll(srk_no, ktgr_kod, frm_tur);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("firma")]
        public async Task<IActionResult> GetFirma(int srk_no, string frm_kod)
        {
            try
            {
                var modelData = await _repository.GetFirma(srk_no, frm_kod);
                //return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => (hero)) });
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("firmadist")]
        public async Task<IActionResult> GetFirmaDistAll(int srk_no)
        {
            try
            {
                var modelData = await _repository.GetFirmaDistAll(srk_no);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<FirmaDistDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("firmadist/{srk_no}/{frmd_kod?}")]
        public async Task<IActionResult> GetFirmaDist(int srk_no, string? frmd_kod)
        {
            try
            {
                var modelData = await _repository.GetFirmaDist(srk_no, frmd_kod);
                var mappedData = modelData.Select(hero => _mapper.Map<FirmaDistDTO>(hero)).FirstOrDefault();
                var responseData = mappedData.frmd_ad;

                return Ok(new { data = responseData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("firmadr")]
        public async Task<IActionResult> GetFirmadrAll(int srk_no, string frm_kod)
        {
            try
            {
                var modelData = await _repository.GetFirmadrAll(srk_no, frm_kod);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<FirmadrDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("next/{srk_no}/{frm_kod}")]
        public async Task<IActionResult> Next(int srk_no, string frm_kod)
        {
            try
            {
                var firmaResult = await _repository.Next(srk_no, frm_kod);

                var resultData = await _repository.GetList(firmaResult);

                return Ok(new { statusCode = 200, data = resultData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpGet("previous/{srk_no}/{frm_kod}")]
        public async Task<IActionResult> Previous(int srk_no, string frm_kod)
        {
            try
            {
                var result = await _repository.Previous(srk_no, frm_kod);

                var resultData = await _repository.GetList(result);

                return Ok(new { statusCode = 200, data = resultData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult Post(Firma firma)
        {
            try
            {
                return PostReturnStatus(_repository.AddAsync(firma).Result, null);
            }
            catch (Exception ex)
            {
                return PostReturnStatus(0, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Firma firma)
        {
            try
            {
                return PutReturnStatus(_repository.UpdateAsync(firma).Result, null);
            }
            catch (Exception ex)
            {
                return PutReturnStatus(0, ex.Message);
            }
        }

        [HttpDelete("{srk_no}/{frm_kod}")]
        public IActionResult Delete(int srk_no, string frm_kod)
        {
            try
            {
                return DeleteReturnStatus(_repository.FirmaDelete(srk_no, frm_kod).Result, null);
            }
            catch (Exception ex)
            {
                return DeleteReturnStatus(0, ex.Message);
            }
        }


    }
}
