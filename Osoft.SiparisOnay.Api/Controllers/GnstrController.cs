using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GnstrController : CustomController
    {
        private readonly IMapper _mapper;
        private readonly IGnstrRepository _repo;
        public GnstrController(IGnstrRepository gnstrRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = gnstrRepository;
        }

        // GET: api/<GnstrController>/
        [HttpGet("{srk_no}/{gs_bcmno}")]
        public async Task<IActionResult> Gnstr(int srk_no, int gs_bcmno)
        {
            try
            {
                return GetReturnStatus(await _repo.Gnstr(srk_no, gs_bcmno), null);
            }
            catch (Exception ex)
            {
                return GetReturnStatus(null, ex.Message);

            }
        }

        // POST: api/<GnstrController2>/
        [HttpPost("{srk_no}")]
        public async Task<IActionResult> GetGnstr(int srk_no, List<string> gs_primno)
        {
            try
            {
                return GetReturnStatus(await _repo.GetGnstr(srk_no, gs_primno), null);
            }
            catch (Exception ex)
            {
                return GetReturnStatus(null, ex.Message);

            }
        }
    }
}
