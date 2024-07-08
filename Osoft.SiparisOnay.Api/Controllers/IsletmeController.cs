using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsletmeController : ControllerBase
    {
        private readonly IIsletmeRepository _repository;
        private readonly IMapper _mapper;

        public IsletmeController(IIsletmeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetIsletmeAll()
    {
            try
            {
                var modelData = await _repository.GetIsletmeAll();
                var result = modelData.Select(hero => _mapper.Map<IsletmeDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
