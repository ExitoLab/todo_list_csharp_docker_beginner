using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models; // Ensure this matches the namespace in TodoItem.cs

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static readonly List<TodoItem> TodoItems = new();

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return Ok(TodoItems);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem item)
        {
            item.Id = TodoItems.Count + 1;
            TodoItems.Add(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }
    }
}
