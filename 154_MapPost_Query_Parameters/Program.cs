// 154. MapPost with Query Parameters
/*
    NEW CONCEPT: Using POST with Query Parameters (?key=value)
    
    You can also combine MapPost (receiving a JSON body) with Query Parameters.
    
    Why would you do this?
    Imagine you are creating a new user (JSON Body), but you want to pass an optional 
    flag like "sendWelcomeEmail=true" in the URL without putting it in the main User database object.
    
    Example URL: POST /users?sendWelcomeEmail=true
    Body: { "Name": "Sony", "Email": "sony@test.com" }
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: Combining Query Parameter (bool? sendWelcomeEmail) with Body (User newUser)
// ─────────────────────────────────────────────────────────────────────────
app.MapPost("/users", (bool? sendWelcomeEmail, User newUser) => 
{
    Console.WriteLine($"[SERVER] Creating user {newUser.Name}");
    
    // Check if the query parameter was provided and is true
    if (sendWelcomeEmail == true)
    {
        Console.WriteLine($"[SERVER] ✉️ Sending welcome email to {newUser.Email}...");
    }
    else
    {
        Console.WriteLine($"[SERVER] 🚫 Skipping welcome email.");
    }
    
    return Results.Ok(new 
    { 
        Message = "User processed successfully!", 
        User = newUser,
        EmailSent = sendWelcomeEmail ?? false
    });
});

app.Run();

/*
    HOW TO TEST (Using cURL in a new terminal):
    
    1. WITHOUT the query parameter:
       curl -X POST http://localhost:5000/users \
            -H "Content-Type: application/json" \
            -d '{"Name": "Sony", "Email": "sony@test.com"}'
            
    2. WITH the query parameter (?sendWelcomeEmail=true):
       curl -X POST "http://localhost:5000/users?sendWelcomeEmail=true" \
            -H "Content-Type: application/json" \
            -d '{"Name": "Sony", "Email": "sony@test.com"}'
            
       (Note: Quotes around the URL are needed in terminal when using ?)
*/
