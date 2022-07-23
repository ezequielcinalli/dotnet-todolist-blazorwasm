public class Todo
{
    public Todo(string Title)
    {
        this.Title = Title;
    }

    public string? Title { get; set; }
    public bool IsDone { get; set; }
}