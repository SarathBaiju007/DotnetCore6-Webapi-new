using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoApp.Webapi.DataAccess;
using TodoApp.Webapi.Models;

namespace TodoApp.Webapi.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _dbContext;

        public TodoController(TodoDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Todos.ToList());
        }

        [HttpPost]
        public IActionResult Add([FromBody] TodoDto todo)
        {
            _dbContext.Todos.Add(new Todo { Id = Guid.NewGuid(), Title = todo.Title });
            _dbContext.SaveChanges();
            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Todo todo)
        {
            todo.UpdatedDate = DateTime.Now;
            _dbContext.Todos.Update(todo);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var todo = _dbContext.Todos.First(todo => todo.Id == id);
            _dbContext.Todos.Remove(todo);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
