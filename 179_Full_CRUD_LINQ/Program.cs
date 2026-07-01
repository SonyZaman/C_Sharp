// 179. Full CRUD Practice: LINQ Style
/*
    MILESTONE PRACTICE: Full CRUD API (The LINQ Way)
    
    This is the EXACT SAME PROJECT as 178, but we have replaced every single 
    `foreach` loop with LINQ!
    
    Notice how much cleaner, shorter, and more professional this file looks 
    compared to 178.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Database Model & Fake Database
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string SecretPassword { get; set; }
}

public static class Db
{
    public static int NextId = 3;
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony",   Email = "sony@test.com",   SecretPassword = "pass1" },
        new User { Id = 2, Name = "Maysha", Email = "maysha@test.com", SecretPassword = "pass2" }
    };
}

// ─────────────────────────────────────────────────────────────────────────
// 2. DTOs
// ─────────────────────────────────────────────────────────────────────────
public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string SecretPassword { get; set; }
}

public class UpdateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 3. GET ALL (Using LINQ .Select instead of a foreach loop!)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    var responseList = Db.Users.Select(u => new UserResponseDto
    {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email
    }).ToList();

    return Results.Ok(responseList);
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET BY ID (Using LINQ .FirstOrDefault instead of a foreach loop!)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/{id:int}", (int id) =>
{
    // ONE LINE replaces 10 lines from Project 178!
    var foundUser = Db.Users.FirstOrDefault(u => u.Id == id);
    if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

    var dto = new UserResponseDto
    {
        Id = foundUser.Id,
        Name = foundUser.Name,
        Email = foundUser.Email
    };

    return Results.Ok(dto);
});

// ─────────────────────────────────────────────────────────────────────────
// 5. POST (Same as 178)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPost("/", (CreateUserDto input) =>
{
    if (string.IsNullOrWhiteSpace(input.Name)) return Results.BadRequest("Name is required");
    if (string.IsNullOrWhiteSpace(input.Email)) return Results.BadRequest("Email is required");

    var newUser = new User
    {
        Id = Db.NextId++,
        Name = input.Name,
        Email = input.Email,
        SecretPassword = input.SecretPassword
    };

    Db.Users.Add(newUser);

    var responseDto = new UserResponseDto
    {
        Id = newUser.Id,
        Name = newUser.Name,
        Email = newUser.Email
    };

    return Results.Created($"/users/{newUser.Id}", responseDto);
});

// ─────────────────────────────────────────────────────────────────────────
// 6. PUT (Using LINQ .FirstOrDefault instead of a foreach loop!)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPut("/{id:int}", (int id, UpdateUserDto input) =>
{
    // ONE LINE replaces 10 lines from Project 178!
    var foundUser = Db.Users.FirstOrDefault(u => u.Id == id);
    if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

    if (string.IsNullOrWhiteSpace(input.Name)) return Results.BadRequest("Name is required");

    foundUser.Name = input.Name;
    foundUser.Email = input.Email;

    var responseDto = new UserResponseDto
    {
        Id = foundUser.Id,
        Name = foundUser.Name,
        Email = foundUser.Email
    };

    return Results.Ok(responseDto);
});

// ─────────────────────────────────────────────────────────────────────────
// 7. DELETE (Using LINQ .FirstOrDefault instead of a foreach loop!)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapDelete("/{id:int}", (int id) =>
{
    // ONE LINE replaces 10 lines from Project 178!
    var foundUser = Db.Users.FirstOrDefault(u => u.Id == id);
    if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

    Db.Users.Remove(foundUser);

    return Results.Ok(new { Message = $"User {id} deleted successfully" });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    (Tests are the exact same as 178, but the code is much shorter and cleaner!)
    
    1. GET ALL:    curl http://localhost:5000/users
    2. GET ONE:    curl http://localhost:5000/users/1
    3. CREATE:     curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name":"Zaman","Email":"zaman@test.com","SecretPassword":"123"}'
    4. UPDATE:     curl -X PUT http://localhost:5000/users/1 -H "Content-Type: application/json" -d '{"Name":"Sony Updated","Email":"sony@new.com"}'
    5. DELETE:     curl -X DELETE http://localhost:5000/users/1
*/
