// 155. MapPut (Updating Data)
/*
    NEW CONCEPT: HTTP PUT requests
    
    In REST APIs:
    - GET   = Read data
    - POST  = Create data
    - PUT   = Update data
    
    A PUT request requires TWO things to work properly:
    1. A Route Parameter (to know WHICH item to update, e.g., /users/1)
    2. A JSON Body (to know the NEW DATA to replace it with)
    
    (Note: In this simple example, we don't use a fake database yet. 
     We just simulate receiving the PUT request.)
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: MapPut (Route Parameter + Request Body)
// ─────────────────────────────────────────────────────────────────────────
app.MapPut("/users/{id}", (int id, User updatedUserData) => 
{
    // Normally, here you would find the user with 'id' in the database,
    // and replace their data with 'updatedUserData'.
    
    Console.WriteLine($"[SERVER] Received PUT request to update User ID: {id}");
    Console.WriteLine($"[SERVER] New Name: {updatedUserData.Name}");
    Console.WriteLine($"[SERVER] New Email: {updatedUserData.Email}");
    
    // We return a simulated success response
    return Results.Ok(new 
    { 
        Message = $"User {id} was successfully updated (Simulated)!", 
        UpdatedData = updatedUserData 
    });
});

app.Run();

/*
    HOW TO TEST (run this in a new terminal):
    
    curl -X PUT http://localhost:5000/users/101 \
         -H "Content-Type: application/json" \
         -d '{"Name": "Sony Zaman", "Email": "sony_updated@test.com"}'
*/
