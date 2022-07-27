using System.Net.Http.Json;
using System.Threading.Tasks;

public interface ITodoService{
    Task<IEnumerable<Todo>> getTodos();
    Task<Todo> AddTodo(string title);
    Task<Todo> GetTodo(int id);
    Task UpdateTodo(Todo todo); 
    Task DeleteTodo(Todo todo);
}

public class TodoService : ITodoService{
    private HttpClient _httpClient;
    private const string apiUrl = "https://localhost:5001/api/";

    public TodoService(HttpClient httpClient){
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<Todo>> getTodos(){
         return (await _httpClient.GetFromJsonAsync<IEnumerable<Todo>>(apiUrl + "todoitems"))!;
    }

    public async Task<Todo> AddTodo(string title){
        var response = await _httpClient.PostAsJsonAsync<Todo>(apiUrl+ "todoitems", new Todo(0,title,false));
        return (await response.Content.ReadFromJsonAsync<Todo>())!;
    }

    public async Task<Todo> GetTodo(int id){
        return (await _httpClient.GetFromJsonAsync<Todo>(apiUrl + "todoitems/"+id))!;
    }

    public async Task UpdateTodo(Todo todo){
         await _httpClient.PutAsJsonAsync<Todo>(apiUrl + "todoitems/"+todo.Id ,todo);
    }

    public async Task DeleteTodo(Todo todo){
         await _httpClient.DeleteAsync(apiUrl + "todoitems/"+todo.Id);
    }
}