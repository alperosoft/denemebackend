using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LfydController : ControllerBase
    {
        private readonly ILfydRepository _repository;
        private readonly IMapper _mapper;

        public LfydController(ILfydRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLfyd(int srk_no, string? frm_kod, string? kod1)
        {
            try
            {
                var modelData = await _repository.GetLfyd(srk_no, frm_kod, kod1);
                return Ok(new
                {
                    statusCode = 200,
                    rowCount = modelData.Count(),
                    data = modelData.Select(hero => _mapper.Map<LfydDTO>(hero))
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
