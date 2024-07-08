using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osoft.SiparisOnay.Core.Models;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace Osoft.SiparisOnay.Api.Controllers
{
    public class CustomController : ControllerBase
    {
        [NonAction]
        public IActionResult GetReturnStatus(object data, string? error)
        {
            ApiStatus<Object> status = new ApiStatus<Object>();
            if (data != null)
            {
                status.tableId = 0;
                status.json = data;
                status.errors = "";
                status.rowCount = ((IEnumerable<object>)data).ToList().Count;
                if (status.rowCount > 0)
                {
                    status.statusCode = 200;
                }
                else
                {
                    status.statusCode = 204;
                }

                return Ok(status);
            }
            else
            {
                status.statusCode = 400;
                status.tableId = 0;
                status.errors = error;
                return BadRequest(status);
            }
        }
        [NonAction]
        public IActionResult PostReturnStatus(int id, string? error)
        {
            ApiStatus<Object> status = new ApiStatus<Object>();
            if (error == null)
            {
                status.statusCode = 200;
                status.tableId = id;
                status.errors = "";
                return Ok(status);
            }
            else
            {
                status.statusCode = 400;
                status.tableId = 0;
                status.errors = error;
                return BadRequest(status);
            }
        }

        [NonAction]
        public IActionResult PutReturnStatus(int id, string error)
        {
            ApiStatus<Object> status = new ApiStatus<Object>();
            if (id > 0)
            {
                status.statusCode = 200;
                status.tableId = id;
                status.errors = "";
                return Ok(status);
            }
            else if (error != null)
            {
                status.statusCode = 400;
                status.tableId = 0;
                status.errors = error;
                return BadRequest(status);
            }
            else
            {
                status.statusCode = 400;
                status.tableId = id;
                status.errors = "Hiçbir satır etkilenmedi!";
                return BadRequest(status);
            }
        }

        [NonAction]
        public IActionResult DeleteReturnStatus(int rowAffect, string error)
        {
            ApiStatus<Object> status = new ApiStatus<Object>();
            if (rowAffect > 0)
            {
                status.statusCode = 200;
                status.tableId = rowAffect;
                status.errors = "";
                return Ok(status);
            }
            else if (error != null)
            {
                status.statusCode = 400;
                status.tableId = 0;
                status.errors = error;
                return BadRequest(status);
            }
            else
            {
                status.statusCode = 400;
                status.tableId = rowAffect;
                status.errors = "Hiçbir satır etkilenmedi!";
                return BadRequest(status);
            }
        }
    }
}