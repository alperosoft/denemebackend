using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GnstrController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGnstrRepository _repo;
        public GnstrController(IGnstrRepository gnstrRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = gnstrRepository;
        }

        [HttpGet("{srk_no}/{gs_bcmno}")]
        public async Task<IActionResult> Gnstr(int srk_no,int gs_bcmno)
        {
            try
            {
                var modelData = _mapper.Map<IEnumerable<GnstrDTO>>(await _repo.Gnstr(srk_no, gs_bcmno));
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("gnstr/{srk_no}/{gs_primno}")]
        public async Task<IActionResult> GetGnstr(int srk_no, int gs_primno)
        {
            try
            {
                var testModelData = await _repo.GetByIdAsync(new Gnstr(), gs_primno);
                var modelData = await _repo.GetGnstr(srk_no, gs_primno);
                var mappedData = modelData.Select(hero => _mapper.Map<GnstrDTO>(hero)).FirstOrDefault();
                var responseData = mappedData?.gs_kod;

                return Ok(new { data = responseData });

            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
