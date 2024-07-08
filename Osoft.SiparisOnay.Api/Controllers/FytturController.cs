using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FytturController : ControllerBase
    {
        private readonly IFytturRepository _repository;
        private readonly IMapper _mapper;

        public FytturController(IFytturRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetFytturAll()
    {
            try
            {
                var modelData = await _repository.GetFytturAll();
                var result = modelData.Select(hero => _mapper.Map<FytturDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
