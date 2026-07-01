// 162. Basic Validation (Manual if-statements)
/*
    NEW CONCEPT: Basic Validation
    
    When a user sends data to your API (like creating a new user), 
    you should NEVER trust it! They might forget their Name, or put a negative Age.
    
    The easiest and most basic way to validate data is using simple 
    `if` statements inside your endpoint. 
    
    If the data is bad, we stop the code and return:
    `Results.BadRequest("Error Message")` -> This sends a 400 Bad Request error.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model & Fake Database
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Maysha", Age = 21 }
    };
    public static int NextId = 2;
}

// ─────────────────────────────────────────────────────────────────────────
// 2. MapGroup for cleaner code
// ─────────────────────────────────────────────────────────────────────────
var usersGroup = app.MapGroup("/users");

// GET ALL
usersGroup.MapGet("/", () => Results.Ok(Db.Users));

// ─────────────────────────────────────────────────────────────────────────
// 3. POST Endpoint with BASIC MANUAL VALIDATION
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPost("/add", (User newUser) => 
{
    // --- START OF VALIDATION ---

    // Rule 1: Name cannot be empty
    if (string.IsNullOrWhiteSpace(newUser.Name))
    {
        return Results.BadRequest(new { Error = "Validation Failed: Name is absolutely required!" });
    }

    // Rule 2: Name must be at least 3 characters long
    if (newUser.Name.Length < 3)
    {
        return Results.BadRequest(new { Error = "Validation Failed: Name must be at least 3 characters long." });
    }

    // Rule 3: Age must be 18 or older
    if (newUser.Age < 18)
    {
        return Results.BadRequest(new { Error = "Validation Failed: You must be at least 18 years old." });
    }

    // Rule 4: Age cannot be insanely high
    if (newUser.Age > 120)
    {
        return Results.BadRequest(new { Error = "Validation Failed: Age cannot be more than 120." });
    }

    // --- END OF VALIDATION ---

    // If we reach this line, the data is perfectly valid!
    newUser.Id = Db.NextId++;
    Db.Users.Add(newUser);

    return Results.Ok(new { Message = "User added successfully!", User = newUser });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then try these in a new terminal:
    
    1. VALID USER:
       curl -X POST http://localhost:5000/users/add -H "Content-Type: application/json" -d '{"Name": "Sony", "Age": 22}'
       (✅ Works - User gets added)

    2. BAD REQUEST (Missing Name):
       curl -X POST http://localhost:5000/users/add -H "Content-Type: application/json" -d '{"Name": "", "Age": 22}'
       (❌ Fails - "Name is absolutely required")
       
    3. BAD REQUEST (Too young):
       curl -X POST http://localhost:5000/users/add -H "Content-Type: application/json" -d '{"Name": "Zaman", "Age": 15}'
       (❌ Fails - "You must be at least 18")
*/
