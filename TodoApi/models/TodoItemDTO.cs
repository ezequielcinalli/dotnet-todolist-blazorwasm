namespace TodoApi.Models
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public bool IsDone { get; set; }
    }
}