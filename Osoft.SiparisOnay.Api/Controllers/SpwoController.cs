using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SpwoController : ControllerBase
    {
        private readonly ISpwoRepository _spwodRepository;
        private readonly IMapper _mapper;

        public SpwoController(ISpwoRepository spwodRepository, IMapper mapper)
        {
            _spwodRepository = spwodRepository;
            _mapper = mapper;
        }

        [HttpPost("uretim")]
        public async Task<IActionResult> GetUretim(Filter? filter)
        {
            try
            {
                var modelData = await _spwodRepository.GetUretim(filter);

                return Ok(new { statusCode = 200,totalKg = modelData.Sum(item=>item.cmpt_mkt_kg), data = modelData.Select(hero => _mapper.Map<SpwoUretimDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
