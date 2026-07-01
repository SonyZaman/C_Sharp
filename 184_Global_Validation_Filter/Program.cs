// 184. Global Validation Filter (IEndpointFilter)
/*
    NEW CONCEPT: Endpoint Filters
    
    In Projects 181-183, we kept writing this code inside EVERY POST and PUT endpoint:
    
        if (!MiniValidator.TryValidate(input, out var errors))
            return Results.ValidationProblem(errors);
    
    If you have 10 endpoints, you repeat this 10 times. That is annoying!
    
    An Endpoint Filter is like a security guard at the gate.
    Before ANY request reaches your endpoint code, the filter checks the data first.
    If the data is bad, the filter rejects it. Your endpoint never even runs!
    
    HOW IT WORKS:
    
    Without Filter:
    Request → Endpoint (validates manually) → Response
    
    With Filter:
    Request → 🔒 FILTER (validates automatically) → Endpoint (clean data!) → Response
*/

using System.ComponentModel.DataAnnotations;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Endpoints — Notice: NO MiniValidator.TryValidate() inside them!
// ─────────────────────────────────────────────────────────────────────────
var usersGroup = app.MapGroup("/users");

usersGroup.MapGet("/", () => Results.Ok(Db.Users));

// ✅ POST — The filter handles validation automatically!
usersGroup.MapPost("/", (CreateUserDto input) =>
{
    // No TryValidate needed! The filter already checked everything!
    var newUser = new User
    {
        Id = Db.NextId++,
        Name = input.Name,
        Email = input.Email
    };

    Db.Users.Add(newUser);
    return Results.Created($"/users/{newUser.Id}", newUser);
})
.AddEndpointFilter<ValidationFilter<CreateUserDto>>();  // ← Attach the filter!

// ✅ PUT — The filter handles validation automatically!
usersGroup.MapPut("/{id:int}", (int id, UpdateUserDto input) =>
{
    // No TryValidate needed! The filter already checked everything!
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound();

    user.Name = input.Name;
    return Results.Ok(user);
})
.AddEndpointFilter<ValidationFilter<UpdateUserDto>>();  // ← Attach the filter!

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// 2. Classes (Must be at bottom of file in C# 9+)
// ─────────────────────────────────────────────────────────────────────────

// The Validation Filter Class
// This runs BEFORE every endpoint it is attached to!
public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, 
        EndpointFilterDelegate next)
    {
        // 1. Find the argument of type T (our DTO) from the request
        var argToValidate = context.Arguments.FirstOrDefault(a => a is T) as T;

        // 2. If there is no body data, reject the request
        if (argToValidate == null)
        {
            return Results.BadRequest(new { Error = "Request body is required." });
        }

        // 3. Validate the data using MiniValidator (same as before!)
        if (!MiniValidator.TryValidate(argToValidate, out var errors))
        {
            return Results.ValidationProblem(errors);
        }

        // 4. If validation passed, continue to the actual endpoint!
        return await next(context);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CreateUserDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}

public class UpdateUserDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }
}

public static class Db
{
    public static int NextId = 3;
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony",   Email = "sony@test.com" },
        new User { Id = 2, Name = "Maysha", Email = "maysha@test.com" }
    };
}


/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. VALID POST:
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "Zaman", "Email": "zaman@test.com"}'
       ✅ 201 Created — Filter let it through!
       
    2. INVALID POST (The filter catches it BEFORE the endpoint runs):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "", "Email": "bad"}'
       ❌ 400 — Filter blocked it! The endpoint code never ran.
       
    3. INVALID PUT:
       curl -X PUT http://localhost:5000/users/1 -H "Content-Type: application/json" -d '{"Name": ""}'
       ❌ 400 — Filter blocked it!
       
    KEY TAKEAWAY:
    - The endpoint code is now 100% clean — no validation logic at all!
    - The filter runs automatically before every attached endpoint.
    - `.AddEndpointFilter<ValidationFilter<CreateUserDto>>()` is how you attach it.
*/
