using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DovizController : ControllerBase
    {
        private readonly IDovizRepository _repository;
        private readonly IMapper _mapper;

        public DovizController(IDovizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetDovizAll()
    {
            try
            {
                var modelData = await _repository.GetDovizAll();
                var result = modelData.Select(hero => _mapper.Map<DovizDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
