using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private static List<Todo> _todos = new();
    private static int _nextId = 1;

    public class CreateTodoRequest
{
    public string Name { get; set; } = "";
}

    [HttpPost]
    public IActionResult Create(CreateTodoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("タイトルは必須");

        var todo = new Todo
        {
            Id = _nextId++,
            Name = request.Name,
            IsCompleted = false
        };

        _todos.Add(todo);

        return Ok(todo);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_todos);
    }
}