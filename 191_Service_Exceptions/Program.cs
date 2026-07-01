// 191. Service Exceptions (throw + try-catch pattern)
/*
    NEW CONCEPT: Throwing Exceptions from a Service
    
    In Project 187, our Service just returned `null` when a user wasn't found:
        public User GetUserById(int id) => Db.Users.FirstOrDefault(u => u.Id == id);
    
    Then the endpoint checked if the result was null and returned NotFound().
    This is fine for simple cases. But what about COMPLEX business rule failures?
    
    Imagine your service does 5 different things and any one of them could fail.
    The endpoint would need to check 5 different return values!
    
    The BETTER pattern (used in real enterprise code) is:
    - The SERVICE "throws" an exception when something goes wrong.
    - The ENDPOINT wraps the call in `try-catch` and converts the exception into an HTTP response.
    
    This keeps the business logic (WHY it failed) inside the Service,
    and the HTTP logic (WHAT to send to the client) inside the Endpoint/Controller.
*/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserService, UserService>();
var app = builder.Build();

var usersGroup = app.MapGroup("/users");

// GET ALL
usersGroup.MapGet("/", (IUserService userService) =>
{
    var users = userService.GetAllUsers();
    return Results.Ok(users);
});

// GET BY ID — using try-catch to handle Service exceptions!
usersGroup.MapGet("/{id:int}", (int id, IUserService userService) =>
{
    try
    {
        var user = userService.GetUserById(id);
        return Results.Ok(user);
    }
    catch (KeyNotFoundException ex)
    {
        // The Service threw a KeyNotFoundException → we return 404
        return Results.NotFound(new { Error = ex.Message });
    }
});

// CREATE — using try-catch to handle duplicate email exception!
usersGroup.MapPost("/", (CreateUserDto input, IUserService userService) =>
{
    try
    {
        var newUser = userService.CreateUser(input);
        return Results.Created($"/users/{newUser.Id}", newUser);
    }
    catch (InvalidOperationException ex)
    {
        // The Service threw an InvalidOperationException → we return 409 Conflict
        return Results.Conflict(new { Error = ex.Message });
    }
});

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// Classes at bottom (C# 9+ rule!)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CreateUserDto
{
    public string Name { get; set; }
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

public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(int id);
    User CreateUser(CreateUserDto input);
}

public class UserService : IUserService
{
    public List<User> GetAllUsers() => Db.Users.ToList();

    public User GetUserById(int id)
    {
        var user = Db.Users.FirstOrDefault(u => u.Id == id);

        // Instead of returning null, THROW an exception!
        // The endpoint's try-catch will handle this.
        if (user == null)
            throw new KeyNotFoundException($"User with ID {id} does not exist.");

        return user;
    }

    public User CreateUser(CreateUserDto input)
    {
        // Business Rule: Email must be unique
        var emailExists = Db.Users.Any(u => u.Email.Equals(input.Email, StringComparison.OrdinalIgnoreCase));

        // Instead of returning null, THROW an exception with a clear message!
        if (emailExists)
            throw new InvalidOperationException($"Email '{input.Email}' is already registered.");

        var newUser = new User
        {
            Id = Db.NextId++,
            Name = input.Name,
            Email = input.Email
        };

        Db.Users.Add(newUser);
        return newUser;
    }
}

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. GET VALID USER:
       curl http://localhost:5000/users/1
       ✅ Returns Sony
       
    2. GET NON-EXISTENT USER (Service throws KeyNotFoundException):
       curl http://localhost:5000/users/99
       ❌ Returns 404 — "User with ID 99 does not exist."
       
    3. CREATE VALID USER:
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name":"Zaman","Email":"zaman@test.com"}'
       ✅ Returns 201 Created
       
    4. CREATE DUPLICATE EMAIL (Service throws InvalidOperationException):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name":"Test","Email":"sony@test.com"}'
       ❌ Returns 409 Conflict — "Email 'sony@test.com' is already registered."
       
    KEY TAKEAWAY:
    - Service is responsible for WHAT went wrong (business logic).
    - Endpoint is responsible for HOW to respond (HTTP status codes).
    - `KeyNotFoundException` → 404 Not Found
    - `InvalidOperationException` → 409 Conflict
    - Any other crash → Global Error Handler catches it → 500 Internal Server Error
*/
