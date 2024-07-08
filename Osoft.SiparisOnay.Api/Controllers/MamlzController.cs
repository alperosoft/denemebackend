using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MamlzController : ControllerBase
    {
        private readonly IMamlzRepository _repository;
        private readonly IMapper _mapper;

        public MamlzController(IMamlzRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get-all/{srk_no}")]
        public async Task<IActionResult> GetAll(int srk_no)
        {
            try
            {
                var modelData = await _repository.GetAll(srk_no);
                return Ok(new { statusCode = 200, data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }


        [HttpGet("{param}/{mm_primno}")]
        public async Task<IActionResult> GetRofMamlz(string param, int mm_primno)
        {
            try
            {
                var modelData = await _repository.GetRofMamlz(param, mm_primno);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<MamlzDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetMamlzYardim(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetMamlzYardim(filter);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<MamlzYardimDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMamlz(int an_srk_no, int an_tur, int an_mlz_tur, int an_left, string? as_left_kod, string? as_kod_i, string? as_kod_s, int an_yok)
        {
            try
            {
                var modelData = await _repository.GetMamlz(an_srk_no, an_tur, an_mlz_tur, an_left, as_left_kod, as_kod_i, as_kod_s, an_yok);
                return Ok(new
                {
                    statusCode = 200,
                    rowCount = modelData.Count(),
                    data = modelData
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}