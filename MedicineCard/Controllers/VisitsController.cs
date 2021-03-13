using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public VisitsController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet("allVisits")]
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

        [HttpDelete("delete")]
        public IActionResult DeleteVisit(long id)
        {
            _visitService.Delete(id);
            return Ok("Visit deleted!");
        }
    }
}
