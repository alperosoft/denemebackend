using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.Erp.Core.IRepositories;
using Osoft.SiparisOnay.Core.DTO;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TableIdController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITableIdRepository _repo;
        public TableIdController(ITableIdRepository tableIdRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = tableIdRepository;
        }

        // GET: api/<TableIdController>
        //[HttpGet("{srk_no}/{bcmno}/{yil}/{table_name}")]
        //public async Task<IActionResult> TableId(int srk_no, int bcmno, int yil, string table_name, string? kategori, string? f_set)
        //{
        //    try
        //    {
        //        var modelData = await _repo.GetByTableIdAsync(srk_no, bcmno, yil, table_name, kategori, f_set);
        //        var result = modelData.Select(hero => _mapper.Map<TableIdDTO>(hero).f_id);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { statusCode = 400, error = ex.Message });
        //    }
        //}

        [HttpGet("{srk_no}/{bcmno}/{yil}/{table_name}")]
        public async Task<IActionResult> TableId(int srk_no, int bcmno, int yil, string table_name, [FromQuery] string? kategori, [FromQuery] string? f_set)
        {
            try
            {
               var result = await _repo.GetByTableIdAsync(srk_no, bcmno, yil, table_name, kategori, f_set);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }



        [HttpGet("getspdno2/{spd_no1}")]
        public async Task<IActionResult> GetSpdNo2(int spd_no1)
        {
            try
            {
                var modelData = await _repo.GetSpdNo2(spd_no1);
                var result = modelData.Select(hero => _mapper.Map<TableIdDTO>(hero).f_id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetTlmtPrimno()
        {
            try
            {
                var modelData = await _repo.GetTlmtPrimno();
                var result = modelData.Select(hero => _mapper.Map<TableIdDTO>(hero).f_id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}