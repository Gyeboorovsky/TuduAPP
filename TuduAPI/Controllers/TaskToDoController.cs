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
    public class TaskTodoController : Controller
    {
        private readonly PostgreSqlContext _context;
        public TaskTodoController(PostgreSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TaskTodo> GetAllofUser(int userId)
        {
            var allUserTasks = _context.Tasks.Where(t => t.UserId == userId).ToList();
            return allUserTasks;
        }

        [HttpPost]
        //TODO może powinienem dodać też userId jako parametr?
        public ActionResult<TaskTodo> CreateTask(TaskTodo _task)
        {
            _task.TaskCreationDate = DateTime.Now;
            _context.Tasks.Add(_task);
            _context.SaveChanges();
            return _task;
        }

        [HttpPut]
        public IActionResult EditTask([FromBody] TaskTodo _task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(_task);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<TaskTodo> DeleteTask(int id)
        {
            var user = _context.Tasks.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            var entity = _context.Tasks.FirstOrDefault(t => t.Id == id);
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
            return Ok();
        }
    }
}
