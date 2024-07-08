using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbatController : ControllerBase
    {
        private readonly IEbatRepository _repository;
        private readonly IMapper _mapper;

        public EbatController(IEbatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetEbatAll(int srk_no)
    {
            try
            {
                var modelData = await _repository.GetEbatAll(srk_no);
                var result = modelData.Select(hero => _mapper.Map<EbatDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

    }
}
