// 168. Data Transfer Objects (DTO)
/*
    NEW CONCEPT: DTOs (Data Transfer Objects)
    
    A DTO is just a regular C# class used to transfer data safely.
    
    PROBLEM: 
    Your database `User` class often contains sensitive data (Passwords, PINs, Internal IDs).
    If you return the `User` object directly in your API, you leak that data to the internet!
    
    SOLUTION:
    Create a "Safe" class (DTO) that only has the properties you want the internet to see.
    Before returning, you copy the data from the `User` to the `DTO` and return the `DTO`.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. The Database Model (Contains Secrets!)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int SecretPin { get; set; } // We do NOT want the internet to see this!
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony", Age = 25, SecretPin = 1234 }
    };
}

// ─────────────────────────────────────────────────────────────────────────
// 2. The DTO (The Safe Version)
// ─────────────────────────────────────────────────────────────────────────
public class SafeUserDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    // Notice there is NO SecretPin property here!
}

// ─────────────────────────────────────────────────────────────────────────
// 3. The Endpoints
// ─────────────────────────────────────────────────────────────────────────

// ❌ BAD: Returns the Database Model directly
app.MapGet("/users/bad/{id:int}", (int id) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound();

    // DANGER: This sends the SecretPin to the user's browser!
    return Results.Ok(user);
});

// ✅ GOOD: Returns the DTO
app.MapGet("/users/good/{id:int}", (int id) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound();

    // 1. Create a new DTO
    var safeDto = new SafeUserDto 
    {
        Name = user.Name,
        Age = user.Age
    };

    // 2. Return the DTO instead of the Database User!
    return Results.Ok(safeDto);
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then open a new terminal.
    
    1. BAD REQUEST (Leaking Data):
       curl http://localhost:5000/users/bad/1
       Notice how the JSON response includes "SecretPin": 1234
       
    2. GOOD REQUEST (Safe Data):
       curl http://localhost:5000/users/good/1
       Notice how the JSON only contains "Name" and "Age". The PIN is safe!
*/
