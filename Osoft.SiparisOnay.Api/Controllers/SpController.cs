using AutoMapper;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Repository.IRepositories;
using System.Text.Json;
using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpController : ControllerBase
    {
        private readonly ISpRepository _repository;
        private readonly IMapper _mapper;

        public SpController(ISpRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpAll(DateTime sp_siptrh, string sp_frm_kod, int ai_srk_no)
        {
            try
            {
                var modelData = await _repository.GetSpAll(sp_siptrh, sp_frm_kod, ai_srk_no);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("sp")]
        public async Task<IActionResult> GetSp(int srk_no, int bcmno, int no1, int no2)
        {
            try
            {
                var modelData = await _repository.GetSp(srk_no, bcmno, no1, no2);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpGet("proje")]
        public async Task<IActionResult> GetSpProjeAll(int srk_no, string frm_kod)
        {
            try
            {
                var modelData = await _repository.GetSpProjeAll(srk_no, frm_kod);
                return Ok(new { statusCode = 200, rowCount = modelData.Count(), data = modelData.Select(hero => _mapper.Map<SpDTO>(hero)) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost("insertsp")]
        public async Task<IActionResult> Insert([FromBody] JsonElement data)
        {
            try
            {
                var model = JsonSerializer.Deserialize<Sp>(data);

                var insertResult = await _repository.AddAsync(model);
                return Ok(new { statusCode = 200 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }

            //try
            //{

            //    var result = JsonSerializer.Deserialize<Sp>(data);

            //    var insert = await _repository.AddAsync((Sp)result);


            //    var rowsAffected = await _repository.InsertSp(data);
            //    return Ok(new { statusCode = 200, rowAffected = rowsAffected, data });
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { statusCode = 400, error = ex.Message });

            //}
        }

        [HttpPut("updatesp")]
        public async Task<IActionResult> UpdateSp([FromBody] JsonElement data)
        {
            try
            {
                var model = JsonSerializer.Deserialize<Sp>(data);
                var result = _repository.UpdateAsync(model).Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Günceleme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }

            //try
            //{
            //    // JSON verisinden güncellenecek sütun adı ve değerini alın
            //    var spPrimnoValue = data.GetProperty("sp_primno").GetInt32();

            //    // Diğer güncellenecek verileri içeren JSON verisini oluşturun
            //    var jsonData = data;

            //    var rowsAffected = await _repository.UpdateSp("sp_primno", Convert.ToInt32(spPrimnoValue), jsonData);
            //    return Ok(new { statusCode = 200, message = true });
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { statusCode = 400, error = ex.Message });
            //}
        }

        [HttpDelete("{sp_primno}")]
        public IActionResult Delete(int sp_primno)
        {
            try
            {
                Sp sp = new();
                var result = _repository.DeleteAsync(sp, sp_primno).Result;
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Silme başarılı" });

                return NotFound(new { statusCode = 404, message = "Hiçbir satır etkilenmedi!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpGet("grp")]
        public async Task<IActionResult> GetSpgrpAll(int srk_no, int bcmno)
        {
            try
            {
                var modelData = await _repository.GetSpgrpAll(srk_no, bcmno);
                var result = modelData.Select(hero => _mapper.Map<SpgrpDTO>(hero));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }


        [HttpGet("next/{sp_srk_no}/{sp_bcmno}/{sp_no2}/{sp_no1}")]
        public async Task<IActionResult> Next(int sp_srk_no, int sp_bcmno, int sp_no2, int sp_no1)
        {
            try
            {
                var stkfResult = await _repository.Next(sp_srk_no, sp_bcmno, sp_no2, sp_no1);

                var resultData = await _repository.GetList(stkfResult);

                return Ok(new { statusCode = 200, data = resultData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpGet("previous/{sp_srk_no}/{sp_bcmno}/{sp_no2}/{sp_no1}")]
        public async Task<IActionResult> Previous(int sp_srk_no, int sp_bcmno, int sp_no2, int sp_no1)
        {
            try
            {
                var result = await _repository.Previous(sp_srk_no, sp_bcmno, sp_no2, sp_no1);

                var resultData = await _repository.GetList(result);

                return Ok(new { statusCode = 200, data = resultData });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { statusCode = 500, message = "Internal Server Error", error = ex.Message });
            }
        }

    }
}
