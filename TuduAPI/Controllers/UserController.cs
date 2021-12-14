using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuduAPI.Data;
using TuduAPI.Models;

namespace TuduAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly PostgreSqlContext _context;
        public UserController(PostgreSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        public User CreateAccount([FromBody] User user)
        {
            user.Role = "user";
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeletePerson(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            var entity = _context.Users.FirstOrDefault(t => t.Id == id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{username}/{password}")]
        public ActionResult<string> GetUserId(string username, string password)
        {

            var user = _context.Users.Where(
                u => u.Username == username && u.Password == password)
                .FirstOrDefault();

            return user.Username;
        }
    }
}
