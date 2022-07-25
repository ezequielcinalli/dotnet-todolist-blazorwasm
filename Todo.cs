public class Todo
{
    public Todo(string Title)
    {
        this.Title = Title;
    }

    public Todo(int Id, string Title)
    {
        this.Id = Id;
        this.Title = Title;
    }

    public int? Id { get; set; } = 1;
    public string? Title { get; set; }
    public bool IsDone { get; set; }
}