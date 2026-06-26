// 150. Query Parameters (?key=value)
/*
    NEW CONCEPT: Query Strings
    
    Route parameters (project 149) are required parts of the URL path: /users/101
    
    Query Parameters are optional filters added to the END of a URL after a question mark `?`.
    They are commonly used for searching, sorting, and filtering.
    
    Example URL: /search?name=Sony&age=25
    
    How to read them in ASP.NET Core?
    Just add them as parameters to your Lambda function! 
    DO NOT put them in the Route string.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: Parameters in the Lambda but NOT in the Route string!
// ─────────────────────────────────────────────────────────────────────────

// Notice that the route is JUST "/search". 
// But the Lambda expects 'name' and 'age'. 
// ASP.NET Core knows to look in the Query String for them!
app.MapGet("/search", (string name, int? age) => 
{
    // NOTE: 'int? age' is nullable. If the user doesn't provide it, it won't crash!
    
    if (age == null)
    {
        return Results.Ok(new 
        { 
            Message = $"Searching for anyone named {name}...",
            AgeProvided = false
        });
    }
    
    return Results.Ok(new 
    { 
        Message = $"Searching for {name} who is exactly {age} years old.",
        AgeProvided = true
    });
});

app.Run();

/*
    HOW TO TEST:
    1. Run: dotnet run
    2. Open browser:
    
       → http://localhost:5000/search?name=Sony
         (ASP.NET grabs 'Sony'. Because 'age' is missing, it is null)
         
       → http://localhost:5000/search?name=Sony&age=25
         (Use the '&' symbol to chain multiple query parameters together!)
*/
