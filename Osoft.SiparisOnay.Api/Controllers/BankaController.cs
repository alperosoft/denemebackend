using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BankaController : CustomController
    {
        private readonly IMapper _mapper;
        private readonly IBankaRepository _repo;
        public BankaController(IBankaRepository bankaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = bankaRepository;
        }

        // GET: api/<BankaController>
        [HttpGet("{srk_no}")]
        public async Task<IActionResult> BankaAll(int srk_no)
        {
            try
            {
                return GetReturnStatus(await _repo.BankaAll(srk_no), null);
            }
            catch (Exception ex)
            {
                return GetReturnStatus(null, ex.Message);
            }
        }
    }
}