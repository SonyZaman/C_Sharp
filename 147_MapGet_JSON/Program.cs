// 147. Returning JSON from a MapGet Endpoint
/*
    NEW CONCEPT: Returning JSON (instead of plain text)
    
    In project 146, we returned a raw string: "Hello from my Web API!"
    The server sent it as plain text (Content-Type: text/plain).
    
    Real APIs NEVER return plain text. They return JSON.
    
    How to return JSON? It is incredibly simple:
    Instead of returning a string, return a C# OBJECT from the Lambda!
    
    ASP.NET Core automatically:
    1. Detects you returned an object (not a string)
    2. Serializes it into a JSON string using System.Text.Json
    3. Sets the Content-Type header to: application/json
    
    Two ways to return JSON:
    
    WAY 1 - Return an Anonymous Object (quick and simple):
        app.MapGet("/", () => new { Name = "Sony", Age = 25 });
    
    WAY 2 - Use Results.Ok() (professional, explicit):
        app.MapGet("/", () => Results.Ok(new { Name = "Sony", Age = 25 }));
    
    Results.Ok() is preferred because it EXPLICITLY states "return 200 OK status"
    and makes the intent of the code crystal clear.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: Return an anonymous object → ASP.NET auto-converts to JSON!
// ─────────────────────────────────────────────────────────────────────────

// Way 1: Direct anonymous object (ASP.NET Core auto-serializes to JSON)
app.MapGet("/user", () => new { Name = "Sony Zaman", Age = 25, Role = "Developer" });

// Way 2: Explicit Results.Ok() — preferred in professional code
app.MapGet("/product", () => Results.Ok(new { Id = 1, Name = "Laptop", Price = 1200.99 }));

app.Run();

/*
    Notice:
    - The C# object { Name = "Sony" } becomes JSON { "name": "sony" }
    - Property names are automatically camelCased (Name → name)
    - Numbers stay as numbers, strings stay as strings!
    
    WHAT CHANGED from project 146:
    146: () => "Hello from my Web API!"       ← returns plain TEXT
    147: () => new { Name = "Sony", Age = 25 } ← returns JSON automatically!
*/
