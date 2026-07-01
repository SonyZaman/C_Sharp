// This file contains ALL of the User endpoints, hidden away from Program.cs!

public static class UserEndpoints
{
    // 1: Do we have to name it `MapUserEndpoints`?
    // ANSWER: No! We can name it `RegisterUserRoutes` or `AddSonyEndpoints`. 
    // `MapUserEndpoints` is just a standard naming convention.
    
    // 2: What is `this WebApplication app`?
    // ANSWER: `WebApplication` is the data type of the `app` variable in Program.cs.
    // By using the `this` keyword, we are "gluing" our custom method directly 
    // onto the `app` object! It acts like a built-in feature of `app`.
    public static void MapUserEndpoints(this WebApplication app)
    {
        // 1. We create the group just like we did in Project 161
        var usersGroup = app.MapGroup("/users");

        // 2. We attach all our endpoints to the group
        usersGroup.MapGet("/", () => 
        {
            return Results.Ok(new { Message = "All Users", Users = Db.Users });
        });

        usersGroup.MapGet("/{id:int}", (int id) => 
        {
            var user = Db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return Results.NotFound(new { Message = $"User ID {id} not found." });

            return Results.Ok(new { Message = "User found", User = user });
        });

        // If we add MapPost, MapPut, MapDelete later, they all go perfectly in here!
    }
}

// ─────────────────────────────────────────────────────────────────────────
// Data Model & Fake Database (Moved here to keep things simple for this project)
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
        new User { Id = 3, Name = "Marium" }
    };
}
