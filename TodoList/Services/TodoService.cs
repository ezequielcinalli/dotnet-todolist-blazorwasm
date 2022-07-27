using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoListShared;

public interface ITodoService
{
    Task<IEnumerable<TodoItemDTO>> getTodos();
    Task<TodoItemDTO> AddTodo(string title);
    Task<TodoItemDTO> GetTodo(int id);
    Task UpdateTodo(TodoItemDTO todo);
    Task DeleteTodo(TodoItemDTO todo);
}

public class TodoService : ITodoService
{
    private HttpClient _httpClient;
    private const string apiUrl = "https://localhost:5001/api/";

    public TodoService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<TodoItemDTO>> getTodos()
    {
        return (await _httpClient.GetFromJsonAsync<IEnumerable<TodoItemDTO>>(apiUrl + "todoitems"))!;
    }

    public async Task<TodoItemDTO> AddTodo(string title)
    {
        var response = await _httpClient.PostAsJsonAsync<TodoItemDTO>(apiUrl + "todoitems", new TodoItemDTO(title, false));
        return (await response.Content.ReadFromJsonAsync<TodoItemDTO>())!;
    }

    public async Task<TodoItemDTO> GetTodo(int id)
    {
        return (await _httpClient.GetFromJsonAsync<TodoItemDTO>(apiUrl + "todoitems/" + id))!;
    }

    public async Task UpdateTodo(TodoItemDTO todo)
    {
        await _httpClient.PutAsJsonAsync<TodoItemDTO>(apiUrl + "todoitems/" + todo.Id, todo);
    }

    public async Task DeleteTodo(TodoItemDTO todo)
    {
        await _httpClient.DeleteAsync(apiUrl + "todoitems/" + todo.Id);
    }
}