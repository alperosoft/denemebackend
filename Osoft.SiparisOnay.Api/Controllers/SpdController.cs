using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.Text.Json;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpdController : ControllerBase
    {
        private readonly ISpdRepository _repository;
        private readonly IMapper _mapper;

        public SpdController(ISpdRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("insertspd")]
        public async Task<IActionResult> InsertSpd(Spd spd)
        {
            try
            {
                //var model = JsonSerializer.Deserialize<Spd>(data);

                var insertResult = await _repository.AddAsync(spd);

                //buraya tekrar bakılacak...
                if (insertResult >= 0)
                    return Ok(new { statusCode = 200 });

                return NotFound(new { statusCode = 404 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }


        [HttpPut("updatespd")]
        public async Task<IActionResult> UpdateSpd(Spd spd)
        {
            //try
            //{
            //   // string spPrimnoValue = data.GetProperty("spd_primno").GetString();

            //   // var jsonData = data;

            //    //var rowsAffected = await _repository.UpdateSpd("spd_primno", spPrimnoValue, jsonData);
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { statusCode = 400, error = ex.Message });
            //}

            try
            {
                var result = _repository.UpdateAsync(spd).Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Günceleme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }

        }

        [HttpPost("filter")]    
        public async Task<IActionResult> GetSpdFiltre(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetSpdFiltre(filter);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost("spd")]
        public async Task<IActionResult> GetSpd(Filter filter)
        {
            try
            {
                var modelData = await _repository.GetSpd(filter);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("spdtotalsum/{srk_no}/{mm_primno}/{cl_primno}")]

        public async Task<IActionResult> GetSpdTotalSum(int srk_no, int mm_primno, int cl_primno)
        {
            try
            {
                var modelData = await _repository.GetSpdTotalSum(srk_no, mm_primno, cl_primno);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(totalSum => new { total_sum = totalSum }) });

            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("spdprimno")]
        public async Task<IActionResult> GetSpdPrimno(int spd_no1)
        {
            try
            {
                var modelData = await _repository.GetSpdPrimno(spd_no1);
                return Ok(modelData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost("siparisdagilim")]
        public async Task<IActionResult> GetSiparisDagilim(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetSiparisDagilim(filter);
                return Ok(modelData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
