using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpkategController : ControllerBase
    {
        private readonly ISpkategRepository _repository;
        private readonly IMapper _mapper;

        public SpkategController(ISpkategRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetSpkategAll(int srk_no)
    {
            try
            {
                var modelData = await _repository.GetSpkategAll(srk_no);
                var result = modelData.Select(hero => _mapper.Map<SpkategDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
