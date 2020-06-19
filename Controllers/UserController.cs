using System.Collections.Generic;
using BookShelf.Models;
using BookShelf.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser() =>
          Ok(_userService.Get());

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> GetUser(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {

            _userService.Create(user);

            return CreatedAtRoute(nameof(GetUser), new { ID = user.ID.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.ID);

            return NoContent();
        }
    }
}