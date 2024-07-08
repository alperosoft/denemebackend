using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryExecuteController : Controller
    {
        private readonly IDinamikRaporRepository _dinamikRaporRepository;
        private readonly IDinamikRaporFilterRepository _dinamikRaporFilterRepository;
        public QueryExecuteController(IDinamikRaporRepository dinamikRaporRepository, IDinamikRaporFilterRepository dinamikRaporFilterRepository)
        {
            _dinamikRaporRepository = dinamikRaporRepository;
            _dinamikRaporFilterRepository = dinamikRaporFilterRepository;
        }

        [HttpGet("{raporId}/{whereValues}")]
        public async Task<IActionResult> Query(string  whereValues, int raporId)
        {
            try
            {
                if (whereValues =="a")
                {
                    whereValues = "";
                }
                var result = await _dinamikRaporRepository.QueryGetData(whereValues, raporId);
                if (result.DinamikRaporRows.Count == 0)
                {
                    return NoContent(); // 204 No Content
                }

                return Ok(new { statusCode = 200, data = result }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }


        [HttpGet("pagefilter/{raporId}")]
        public async Task<IActionResult> QueryPag(int raporId)
        {
            try
            {
                var result = _dinamikRaporFilterRepository.QueryGetFilter(raporId);
                if (result==null)
                {
                    return NoContent();
                }

                return Ok(new { statusCode = 200, rowCount = result.Result.Count(), data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message }); 
            }
        }
    }
}
