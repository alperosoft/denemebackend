using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelRepository _repository;
        private readonly IMapper _mapper;

        public PersonelController(IPersonelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<IActionResult> GetPersonelAll()
    {
        try
        {
            var modelData = await _repository.GetPersonelAll();
            var result = modelData.Select(hero => _mapper.Map<PersonelDTO>(hero));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 400, error = ex.Message });
        }
    }

    }
}
