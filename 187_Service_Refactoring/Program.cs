// 187. Service Layer Refactoring (Business Logic Separation)
/*
    NEW CONCEPT: The Service Layer
    
    Until now, our Endpoints have talked DIRECTLY to the Database:
        usersGroup.MapGet("/", () => Db.Users.ToList());
        
    In a real app, Endpoints should be DUMB. They should only handle HTTP 
    (status codes, routing). They should NOT handle business logic or database queries!
    
    We fix this by creating a "Service Class" (UserService). 
    The Endpoint asks the Service for data. The Service talks to the DB.
    
    Request → Endpoint (Dumb) → UserService (Smart) → Database
    
    This is EXACTLY how MVC Controllers work, so this is perfect practice!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. THE ENDPOINTS (Dumb HTTP handlers)
// Notice how clean they are! No database code at all.
// ─────────────────────────────────────────────────────────────────────────

var usersGroup = app.MapGroup("/users");

// We create an instance of our service to use
var userService = new UserService();

usersGroup.MapGet("/", () =>
{
    // The endpoint just asks the service for the data!
    var users = userService.GetAllUsers();
    return Results.Ok(users);
});

usersGroup.MapGet("/{id:int}", (int id) =>
{
    var user = userService.GetUserById(id);
    
    if (user == null) return Results.NotFound("User not found");
    
    return Results.Ok(user);
});

usersGroup.MapPost("/{name}", (string name) =>
{
    var createdUser = userService.CreateUser(name);
    return Results.Created($"/users/{createdUser.Id}", createdUser);
});

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// 2. THE SERVICE LAYER AND DATABASE (MUST BE AT BOTTOM IN C# 9+)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class Db
{
    public static int NextId = 3;
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony" },
        new User { Id = 2, Name = "Maysha" }
    };
}

public class UserService
{
    // The Service handles all the LINQ and DB interactions
    public List<User> GetAllUsers()
    {
        return Db.Users.OrderBy(u => u.Name).ToList();
    }

    public User GetUserById(int id)
    {
        return Db.Users.FirstOrDefault(u => u.Id == id);
    }

    public User CreateUser(string name)
    {
        var newUser = new User { Id = Db.NextId++, Name = name };
        Db.Users.Add(newUser);
        return newUser;
    }
}

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    curl http://localhost:5000/users
    curl http://localhost:5000/users/1
    curl -X POST http://localhost:5000/users/Zaman
    
    Everything works exactly the same, but the ARCHITECTURE is now enterprise-grade.
*/
