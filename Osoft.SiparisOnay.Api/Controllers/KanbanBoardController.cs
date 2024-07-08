using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class KanbanBoardController : Controller
    {
        private readonly IKanbanBoardRepository _kanbanBoardRepository;
        public KanbanBoardController(IKanbanBoardRepository kanbanBoardRepository)
        {
            _kanbanBoardRepository = kanbanBoardRepository;
        }

        [HttpGet("{us_kod}")]
        public async Task<IActionResult> Get(string us_kod)
        {
            try
            {
                var result = _kanbanBoardRepository.Get(us_kod);
                return Ok(new { statusCode = 200, rowCount = result.Result.Count(), data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(List<kanban_board>? kanbanBoard)
        {
            try
            {
                if (kanbanBoard != null)
                {
                    var modelData = kanbanBoard.First();
                    var resultDelete = _kanbanBoardRepository.Delete(modelData.kullanici_kodu, modelData.srk_no.ToString());

                    foreach (var item in kanbanBoard)
                    {
                        _ = _kanbanBoardRepository.AddAsync(item).Result;
                    }

                    var result = _kanbanBoardRepository.Get(kanbanBoard.First().kullanici_kodu);

                    return Ok(new { statusCode = 200, rowCount = result.Result.Count(), data = result });
                }
                return BadRequest(new { statusCode = 400 });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }



        [HttpDelete("{kartID}")]
        public async Task<IActionResult> Delete(int kartID)
        {
            try
            {
                if (kartID != 0)
                {
                    var result = _kanbanBoardRepository.DeleteAsync(new kanban_board(), kartID);

                    return Ok(new { statusCode = 200, data = result });
                }

                return BadRequest(new { statusCode = 400 });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        [HttpDelete("{srk_no}/{us_kod}")]
        public async Task<IActionResult> DeleteAll(string srk_no, string? us_kod)
        {
            try
            {
                if (us_kod != null)
                {
                    var result = _kanbanBoardRepository.Delete(us_kod, srk_no);

                    return Ok(new { statusCode = 200, data = result });
                }

                return BadRequest(new { statusCode = 400 });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }
    }
}
