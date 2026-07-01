// 166. Optional Route Parameters
/*
    NEW CONCEPT: Optional Route Parameters
    
    In Project 160, you learned how to require an ID: `/users/{id:int}`. 
    But what if you want an endpoint to handle BOTH `/users` AND `/users/1`?
    
    By adding a question mark inside the curly braces `?`, we make the parameter OPTIONAL.
    `/users/{id?}`
    
    This works perfectly with Nullable Types (`int?`), which you learned in Project 165!
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
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Maysha" },
        new User { Id = 2, Name = "Sony" },
        new User { Id = 3, Name = "Marium" },
        new User { Id = 4, Name = "Zaman" }
    };
}

// ─────────────────────────────────────────────────────────────────────────
// 2. The Endpoint with an Optional Parameter
// ─────────────────────────────────────────────────────────────────────────
// Notice the `?` in the route: {id?}
// Notice the `?` in the variable type: int?
app.MapGet("/users/{id?}", (int? id) => 
{
    // Scenario 1: The user didn't provide an ID (they just went to /users)
    if (id == null)
    {
        return Results.Ok(new { Message = "Returning ALL users", Users = Db.Users });
    }

    // Scenario 2: The user provided an ID (they went to /users/2)
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    
    if (user == null) 
    {
        return Results.NotFound(new { Message = $"User ID {id} not found." });
    }

    return Results.Ok(new { Message = "Returning specific user", User = user });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then open a new terminal.
    
    1. WITHOUT ID (Returns all users):
       curl http://localhost:5000/users
       
    2. WITH ID (Returns specific user):
       curl http://localhost:5000/users/2
*/
