// 163. Validation Constraints (Data Annotations)
/*
    NEW CONCEPT: Validation Constraints
    
    Instead of writing tons of `if` statements (like we did in Project 162),
    C# provides "Data Annotations". These are attributes you place directly 
    on your class properties to define the "Rules" for that data.

    In Minimal APIs, we use a very popular package called `MiniValidation` 
    to trigger these rules with just ONE single line of code!
*/

using System.ComponentModel.DataAnnotations;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model with Constraints (The Rules)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    // Rule: Cannot be null or empty
    [Required(ErrorMessage = "Name is absolutely required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
    public string Name { get; set; }

    // Rule: Must be a valid email format
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; set; }

    // Rule: Must be between 18 and 120
    [Range(18, 120, ErrorMessage = "You must be at least 18 years old to register.")]
    public int Age { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// 2. The Endpoint
// ─────────────────────────────────────────────────────────────────────────
app.MapPost("/users/add", (User newUser) => 
{
    // THIS ONE LINE replaces all of your manual `if` statements!
    // It looks at the [Required], [Range] attributes and checks them.
    if (!MiniValidator.TryValidate(newUser, out var errors))
    {
        // ValidationProblem automatically formats all the errors beautifully!
        return Results.ValidationProblem(errors);
    }

    // If we reach here, the data is 100% valid!
    return Results.Ok(new 
    { 
        Message = "User successfully registered!", 
        User = newUser 
    });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then open a new terminal.
    
    1. VALID REQUEST (Should return 200 OK):
       curl -X POST http://localhost:5000/users/add \
            -H "Content-Type: application/json" \
            -d '{"Name": "Sony", "Email": "sony@example.com", "Age": 25}'
            
    2. INVALID REQUEST (Missing fields, bad email, underage)
       (Should return 400 Bad Request with all the error messages!):
       curl -X POST http://localhost:5000/users/add \
            -H "Content-Type: application/json" \
            -d '{"Name": "Jo", "Email": "not-an-email", "Age": 15}'
*/
