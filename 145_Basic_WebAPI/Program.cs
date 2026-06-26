// 145. Basic Web API (ASP.NET Core Minimal API)
/*
    This is the most stripped-down, bare-bones Web API possible.
    We use ASP.NET Core's "Minimal API" style - no controllers, no complexity.
    
    The 3 essential lines that every ASP.NET Core app must have:
    
    1. var builder = WebApplication.CreateBuilder(args);
       → Creates the "factory" that will build our web application.
         This is where you register services (database, auth, etc.) later on.
    
    2. var app = builder.Build();
       → The factory finishes building the actual web application object.
         After this point, we configure how the app handles requests.
    
    3. app.Run();
       → Starts the web server and makes it listen for incoming HTTP requests.
         The app blocks here and runs FOREVER until you press Ctrl+C.
    
    Between Build() and Run() is where we map our API endpoints using:
    
    app.MapGet("/route",    () => ...)  → Handles HTTP GET  requests
    app.MapPost("/route",   () => ...)  → Handles HTTP POST requests
    app.MapPut("/route",    () => ...)  → Handles HTTP PUT  requests
    app.MapDelete("/route", () => ...)  → Handles HTTP DELETE requests
*/

// ─────────────────────────────────────────
// STEP 1: Create the builder (the factory)
// ─────────────────────────────────────────
var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────
// STEP 2: Build the app from the factory
// ─────────────────────────────────────────
var app = builder.Build();

// ─────────────────────────────────────────
// STEP 3: Start the server and run forever
// ─────────────────────────────────────────
app.Run();


