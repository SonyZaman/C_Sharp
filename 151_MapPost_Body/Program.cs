// 151. HTTP POST and the Request Body
/*
    NEW CONCEPT: app.MapPost() and the Request Body
    
    Until now, we used GET requests. GET requests are for FETCHING data.
    If you want to CREATE data (like registering a new user), you must use a POST request.
    
    Why POST?
    Because POST requests have a "Body". 
    You can't send a massive 50-field JSON object in the URL query string — it's insecure and messy.
    Instead, you place the JSON securely inside the Body of the POST request.
    
    How to read the Body in ASP.NET Core?
    1. Define a C# Class that matches the JSON structure you expect.
    2. Add that Class as a parameter to your MapPost Lambda.
    3. ASP.NET Core will automatically deserialize the incoming JSON Body into your C# object!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Define the class that matches the expected JSON
// ─────────────────────────────────────────────────────────────────────────
public class UserRegistration
{
    public string Username { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// 2. NEW CONCEPT: MapPost + Request Body binding
// ─────────────────────────────────────────────────────────────────────────

// When someone sends a POST request with JSON in the body,
// ASP.NET automatically converts it into the 'newUser' object!
app.MapPost("/users", (UserRegistration newUser) => 
{
    // Normally, here you would save 'newUser' to a SQL Database.
    // For now, we just pretend we saved it.
    
    Console.WriteLine($"[SERVER] New user registered: {newUser.Username} ({newUser.Email})");
    
    
    return Results.Ok(new 
    { 
        Message = "User successfully created!", 
        CreatedUser = newUser 
    });
});

app.Run();

/*
    HOW TO TEST (You can't use a normal Browser for POST requests!):
    
    Browsers only send GET requests when you type a URL.
    To test a POST request, you must use a tool like Postman, Thunder Client, or cURL.
    
    If you open a new terminal, you can run this exact cURL command to simulate it:
    
    curl -X POST http://localhost:5000/users \
         -H "Content-Type: application/json" \
         -d '{"Username": "SonyZaman", "Email": "sony@test.com", "Age": 25}'
         
    The server will grab that JSON string, convert it into the UserRegistration class, 
    print it to the console, and return a success JSON!
*/
