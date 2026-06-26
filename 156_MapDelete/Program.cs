// 156. MapDelete (Deleting Data)
/*
    NEW CONCEPT: HTTP DELETE requests
    
    In REST APIs:
    - DELETE = Remove data
    
    A DELETE request usually only requires ONE thing:
    - A Route Parameter (to know WHICH item to delete, e.g., /users/1)
    
    Unlike POST and PUT, DELETE requests almost never have a JSON Body.
    You just tell the server "Delete user 101" and the server does it.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: MapDelete (Route Parameter only)
// ─────────────────────────────────────────────────────────────────────────
app.MapDelete("/users/{id}", (int id) => 
{
    // Normally, here you would connect to a database and write:
    // DELETE FROM Users WHERE Id = {id}
    
    Console.WriteLine($"[SERVER] Received DELETE request for User ID: {id}");
    
    // We return a simulated success response
    return Results.Ok(new 
    { 
        Message = $"User {id} was successfully deleted (Simulated)!" 
    });
});

app.Run();

/*
    HOW TO TEST (run this in a new terminal):
    
    curl -X DELETE http://localhost:5000/users/101
*/
