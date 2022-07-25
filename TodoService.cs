public interface ITodoService{
    List<Todo> getTodos();
    void AddTodo(string title);
    Todo GetTodo(int id);
    void UpdateTodo(Todo todo); 
    void DeleteTodo(Todo todo);
}

public class TodoService : ITodoService{
    List<Todo> items;

    public TodoService(){
        items = new List<Todo>();
        items.Add(new Todo(1,"Item 1",false));
        items.Add(new Todo(2,"Item 4",false));
    }

    public List<Todo> getTodos(){
        return items;
    }

    public void AddTodo(string title){
        items.Add(new Todo(items.Count+1, title, false));
    }

    public Todo GetTodo(int id){
        Todo todo = items.First((item)=>item.Id == id);
        return new Todo(todo.Id, todo.Title, todo.IsDone);
    }

    public void UpdateTodo(Todo todo){
         Todo todoToUpdated = items.First((item)=>item.Id == todo.Id);
         todoToUpdated.Title = todo.Title;
         todoToUpdated.IsDone = todo.IsDone;
    }

    public void DeleteTodo(Todo todo){
        items.RemoveAll(item => item.Id ==todo.Id);
    }
}