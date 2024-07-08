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

    public class ReceteController : ControllerBase
    {
        private readonly IReceteRepository _repository;
        private readonly IMapper _mapper;

        public ReceteController(IReceteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetRecete(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetRecete(filter);
                return Ok(new { statusCode = 200, totalKg = modelData.Sum(item => item.receteCmpt.cmpt_bakiye_kg), data = modelData.Select(hero => _mapper.Map<ReceteDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
