// 158. Full CRUD Minimal API (In-Memory)
/*
    MILESTONE: Full CRUD API!
    
    We are putting everything together:
    - C = Create (POST)
    - R = Read   (GET)
    - U = Update (PUT)
    - D = Delete (DELETE)
    
    Plus Route Parameters, JSON Bodies, Status Codes, and a static Fake Database!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model & Fake Database
// ─────────────────────────────────────────────────────────────────────────
public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}

public static class Db
{
    public static List<Todo> Todos = new List<Todo>();
    public static int NextId = 1;
}

// ─────────────────────────────────────────────────────────────────────────
// 2. The Endpoints (CRUD)
// ─────────────────────────────────────────────────────────────────────────

// READ ALL (GET)
app.MapGet("/todos", () => 
{
    return Results.Ok(Db.Todos);
});

// READ ONE (GET by ID)
app.MapGet("/todos/{id}", (int id) => 
{
    var todo = Db.Todos.FirstOrDefault(t => t.Id == id);
    
    // Status Code: 404
    if (todo == null) return Results.NotFound(new { Error = "Todo not found" });
    
    return Results.Ok(todo);
});

// CREATE (POST)
app.MapPost("/todos", (Todo newTodo) => 
{
    // Status Code: 400 (Validation)
    if (string.IsNullOrWhiteSpace(newTodo.Title))
        return Results.BadRequest(new { Error = "Title is required" });
        
    newTodo.Id = Db.NextId++;
    Db.Todos.Add(newTodo);
    
    // Status Code: 201 (Created)
    return Results.Created($"/todos/{newTodo.Id}", newTodo);
});

// UPDATE (PUT)
app.MapPut("/todos/{id}", (int id, Todo updatedData) => 
{
    var existingTodo = Db.Todos.FirstOrDefault(t => t.Id == id);
    
    // Status Code: 404
    if (existingTodo == null) return Results.NotFound(new { Error = "Todo not found" });
    
    // Status Code: 400 (Validation)
    if (string.IsNullOrWhiteSpace(updatedData.Title))
        return Results.BadRequest(new { Error = "Title is required" });
        
    // Update data (do NOT change the ID)
    existingTodo.Title = updatedData.Title;
    existingTodo.IsCompleted = updatedData.IsCompleted;
    
    return Results.Ok(existingTodo);
});

// DELETE (DELETE)
app.MapDelete("/todos/{id}", (int id) => 
{
    var existingTodo = Db.Todos.FirstOrDefault(t => t.Id == id);
    
    // Status Code: 404
    if (existingTodo == null) return Results.NotFound(new { Error = "Todo not found" });
    
    Db.Todos.Remove(existingTodo);
    return Results.Ok(new { Message = $"Todo {id} successfully deleted!" });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in a terminal, then open another terminal and try these:
    
    1. GET ALL (Empty at first)
       curl http://localhost:5000/todos
       
    2. CREATE 
       curl -X POST http://localhost:5000/todos -H "Content-Type: application/json" -d '{"Title": "Buy Groceries", "IsCompleted": false}'
       
    3. GET ONE (Check the ID that was created)
       curl http://localhost:5000/todos/1
       
    4. UPDATE 
       curl -X PUT http://localhost:5000/todos/1 -H "Content-Type: application/json" -d '{"Title": "Buy Groceries", "IsCompleted": true}'
       
    5. DELETE
       curl -X DELETE http://localhost:5000/todos/1
*/
