// 176. Response DTO Mapping: Manual (foreach loop)
/*
    NEW CONCEPT: DTO Mapping for Lists (Manual)
    
    Back in Project 168, we learned about Output DTOs to hide the `SecretPin`.
    But we only mapped ONE user at a time.
    
    What happens when someone requests `GET /users` and you have a LIST of users?
    You cannot just return `Db.Users` because that exposes the SecretPin for everyone!
    
    In this project, we manually convert a List of Users into a List of DTOs
    using a `foreach` loop. 
    
    In the next project (177), we will replace this loop with LINQ `.Select()`.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Database Model (Has Secrets!)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SecretPin { get; set; }  // DANGER! Do not expose this!
}

// ─────────────────────────────────────────────────────────────────────────
// 2. Output DTO (Safe for the internet)
// ─────────────────────────────────────────────────────────────────────────
public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    // NO SecretPin!
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony",   SecretPin = 1234 },
        new User { Id = 2, Name = "Maysha", SecretPin = 5678 },
        new User { Id = 3, Name = "Zaman",  SecretPin = 9999 }
    };
}

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 3. GET ONE: Manual Mapping (One Object)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/{id:int}", (int id) =>
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound();

    // Mapping one object is easy — no loops needed!
    var dto = new UserResponseDto 
    {
        Id = user.Id,
        Name = user.Name
    };

    return Results.Ok(dto);
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET ALL: Manual Mapping (List of Objects using foreach)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    // Step 1: Create an empty list to hold the safe DTOs
    var safeUsersList = new List<UserResponseDto>();

    // Step 2: Loop through every user in the database
    foreach (var user in Db.Users)
    {
        // Step 3: Create a safe DTO for this specific user
        var dto = new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name
        };

        // Step 4: Add it to our safe list
        safeUsersList.Add(dto);
    }

    // Step 5: Return the safe list!
    return Results.Ok(safeUsersList);
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. GET ONE USER:
       curl http://localhost:5000/users/1
       (Notice: No SecretPin is returned!)
       
    2. GET ALL USERS:
       curl http://localhost:5000/users
       (Notice: It returns a list of all 3 users, but NONE of them have a SecretPin!)
       
    NOTICE: The `foreach` loop in GET ALL works perfectly, but it is a lot of code.
    In Project 177, we will replace the entire loop with LINQ `.Select()`!
*/
