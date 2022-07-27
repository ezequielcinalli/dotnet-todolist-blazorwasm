namespace TodoListShared;
public class TodoItem
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public bool IsDone { get; set; }
    public string? Secret { get; set; }
}