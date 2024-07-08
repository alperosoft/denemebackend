using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkfdController : ControllerBase
    {
        private readonly IStkfdRepository _repository;
        private readonly IMapper _mapper;

        public StkfdController(IStkfdRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("sevkiyatdagilim")]
        public async Task<IActionResult> GetSevkiyatDagilim(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetSevkiyatDagilim(filter);
                return Ok(modelData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

            [HttpPost("ayliksevkiyatdagilim")]
            public async Task<IActionResult> GetAylikSevkiyatDagilim(Filter? filter)
            {
                try
                {
                    var modelData = await _repository.GetAylikSevkiyatDagilim(filter);
                    return Ok(modelData);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { statusCode = 400, error = ex.Message });
                }
            }

        [HttpPost("gelenurun")]
        public async Task<IActionResult> GetGelenUrun(Filter filter)
        {
            try
            {
                var modelData = await _repository.GetGelenUrun(filter);

                var groupedData = modelData.GroupBy(item => item.depo.dp_ad)
                                          .Select(group => new
                                          {
                                              dp_ad = group.Key,
                                              total_fason_kg = group.Sum(item => item.sfd_fist_no == 11 ? item.cmpt_kg : 0),
                                              total_satin_alim_kg = group.Sum(item => item.sfd_fist_no == 10 ? item.cmpt_kg : 0),
                                          });


                return Ok(new { statusCode = 200, totalKg = groupedData.Sum(item => item.total_fason_kg + item.total_satin_alim_kg), grouped_data = groupedData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        //[HttpPost("satisurun")]
        //public async Task<IActionResult> GetSatisUrun(Filter filter)
        //{
        //    try
        //    {
        //        var modelData = await _repository.GetSatisUrun(filter);


        //        return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<StkfdSatisUrunDTO>(hero)) });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { statusCode = 400, error = ex.Message });
        //    }
        //}
    }
}
