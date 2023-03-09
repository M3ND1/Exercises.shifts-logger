using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using shifts_logger.Data;
using shifts_logger.Interfaces;
using shifts_logger.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Runtime.Serialization;
using System.Web.Http;
namespace shifts_logger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftLoggerController : ControllerBase
    {
        private readonly IShiftLogsRepository _shiftLogsRepository;

        public ShiftLoggerController(IShiftLogsRepository shiftLogsRepository)
        {
            _shiftLogsRepository = shiftLogsRepository;
        }

        [HttpGet]
        public IActionResult GetShiftLogs()
        {
            var shiftlogs = _shiftLogsRepository.GetShiftLogs();
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(shiftlogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetShiftLog(int id)
        {
            //validation
            if (!_shiftLogsRepository.ShiftLogExists(id))
                return NotFound();
            var shiftlog = _shiftLogsRepository.GetShiftLog(id);
            return Ok(shiftlog);
        }
        [HttpPost]
        public IActionResult InsertShiftLog([FromQuery] ShiftLogs shiftLogs)
        {
            ModelState.Remove("ID");
            shiftLogs.ID = 0; //set up ID to next one
            if (!_shiftLogsRepository.InsertShiftLog(shiftLogs))
                return BadRequest("Something went wrong");
            return Ok("Succesfully Created");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateShiftLog(int id, [FromBody] ShiftLogs shiftLogs)
        {
            shiftLogs.ID = id;
            if (!_shiftLogsRepository.UpdateShiftLog(shiftLogs))
                return NotFound("Shift log not found");
            return Ok("Succesfully Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShiftLog(int id)
        {
            if (!_shiftLogsRepository.DeleteShiftLog(id))
            {
                return NotFound("ID you provided could not be found");
            }
            return Ok("Successfully deleted");
        }
    }
}
