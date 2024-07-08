using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorsRepository _repository;
        private readonly IMapper _mapper;

        public ColorsController(IColorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("gelenrenk")]
        public async Task<IActionResult> GetGelenRenk(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetGelenRenk(filter);
                return Ok(new { statusCode = 200, data = modelData.Select(hero => _mapper.Map<GelenRenkDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost("onayrenk")]
        public async Task<IActionResult> GetOnayRenk(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetOnayRenk(filter);
                return Ok(new { statusCode = 200, data = modelData.Select(hero => _mapper.Map<OnayRenkDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetColorsAll(int srk_no, int bcmno)
        {
            try
            {
                var modelData = await _repository.GetColorsAll(srk_no, bcmno);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<ColorsDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetColorsYardim(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetColorsYardim(filter);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<ColorsDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("color")]
        public async Task<IActionResult> GetColorAll(int srk_no, int bcmno, int tur)
        {
            try
            {
                var modelData = await _repository.GetColorAll(srk_no, bcmno, tur);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<ColorsDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("getcolor")]
        public async Task<IActionResult> GetColor(int srk_no, int cl_primno)
        {
            try
            {
                var modelData = await _repository.GetColor(srk_no, cl_primno);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<ColorsDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
