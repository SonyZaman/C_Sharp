// 165. Nullable Types
/*
    NEW CONCEPT: Nullable Types (?) in APIs
    
    What happens if a user forgets to send their Age in the JSON?
    
    If your class has: `public int Age { get; set; }`
    ASP.NET Core will automatically set it to the default value: 0.
    This can cause bugs! Is the user actually 0 years old, or did they just forget to send it?
    
    To fix this, we use Nullable Types by adding a question mark (`?`).
    `public int? Age { get; set; }`
    Now, if they forget to send it, the value becomes `null` instead of `0`.
    This makes validation much more accurate!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Models (One BAD, One GOOD)
// ─────────────────────────────────────────────────────────────────────────
public class BadUser
{
    public string Name { get; set; }
    public int Age { get; set; } // NO question mark (Defaults to 0)
}

public class GoodUser
{
    public string Name { get; set; }
    public int? Age { get; set; } // WITH question mark (Defaults to null)
}

// ─────────────────────────────────────────────────────────────────────────
// 2. Endpoints
// ─────────────────────────────────────────────────────────────────────────
app.MapPost("/users/bad-nullable", (BadUser newUser) => 
{
    // If the user forgets to send Age, it becomes 0.
    // Our code might think they are just a newborn baby!
    return Results.Ok(new { 
        Message = "Notice how Age became 0, even if you didn't send it!", 
        User = newUser 
    });
});

app.MapPost("/users/good-nullable", (GoodUser newUser) => 
{
    // Because we used int?, we can actually check if it's null!
    if (newUser.Age == null)
    {
        return Results.BadRequest(new { Error = "You forgot to provide your Age!" });
    }

    return Results.Ok(new { 
        Message = "Age provided successfully!", 
        User = newUser 
    });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run`. Notice how we are NOT sending the "Age" in the JSON below.
    
    1. BAD Nullable (Returns Age: 0):
       curl -X POST http://localhost:5000/users/bad-nullable -H "Content-Type: application/json" -d '{"Name": "Sony"}'
       
    2. GOOD Nullable (Correctly detects that Age is missing and gives an Error):
       curl -X POST http://localhost:5000/users/good-nullable -H "Content-Type: application/json" -d '{"Name": "Sony"}'
*/
