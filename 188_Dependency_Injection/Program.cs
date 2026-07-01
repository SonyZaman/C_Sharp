// 188. Dependency Injection (DI) & Interfaces
/*
    NEW CONCEPT: Dependency Injection (DI)
    
    In Project 187, we created our service manually: 
        `var userService = new UserService();`
        
    This is BAD practice. Why? 
    1. If `UserService` needs its own database connection, you have to pass it manually.
    2. It makes your code tightly coupled (hard to test).
    
    Instead, we use Dependency Injection (DI).
    
    HOW IT WORKS:
    1. Create an INTERFACE (`IUserService`) which acts like a contract.
    2. Register it with the builder: `builder.Services.AddSingleton<IUserService, UserService>();`
    3. Simply ASK for it in your endpoint parameters! .NET will magically provide it.
*/

var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────────────────────────────────────
// STEP 1: Register the Service with the Dependency Injection Container
// ─────────────────────────────────────────────────────────────────────────
// "Singleton" means .NET creates ONE instance of UserService and shares it everywhere.
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 2. The Endpoints (Using Dependency Injection)
// ─────────────────────────────────────────────────────────────────────────

var usersGroup = app.MapGroup("/users");

// Look at the parameter: `(IUserService userService)`
// We never used `new`! .NET looks at the parameter, says "Oh, they need an IUserService!", 
// checks the builder.Services registration, and automatically hands us a `UserService`.
usersGroup.MapGet("/", (IUserService userService) =>
{
    var users = userService.GetAllUsers();
    return Results.Ok(users);
});

app.Run();

// ─────────────────────────────────────────────────────────────────────────
// 3. Classes and Interfaces (Must be at bottom of file in C# 9+)
// ─────────────────────────────────────────────────────────────────────────
public class User { public int Id { get; set; } public string Name { get; set; } }

public static class Db
{
    public static List<User> Users = new List<User> { new User { Id = 1, Name = "Sony" } };
}

public interface IUserService
{
    List<User> GetAllUsers();
}

public class UserService : IUserService
{
    public List<User> GetAllUsers()
    {
        return Db.Users;
    }
}

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    curl http://localhost:5000/users
    
    It works exactly the same! But the architecture is completely decoupled.
    When you move to MVC Controllers, the exact same injection happens in the 
    Controller's constructor!
*/
