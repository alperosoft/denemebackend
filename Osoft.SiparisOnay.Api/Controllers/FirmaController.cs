using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly IFirmaRepository _repository;
        private readonly IMapper _mapper;

        public FirmaController(IFirmaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetFirmaAll(int srk_no, string ktgr_kod, int frm_tur)
        {
            try
            {
                var modelData = await _repository.GetFirmaAll(srk_no, ktgr_kod, frm_tur);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<FirmaDTO>(hero)) });
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
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<FirmaDTO>(hero)) });
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

    }
}
