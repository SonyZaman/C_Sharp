// 178. Full CRUD Practice: Manual Mapping (No LINQ)
/*
    MILESTONE PRACTICE: Full CRUD API (The Manual Way)
    
    This project combines EVERYTHING you have learned so far:
    - Route Groups
    - HTTP Methods (GET, POST, PUT, DELETE)
    - Status Codes (200, 201, 400, 404)
    - Input DTOs & Output DTOs
    - Basic Validation
    
    RULE FOR THIS PROJECT: NO LINQ ALLOWED!
    We will use `foreach` loops for everything (even finding a user by ID).
    This will prove exactly why LINQ is so valuable when we rewrite this in Project 179!
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
    public string SecretPassword { get; set; } // DANGER!
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
// 3. GET ALL (Manual foreach loop to map to DTO)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    var responseList = new List<UserResponseDto>();

    foreach (var user in Db.Users)
    {
        var dto = new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
        responseList.Add(dto);
    }

    return Results.Ok(responseList);
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET BY ID (Manual loop to find user, then manual DTO map)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/{id:int}", (int id) =>
{
    User foundUser = null;

    // Manual search instead of .FirstOrDefault()
    foreach (var user in Db.Users)
    {
        if (user.Id == id)
        {
            foundUser = user;
            break;
        }
    }

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
// 5. POST (Manual Validation + Input DTO to DB Model)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPost("/", (CreateUserDto input) =>
{
    // Manual Validation
    if (string.IsNullOrWhiteSpace(input.Name)) return Results.BadRequest("Name is required");
    if (string.IsNullOrWhiteSpace(input.Email)) return Results.BadRequest("Email is required");

    // Map Input DTO to DB Model
    var newUser = new User
    {
        Id = Db.NextId++,
        Name = input.Name,
        Email = input.Email,
        SecretPassword = input.SecretPassword
    };

    Db.Users.Add(newUser);

    // Map DB Model to Output DTO
    var responseDto = new UserResponseDto
    {
        Id = newUser.Id,
        Name = newUser.Name,
        Email = newUser.Email
    };

    return Results.Created($"/users/{newUser.Id}", responseDto);
});

// ─────────────────────────────────────────────────────────────────────────
// 6. PUT (Manual search + Update + Output DTO)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPut("/{id:int}", (int id, UpdateUserDto input) =>
{
    User foundUser = null;

    foreach (var user in Db.Users)
    {
        if (user.Id == id)
        {
            foundUser = user;
            break;
        }
    }

    if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

    if (string.IsNullOrWhiteSpace(input.Name)) return Results.BadRequest("Name is required");

    // Update the DB Model
    foundUser.Name = input.Name;
    foundUser.Email = input.Email;
    // Notice: SecretPassword is NOT updated because UpdateUserDto doesn't have it!

    var responseDto = new UserResponseDto
    {
        Id = foundUser.Id,
        Name = foundUser.Name,
        Email = foundUser.Email
    };

    return Results.Ok(responseDto);
});

// ─────────────────────────────────────────────────────────────────────────
// 7. DELETE (Manual search + Remove)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapDelete("/{id:int}", (int id) =>
{
    User foundUser = null;

    foreach (var user in Db.Users)
    {
        if (user.Id == id)
        {
            foundUser = user;
            break;
        }
    }

    if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

    Db.Users.Remove(foundUser);

    return Results.Ok(new { Message = $"User {id} deleted successfully" });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. GET ALL:    curl http://localhost:5000/users
    2. GET ONE:    curl http://localhost:5000/users/1
    3. CREATE:     curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name":"Zaman","Email":"zaman@test.com","SecretPassword":"123"}'
    4. UPDATE:     curl -X PUT http://localhost:5000/users/1 -H "Content-Type: application/json" -d '{"Name":"Sony Updated","Email":"sony@new.com"}'
    5. DELETE:     curl -X DELETE http://localhost:5000/users/1
    
    LOOK AT ALL THIS CODE! 
    This is what APIs look like without LINQ. It is very repetitive.
    Are you ready to rewrite this masterpiece using LINQ in Project 179?
*/
