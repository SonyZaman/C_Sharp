// 183. Logical Validation (Business Rules)
/*
    NEW CONCEPT: Logical Validation
    
    You already know TWO types of validation:
    1. Manual `if` statements (Project 162)
    2. Data Annotations like [Required], [EmailAddress] (Project 163)
    
    But Data Annotations can only check the FORMAT of data.
    They CANNOT check your database!
    
    Example: What if someone tries to register with "sony@test.com"
    but that email already exists in the database?
    [EmailAddress] will say "✅ Valid email format!" — it doesn't know the email is taken!
    
    That is why we need LOGICAL VALIDATION (also called Business Rule Validation).
    These are `if` checks that run AFTER Data Annotations pass,
    and they look at the database to enforce business rules.
    
    VALIDATION ORDER:
    Step 1: Data Annotations → Check format (Is it a valid email? Is name long enough?)
    Step 2: Logical Validation → Check database (Does this email already exist?)
    Step 3: Save to database → Only if BOTH steps pass!
*/

using System.ComponentModel.DataAnnotations;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var usersGroup = app.MapGroup("/users");

usersGroup.MapGet("/", () => Results.Ok(Db.Users));

usersGroup.MapPost("/", (CreateUserDto input) =>
{
    // ──────────────────────────────────────────────────────
    // STEP 1: Data Annotation Validation (format check)
    // ──────────────────────────────────────────────────────
    if (!MiniValidator.TryValidate(input, out var errors))
    {
        return Results.ValidationProblem(errors);
    }

    // ──────────────────────────────────────────────────────
    // STEP 2: Logical Validation (business rule check)
    // Data Annotations CANNOT do this! Only code can.
    // ──────────────────────────────────────────────────────

    // Business Rule 1: Email must be unique in the database
    var emailExists = Db.Users.Any(u => u.Email.Equals(input.Email, StringComparison.OrdinalIgnoreCase));
    if (emailExists)
    {
        return Results.Conflict(new { Error = $"Email '{input.Email}' is already registered!" });
    }

    // Business Rule 2: Name must also be unique
    var nameExists = Db.Users.Any(u => u.Name.Equals(input.Name, StringComparison.OrdinalIgnoreCase));
    if (nameExists)
    {
        return Results.Conflict(new { Error = $"Username '{input.Name}' is already taken!" });
    }

    // ──────────────────────────────────────────────────────
    // STEP 3: Both validations passed! Safe to save.
    // ──────────────────────────────────────────────────────
    var newUser = new User
    {
        Id = Db.NextId++,
        Name = input.Name,
        Email = input.Email
    };

    Db.Users.Add(newUser);

    return Results.Created($"/users/{newUser.Id}", newUser);
});

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// Classes (Must be at bottom of file in C# 9+)
// ─────────────────────────────────────────────────────────────────────────

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
    
    1. VALID (Brand new email):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "Zaman", "Email": "zaman@test.com"}'
       ✅ Returns 201 Created
       
    2. FORMAT ERROR (Bad email - caught by Data Annotation):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "Rasel", "Email": "not-an-email"}'
       ❌ Returns 400 - "Invalid email format"
       
    3. DUPLICATE EMAIL (Caught by Logical Validation!):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "Rasel", "Email": "sony@test.com"}'
       ❌ Returns 409 Conflict - "Email 'sony@test.com' is already registered!"
       
    4. DUPLICATE NAME (Caught by Logical Validation!):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "Sony", "Email": "new@test.com"}'
       ❌ Returns 409 Conflict - "Username 'Sony' is already taken!"
       
    NEW THINGS TO NOTICE:
    - `.Any()` is a LINQ method that returns true/false if ANY item matches.
    - `Results.Conflict()` returns a 409 status code (means "data conflicts with existing data").
*/
