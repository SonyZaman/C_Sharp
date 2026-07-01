// 177. Response DTO Mapping: LINQ .Select() Projection
/*
    NEW CONCEPT: DTO Mapping with LINQ (.Select)
    
    In Project 176, we used a `foreach` loop to create a brand new DTO for every User.
    It took 5 lines of code.
    
    LINQ provides `.Select()` specifically for this job!
    `.Select()` is called a "Projection" method. It projects (transforms) each item 
    in a list into a NEW shape (like turning a User into a UserResponseDto).
    
    COMPARISON (Mapping a List):
    
    ── Manual (176 style) ──────────────────────────────────────────────
    var safeList = new List<UserResponseDto>();
    foreach (var user in Db.Users) {
        safeList.Add(new UserResponseDto { Id = user.Id, Name = user.Name });
    }
    
    ── LINQ .Select() (177 style) ──────────────────────────────────────
    var safeList = Db.Users.Select(u => new UserResponseDto { Id = u.Id, Name = u.Name }).ToList();
    
    As always, LINQ does the exact same loop behind the scenes, but makes your code much cleaner!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Database Model & Output DTO (Same as 176)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SecretPin { get; set; }
}

public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
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
// 2. GET ONE: Manual Mapping (Still the same!)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/{id:int}", (int id) =>
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound();

    // Remember: We only use .Select() for LISTS. 
    // Since this is just ONE object, we still map it manually!
    var dto = new UserResponseDto 
    {
        Id = user.Id,
        Name = user.Name
    };

    return Results.Ok(dto);
});

// ─────────────────────────────────────────────────────────────────────────
// 3. GET ALL: LINQ Mapping (.Select)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    // The entire 5-line foreach loop from 176 is replaced by this!
    // .Select() loops through each user (u) and creates a new DTO for them.
    var safeUsersList = Db.Users
        .Select(u => new UserResponseDto
        {
            Id = u.Id,
            Name = u.Name
        })
        .ToList();

    return Results.Ok(safeUsersList);
});

app.Run();

/*
    HOW TO TEST:
    
    The commands and results are identical to Project 176.
    
    1. GET ONE USER:
       curl http://localhost:5000/users/1
       
    2. GET ALL USERS:
       curl http://localhost:5000/users
       (Returns all 3 users, safely mapped without the SecretPin!)
       
    IMPORTANT RULE TO REMEMBER:
    - 1 object?  -> Use Manual Mapping: new Dto { ... }
    - A list?    -> Use LINQ: .Select(u => new Dto { ... })
*/
