using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmagrpController : CustomController
    {
        private readonly IFirmagrpRepository _repository;
        private readonly IMapper _mapper;

        public FirmagrpController(IFirmagrpRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET: api/<FirmagrpController>
        [HttpGet("{srk_no}")]
        public async Task<IActionResult> FirmagrpAll(int srk_no)
        {
            try
            {
                return GetReturnStatus(await _repository.FirmagrpAll(srk_no), null);
            }
            catch (Exception ex)
            {
                return GetReturnStatus(null, ex.Message);
            }
        }
    }
}
