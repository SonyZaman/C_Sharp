// 160. Route Constraints
/*
    NEW CONCEPT: Route Constraints
    
    In the previous project, we learned how to get data from the URL path:
    app.MapGet("/users/{id}", ...);
    
    But what if someone types: "/users/hello" ?
    If your code expects an integer (int id), it will crash or give a bad error!
    
    To fix this easily, we use "Route Constraints". We tell ASP.NET Core exactly 
    what TYPE of data is allowed in the URL.
    
    Examples:
    {id:int}   -> Only allows numbers (1, 2, 99)
    {name:alpha} -> Only allows alphabet letters (A-Z)
    {age:min(18)} -> Only allows numbers 18 or higher
    {code:regex(^USR-[0-9]{3}$)} -> Uses Regular Expressions for complex patterns
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
    public int Age { get; set; }
    public int Pin { get; set; }
    public string Email { get; set; } 
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Maysha", Age = 21, Pin = 1234, Email = "maysha@test.com" },
        new User { Id = 2, Name = "Sony", Age = 22, Pin = 5678, Email = "sony@test.com" },
        new User { Id = 3, Name = "Marium", Age = 20, Pin = 9999, Email = "marium@test.com" },
        new User { Id = 4, Name = "Zaman", Age = 20, Pin = 4321, Email = "zaman@test.com" }
    };
}

// ─────────────────────────────────────────────────────────────────────────
// 2. INT Constraint: Only match if {id} is a number
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/users/{id:int}", (int id) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) return Results.NotFound(new { Message = $"User ID {id} not found." });

    return Results.Ok(new { Message = "User found by ID", User = user });
});

// ─────────────────────────────────────────────────────────────────────────
// 3. ALPHA Constraint: Only match if {name} is letters (no numbers/symbols)
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/users/search/{name:alpha}", (string name) => 
{
    // Search case-insensitive
    var users = Db.Users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    if (users.Count == 0) return Results.NotFound(new { Message = $"No users found with name: {name}" });

    return Results.Ok(new { Message = "User found by Name", Users = users });
});

// ─────────────────────────────────────────────────────────────────────────
// 4. RANGE Constraint: Only match if {age} is between 18 and 100
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/users/adults/{age:range(18, 100)}", (int age) => 
{
    var users = Db.Users.Where(u => u.Age == age).ToList();
    if (users.Count == 0) return Results.NotFound(new { Message = $"No adult users found with age: {age}" });

    return Results.Ok(new { Message = $"Adult users found with age {age}", Users = users });
});

// ─────────────────────────────────────────────────────────────────────────
// 5. MULTIPLE Constraints: Must be a number AND must be exactly 4 digits long
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/users/pin/{pin:int:length(4)}", (int pin) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Pin == pin);
    if (user == null) return Results.NotFound(new { Message = $"No user found with PIN: {pin}" });

    return Results.Ok(new { Message = "User found by PIN", User = user });
});

// ─────────────────────────────────────────────────────────────────────────
// 6. REGEX Constraint: Must match a specific pattern
//    Pattern: Must be a simple email format (something@something.something)
// ─────────────────────────────────────────────────────────────────────────
app.MapGet(@"/users/email/{email:regex(^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)}", (string email) => 
{
    var user = Db.Users.FirstOrDefault(u => u.Email == email);
    if (user == null) return Results.NotFound(new { Message = $"No user found with Email: {email}" });

    return Results.Ok(new { Message = "User found by Email", User = user });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then open a new terminal and try these:
    
    1. Test 'int' constraint:
       curl http://localhost:5000/users/1        (✅ Works - Returns Maysha)
       curl http://localhost:5000/users/hello    (❌ 404 Not Found - because it's not a number)

    2. Test 'alpha' constraint:
       curl http://localhost:5000/users/search/Sony    (✅ Works - Returns Sony)
       curl http://localhost:5000/users/search/Sony123 (❌ 404 Not Found - contains numbers)
       
    3. Test 'range' constraint:
       curl http://localhost:5000/users/adults/25   (✅ Works - Returns Maysha)
       curl http://localhost:5000/users/adults/17   (❌ 404 Not Found - less than 18)
       
    4. Test 'multiple' constraints:
       curl http://localhost:5000/users/pin/9999 (✅ Works - Returns Marium)
       curl http://localhost:5000/users/pin/99   (❌ 404 Not Found - not 4 digits)

    5. Test 'regex' constraint:
       curl http://localhost:5000/users/email/sony@test.com  (✅ Works - Returns Sony)
       curl http://localhost:5000/users/email/sonytest.com   (❌ 404 Not Found - Missing @ symbol)
       curl http://localhost:5000/users/email/sony@test      (❌ 404 Not Found - Missing .com part)
*/
