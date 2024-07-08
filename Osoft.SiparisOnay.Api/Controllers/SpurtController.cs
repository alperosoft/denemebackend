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

    public class SpurtController: ControllerBase
    {
        private readonly ISpurtRepository _spurtRepository;
        private readonly IMapper _mapper;

        public SpurtController(ISpurtRepository spurtRepository, IMapper mapper)
        {
            _spurtRepository = spurtRepository;
            _mapper = mapper;
        }

        [HttpPost("orguUretim")]
        public async Task<IActionResult> GetOrguUretim(Filter? filter)
        {
            try
            {
                var modelData = await _spurtRepository.GetOrguUretim(filter);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero=> _mapper.Map<SpurtOrguUretimDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
