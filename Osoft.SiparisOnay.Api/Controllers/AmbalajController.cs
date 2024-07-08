using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbalajController : ControllerBase
    {
        private readonly IAmbalajRepository _repository;
        private readonly IMapper _mapper;

        public AmbalajController(IAmbalajRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetAmbalajAll(int srk_no)
    {
            try
            {
                var modelData = await _repository.GetAmbalajAll(srk_no);
                var result = modelData.Select(hero => _mapper.Map<AmbalajDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
