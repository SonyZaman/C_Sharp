// 161. Route Groups
/*
    NEW CONCEPT: Route Groups
    
    In the previous project, every single endpoint had to type "/users":
    app.MapGet("/users/{id:int}", ...);
    app.MapGet("/users/search/{name:alpha}", ...);
    app.MapGet("/users/adults/{age}", ...);
    
    This is repetitive. What if we decide to change "/users" to "/api/users"? 
    We would have to update it in 100 different places!
    
    Instead, we can use "Route Groups" to define the common prefix ONCE.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model & Fake Database (Same as previous project)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Pin { get; set; }
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Maysha", Age = 21, Pin = 1234 },
        new User { Id = 2, Name = "Sony", Age = 22, Pin = 5678 },
        new User { Id = 3, Name = "Marium", Age = 20, Pin = 9999 },
        new User { Id = 4, Name = "Zaman", Age = 20, Pin = 4321 }
    };
}

// ─────────────────────────────────────────────────────────────────────────
// 2. Create the Route Group
// ─────────────────────────────────────────────────────────────────────────
// This line says: "Every endpoint attached to 'usersGroup' will automatically start with /users"
var usersGroup = app.MapGroup("/users");


// ─────────────────────────────────────────────────────────────────────────
// 3. Use the Route Group (Notice we don't type "/users" anymore!)
// ─────────────────────────────────────────────────────────────────────────

// Maps to: /users
usersGroup.MapGet("/", () => 
{
    return Results.Ok(new { Message = "All Users", Users = Db.Users });
});

// Maps to: /users/{id:int}
usersGroup.MapGet("/{id:int}", (int id) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound(new { Message = $"User ID {id} not found." });

    return Results.Ok(new { Message = "User found by ID", User = user });
});

// Maps to: /users/search/{name:alpha}
usersGroup.MapGet("/search/{name:alpha}", (string name) => 
{
    var users = Db.Users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    if (users.Count == 0) return Results.NotFound(new { Message = $"No users found with name: {name}" });

    return Results.Ok(new { Message = "User found by Name", Users = users });
});

// Maps to: /users/adults/{age:range(18, 100)}
usersGroup.MapGet("/adults/{age:range(18, 100)}", (int age) => 
{
    var users = Db.Users.Where(u => u.Age == age).ToList();
    if (users.Count == 0) return Results.NotFound(new { Message = $"No adult users found with age: {age}" });

    return Results.Ok(new { Message = $"Adult users found with age {age}", Users = users });
});


// Note: You can even have multiple groups! For example:
// var productsGroup = app.MapGroup("/products");
// productsGroup.MapGet(...);


app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then open a new terminal and try these.
    (They work exactly the same as project 160, but the code is much cleaner!)
    
    1. Test Get All (The root of the group):
       curl http://localhost:5000/users

    2. Test 'int' constraint on the group:
       curl http://localhost:5000/users/1        (✅ Works - Returns Maysha)
       
    3. Test 'alpha' constraint on the group:
       curl http://localhost:5000/users/search/Sony    (✅ Works - Returns Sony)
*/
