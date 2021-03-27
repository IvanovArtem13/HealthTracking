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
