using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineCard.DTO;
using MedicineCard.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicineCard.Controllers
{
    [Route("users")] 
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("auth")]
        public IActionResult Auth(AuthRequest request)
        {
            var result = _userService.Auth(request);
            if (result == null)
            {
                return BadRequest("Error");
            }

            return Ok(result);
        }

    }
}
