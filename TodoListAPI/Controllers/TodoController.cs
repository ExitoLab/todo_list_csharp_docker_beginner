using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models; // Ensure this matches the namespace in TodoItem.cs
using System.Linq;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static readonly List<TodoItem> TodoItems = new();

        // GET: api/todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return Ok(TodoItems);
        }

        // GET: api/todo/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var todoItem = TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult<TodoItem> Create([FromBody] TodoItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Name))
            {
                return BadRequest("Todo item must have a name.");
            }

            item.Id = TodoItems.Count + 1;
            TodoItems.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TodoItem updatedItem)
        {
            var todoItem = TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound(new { Message = $"Todo item with ID {id} not found." });
            }

            if (updatedItem == null || string.IsNullOrWhiteSpace(updatedItem.Name))
            {
                return BadRequest(new { Message = "Todo item must have a valid name." });
            }

            todoItem.Name = updatedItem.Name;
            todoItem.IsComplete = updatedItem.IsComplete;

            return Ok(new { Message = $"Todo item with ID {id} successfully updated." });
        }


        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todoItem = TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound(new { Message = $"Todo item with ID {id} not found." });
            }

            TodoItems.Remove(todoItem);

            return Ok(new { Message = $"Todo item with ID {id} successfully deleted." });
        }
    }
}
