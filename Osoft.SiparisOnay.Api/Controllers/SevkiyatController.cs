using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SevkiyatController : ControllerBase
    {
        private readonly ISevkiyatRepository _repository;
        private readonly IMapper _mapper;

        public SevkiyatController(ISevkiyatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetSevkiyat(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetSevkiyat(filter);

                var groupedData = modelData.GroupBy(item => item.spkategCmpt.cmpt_text)
                                 .Select(group => new
                                 {
                                     cmpt_text = group.Key,
                                     total_cmpt_bmkt_kg = group.Sum(item => item.spkategCmpt.cmpt_bmkt_kg),
                                     total_cmpt_mkt_kg = group.Sum(item => item.spkategCmpt.cmpt_mkt_kg),
                                 });


                return Ok(new { statusCode = 200, totalNetKg = modelData.Sum(item => item.spkategCmpt.cmpt_mkt_kg), grouped_data = groupedData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
