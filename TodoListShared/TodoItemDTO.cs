namespace TodoListShared;
public class TodoItemDTO
{
    public TodoItemDTO() { }

    public TodoItemDTO(string Title, bool IsDone)
    {
        this.Title = Title;
        this.IsDone = IsDone;
    }

    // public TodoItemDTO(long Id, string Title, bool IsDone)
    // {
    //     this.Id = Id;
    //     this.Title = Title;
    //     this.IsDone = IsDone;
    // }

    public long Id { get; set; }
    public string? Title { get; set; }
    public bool IsDone { get; set; }
}