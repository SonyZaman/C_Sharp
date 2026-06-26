// 157. Status Codes
/*
    NEW CONCEPT: HTTP Status Codes
    
    Until now, we always returned `Results.Ok()`, which sends a "200 OK" status code.
    But a good REST API must communicate exactly what happened using standard Status Codes!
    
    The most common ones you need to know:
    - 200 OK          (Success: Used for GET, PUT, DELETE)
    - 201 Created     (Success: Used specifically for POST when a new item is created)
    - 400 Bad Request (Error: The client sent invalid data, e.g., missing name)
    - 404 Not Found   (Error: The client asked for an ID that doesn't exist)
    - 500 Server Error(Error: Your C# code crashed)
    
    ASP.NET Core makes this easy via the `Results` class!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

public class User
{
    public string Name { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// 1. Returning 404 (Not Found)
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/users/{id}", (int id) => 
{
    // Let's pretend we only have users 1, 2, and 3
    if (id > 3)
    {
        // ❌ Return 404 Not Found
        return Results.NotFound(new { Error = $"User with ID {id} does not exist in our database." });
    }
    
    // ✅ Return 200 OK
    return Results.Ok(new { Id = id, Name = "Sony" });
});

// ─────────────────────────────────────────────────────────────────────────
// 2. Returning 400 (Bad Request) and 201 (Created)
// ─────────────────────────────────────────────────────────────────────────
app.MapPost("/users", (User newUser) => 
{
    // Validation: Did the user forget to send a name?
    if (string.IsNullOrWhiteSpace(newUser.Name))
    {
        // ❌ Return 400 Bad Request
        return Results.BadRequest(new { Error = "You must provide a Name to create a user!" });
    }
    
    // ✅ Return 201 Created
    // (Notice that Created often expects the URL where the new item can be found, 
    // but we can pass an empty string if we don't have one yet).
    return Results.Created("", new 
    { 
        Message = "User successfully created!",
        Data = newUser
    });
});

app.Run();

/*
    HOW TO TEST:
    
    1. Test 404 Not Found:
       Browser: http://localhost:5000/users/99
       (You will see the 404 JSON error)
       
    2. Test 400 Bad Request (Empty Name):
       curl -X POST http://localhost:5000/users \
            -H "Content-Type: application/json" \
            -d '{"Name": ""}'
            
    3. Test 201 Created (Valid Name):
       curl -X POST http://localhost:5000/users \
            -H "Content-Type: application/json" \
            -d '{"Name": "Sony"}'
*/
