// 172. GET with Filter: LINQ .Where()
/*
    NEW CONCEPT: LINQ .Where() for Filtering
    
    In Project 171, we filtered a list manually using a foreach loop + if statement.
    This project does the EXACT SAME THING using LINQ .Where().
    
    The results are 100% identical. LINQ .Where() is just doing the foreach + if for you!
    
    COMPARISON (filtering by city):
    
    ── Manual (171 style) ──────────────────────────────────────────────
    var result = new List<User>();
    foreach (var user in Db.Users)
    {
        if (user.City.Equals(city, StringComparison.OrdinalIgnoreCase))
        {
            result.Add(user);
        }
    }
    
    ── LINQ .Where() (172 style) ───────────────────────────────────────
    var result = Db.Users
        .Where(u => u.City.Equals(city, StringComparison.OrdinalIgnoreCase))
        .ToList();
    
    Both give the same result! .Where() is just shorter and cleaner.
    The `u =>` is a Lambda — it represents each user as LINQ loops through them.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model & Fake Database (exact same as Project 171)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Maysha",  Age = 21, City = "Dhaka" },
        new User { Id = 2, Name = "Sony",    Age = 22, City = "Chittagong" },
        new User { Id = 3, Name = "Marium",  Age = 21, City = "Dhaka" },
        new User { Id = 4, Name = "Zaman",   Age = 23, City = "Sylhet" },
        new User { Id = 5, Name = "Rasel",   Age = 22, City = "Dhaka" }
    };
}

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 2. GET ALL (No Filter)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    return Results.Ok(Db.Users);
});

// ─────────────────────────────────────────────────────────────────────────
// 3. GET — Filter by City using LINQ .Where()
// URL Example: /users/filter/city?city=Dhaka
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/filter/city", (string city) =>
{
    // ONE LINE replaces the entire foreach + if from Project 171!
    // .Where() loops through every user and keeps only the ones matching the condition.
    // .ToList() converts the result back into a regular List.
    var result = Db.Users
        .Where(u => u.City.Equals(city, StringComparison.OrdinalIgnoreCase))
        .ToList();

    if (result.Count == 0)
        return Results.NotFound(new { Message = $"No users found in city: {city}" });

    return Results.Ok(new { Message = $"Users in {city}", Users = result });
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET — Filter by Age using LINQ .Where()
// URL Example: /users/filter/age?age=21
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/filter/age", (int age) =>
{
    var result = Db.Users
        .Where(u => u.Age == age)
        .ToList();

    if (result.Count == 0)
        return Results.NotFound(new { Message = $"No users found with age: {age}" });

    return Results.Ok(new { Message = $"Users aged {age}", Users = result });
});

app.Run();

/*
    HOW TO TEST:
    
    The test commands are IDENTICAL to Project 171 — the results will be the same!
    
    Run `dotnet run` in the terminal, then try:
    
    1. GET ALL:
       curl http://localhost:5000/users
       
    2. FILTER by City:
       curl "http://localhost:5000/users/filter/city?city=Dhaka"
       (Returns Maysha, Marium, Rasel — same as project 171!)
       
       curl "http://localhost:5000/users/filter/city?city=Sylhet"
       (Returns only Zaman — same as project 171!)
       
    3. FILTER by Age:
       curl "http://localhost:5000/users/filter/age?age=21"
       (Returns Maysha and Marium — same as project 171!)
       
    The output is EXACTLY the same as 171. LINQ .Where() just replaced the loop!
*/
