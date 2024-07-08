using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LbController : ControllerBase
    {
        private readonly ILbRepository _repository;
        private readonly IMapper _mapper;

        public LbController(ILbRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLbAll(int srk_no)
        {
            try
            {
                var modelData = await _repository.GetLbAll(srk_no);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<LbDTO>(hero) )});
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
