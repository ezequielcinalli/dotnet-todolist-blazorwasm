public class Todo
{
    public Todo(int Id, string Title, bool IsDone)
    {
        this.Id = Id;
        this.Title = Title;
        this.IsDone = IsDone;
    }

    public int Id { get; set; } = 1;
    public string Title { get; set; }
    public bool IsDone { get; set; }
}