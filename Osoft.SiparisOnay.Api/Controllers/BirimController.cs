using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirimController : ControllerBase
    {
        private readonly IBirimRepository _repository;
        private readonly IMapper _mapper;

        public BirimController(IBirimRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetBirimAll()
    {
            try
            {
                var modelData = await _repository.GetBirimAll();
                var result = modelData.Select(hero => _mapper.Map<BirimDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
