// 167. Endpoint Separation (Extension Methods)
/*
    NEW CONCEPT: Endpoint Separation
    
    Look at how clean this Program.cs file is! 
    There are NO routes or endpoints defined here.
    
    Instead of writing `app.MapGroup("/users")` right here, 
    we moved all of that code into a separate file called `UserEndpoints.cs`.
    
    Then, we just call `app.MapUserEndpoints()` down below. 
    This is called an "Extension Method" (which we learned in Project 076!).
    
    If we add Products later, we will just add: `app.MapProductEndpoints()`.
    This keeps our Program.cs incredibly clean forever.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// ONE LINE to map ALL user endpoints!
// (Go look at the UserEndpoints.cs file to see where this comes from)
// ─────────────────────────────────────────────────────────────────────────
app.MapUserEndpoints();

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then open a new terminal.
    
    Even though there are no endpoints written in this file, they all still work perfectly!
    
    1. curl http://localhost:5000/users
    2. curl http://localhost:5000/users/1
*/
