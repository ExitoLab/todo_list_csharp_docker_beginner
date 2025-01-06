namespace TodoListAPI.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Default value
        public bool IsComplete { get; set; }
    }
}
