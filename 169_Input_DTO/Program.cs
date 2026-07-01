// 169. Input DTOs (CreateDto & UpdateDto)
/*
    NEW CONCEPT: Input DTOs
    
    In Project 168, we used a DTO for OUTPUT (to hide the SecretPin from the response).
    Now we learn about DTOs for INPUT (what the user SENDS to us).
    
    PROBLEM with accepting the full User model in a POST request:
    
    public class User { public int Id; public string Name; public int Age; }
    
    If the user sends a POST to create a new User and includes an "Id" in the JSON body,
    they could potentially manipulate your database (e.g., overwriting an existing user!).
    
    SOLUTION: Use a separate "CreateDto" for input that does NOT have the Id property.
    The server always generates the Id. The user never sets it!
    
    Similarly, for PUT (Update), the user should only send the fields they are allowed to update.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Database Model (Full object, only lives inside the server)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }         // Server generates this!
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public int SecretPin { get; set; }  // User should never send or receive this!
}

// ─────────────────────────────────────────────────────────────────────────
// 2. Input DTOs (What the user is ALLOWED to SEND)
// ─────────────────────────────────────────────────────────────────────────

// For CREATE (POST): No Id, No SecretPin!
public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

// For UPDATE (PUT): Only the fields that can be changed
public class UpdateUserDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// 3. Output DTO (What the server is ALLOWED to SEND BACK)
// ─────────────────────────────────────────────────────────────────────────
public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    // Notice: NO SecretPin here!
}

// ─────────────────────────────────────────────────────────────────────────
// 4. Fake Database
// ─────────────────────────────────────────────────────────────────────────
public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Maysha", Email = "maysha@test.com", Age = 21, SecretPin = 1111 },
        new User { Id = 2, Name = "Sony",   Email = "sony@test.com",   Age = 22, SecretPin = 2222 }
    };
    public static int NextId = 3;
}

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// GET ALL: Returns list of safe UserResponseDto
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () => 
{
    var result = Db.Users.Select(u => new UserResponseDto 
        {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email,
        Age = u.Age
    }).ToList();

    return Results.Ok(result);
});

// ─────────────────────────────────────────────────────────────────────────
// POST: Accepts CreateUserDto — user cannot set their own Id or SecretPin!
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPost("/add", (CreateUserDto dto) => 
{
    if (string.IsNullOrWhiteSpace(dto.Name))
        return Results.BadRequest(new { Error = "Name is required." });

    // Create a real User from the safe CreateUserDto
    var newUser = new User 
    {
        Id = Db.NextId++,       // Server sets the Id!
        Name = dto.Name,
        Email = dto.Email,
        Age = dto.Age,
        SecretPin = 9999        // Server sets the Pin! User never touches this.
    };

    Db.Users.Add(newUser);

    // Return a safe UserResponseDto (not the full User with SecretPin!)
    return Results.Ok(new UserResponseDto 
    { 
        Id = newUser.Id, 
        Name = newUser.Name, 
        Email = newUser.Email, 
        Age = newUser.Age 
    });
});

// ─────────────────────────────────────────────────────────────────────────
// PUT: Accepts UpdateUserDto — user can only change Name and Age
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapPut("/{id:int}", (int id, UpdateUserDto dto) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound(new { Error = $"User {id} not found." });

    // Only update the fields from UpdateUserDto
    user.Name = dto.Name;
    user.Age = dto.Age;
    // Email and SecretPin stay untouched!

    return Results.Ok(new UserResponseDto 
    { 
        Id = user.Id, 
        Name = user.Name, 
        Email = user.Email, 
        Age = user.Age 
    });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.

    1. GET ALL USERS (No SecretPin in response!):
       curl http://localhost:5000/users

    2. CREATE USER (You cannot send an Id or SecretPin):
       curl -X POST http://localhost:5000/users/add \
            -H "Content-Type: application/json" \
            -d '{"Name": "Marium", "Email": "marium@test.com", "Age": 20}'

    3. UPDATE USER (You can only change Name and Age):
       curl -X PUT http://localhost:5000/users/1 \
            -H "Content-Type: application/json" \
            -d '{"Name": "Maysha Updated", "Age": 25}'
*/
