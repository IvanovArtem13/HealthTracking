using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JsonApiSerializer.JsonApi;
using MedicineCard.DTO;
using MedicineCard.Services;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(200, Type=typeof(DocumentRoot<List<UserDto>>))]
        [ProducesResponseType(500, Type=typeof(DocumentRoot<UserDto>))]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [ProducesResponseType(200, Type = typeof(DocumentRoot<List<UserDto>>))]
        [ProducesResponseType(404, Type = typeof(DocumentRoot<List<UserDto>>))]
        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("auth")]
        public IActionResult Auth([Required] AuthRequest request)
        {
            if (request == null) return BadRequest("Bad request!");

            var result = _userService.Auth(request);
            if (result == null)
            {
                return BadRequest("Auth error!");
            }
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            if (userDto == null) return BadRequest("Invalid input params");
            var result = await _userService.Add(userDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(UserDto userDto)
        {
            var result = _userService.Update(userDto);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteUser(long id)
        {
            _userService.Delete(id);
            return Ok("User deleted!");
        }
    }
}
