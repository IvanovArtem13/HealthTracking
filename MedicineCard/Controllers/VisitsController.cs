using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineCard.Logger;
using MedicineCard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineCard.Controllers
{
    [Route("visits")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;
        private readonly ILoggerManager _logger;

        public VisitsController(IVisitService visitService, ILoggerManager logger)
        {
            _logger = logger;
            _visitService = visitService;
        }

        [HttpGet("testLogger")]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IActionResult GetAllVisits()
        {
            var visits = _visitService.GetAll();
            return Ok(visits);
        }

        [HttpGet("{id}")]
        public IActionResult GetVisitById(long id)
        {
            var visit = _visitService.GetById(id);
            if (visit == null) return NotFound("Visit not found");
            return Ok(visit);
        }

        [HttpDelete]
        public IActionResult DeleteVisit(long id)
        {
            _visitService.Delete(id);
            return Ok("Visit deleted!");
        }
    }
}
