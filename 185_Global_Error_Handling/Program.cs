// 185. Global Error Handling
/*
    NEW CONCEPT: Exception Handling Middleware
    
    When your API crashes (e.g. dividing by zero, or database goes offline),
    .NET by default returns an ugly HTML page with the stack trace.
    
    APIs should NEVER return HTML! They should always return JSON.
    
    Instead of wrapping every single endpoint in a `try-catch` block (which is exhausting),
    we use a Global Exception Handler (`app.UseExceptionHandler()`).
    
    This acts as a safety net at the very top of your app. If any endpoint crashes,
    this net catches the error and returns a beautiful JSON `ProblemDetails` response!
*/

using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. The Global Error Handler (The Safety Net!)
// ─────────────────────────────────────────────────────────────────────────
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        // 1. Get the actual error that caused the crash
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        var error = exceptionFeature?.Error;

        // 2. Set the status code to 500 (Internal Server Error)
        context.Response.StatusCode = 500;

        // 3. Return a clean, professional JSON response using Results.Problem()
        // In a real app, you might hide `error.Message` from the user so you don't leak secrets!
        await Results.Problem(
            title: "An unexpected error occurred!",
            detail: error?.Message,
            statusCode: 500
        ).ExecuteAsync(context);
    });
});

// ─────────────────────────────────────────────────────────────────────────
// 2. Endpoints (Let's make them crash!)
// ─────────────────────────────────────────────────────────────────────────

app.MapGet("/", () => "Welcome to the API! Try /crash or /db-crash to see errors.");

// Endpoint 1: Simulating a math crash
app.MapGet("/crash", () =>
{
    int x = 10;
    int y = 0;
    return x / y; // 💥 BOOM! DivideByZeroException
});

// Endpoint 2: Simulating a database crash
app.MapGet("/db-crash", () =>
{
    // Let's pretend the database failed to connect
    throw new Exception("Database connection timeout. Cannot reach SQL Server!"); // 💥 BOOM! Custom Exception
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. THE MATH CRASH:
       curl http://localhost:5000/crash
       ✅ See how it returns a clean JSON with "Attempted to divide by zero" instead of HTML?
       
    2. THE DATABASE CRASH:
       curl http://localhost:5000/db-crash
       ✅ See how it returns a clean JSON with "Database connection timeout" instead of HTML?
       
    KEY TAKEAWAY:
    - Never write `try-catch` in every single endpoint just to return 500 errors.
    - Use `app.UseExceptionHandler()` to catch everything globally in one place!
*/
