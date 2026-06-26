// 146. First MapGet Endpoint (Plain Text Response)
/*
    NEW CONCEPT: app.MapGet()
    
    In project 145, we only had app.Run(). The server started but had NO routes.
    If you visited http://localhost:5000/, the server would return 404 Not Found.
    
    Now we add ONE new line between Build() and Run():
    
        app.MapGet("/route", handler);
    
    This tells the server:
    "When a client sends a GET request to /route, call the handler and return the result."
    
    The handler is a Lambda Expression (we learned this in project 115!).
    It runs every time that URL is requested.
    
    For now, the handler returns a plain string.
    In the next project (147), we will upgrade it to return JSON.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────
// NEW CONCEPT: MapGet(route, handler)
// The only difference from project 145 is this one line!
// ─────────────────────────────────────────────────────
app.MapGet("/", () => "Hello from my Web API!");

app.Run();

/*  
    What happens internally:
    Client ──── GET / ────▶  ASP.NET Core  ──── runs the Lambda ────▶  returns string
*/
