// 171. GET with Filter: Manual (foreach + if)
/*
    NEW CONCEPT: Filtering a List Manually
    
    So far, GET All always returned every single user in the database.
    
    In real APIs, users need to FILTER the results.
    Example: "Give me only users from Dhaka" or "Give me only users who are 22 years old."
    
    In this project, we filter manually using the basic tools you already know:
    - A `foreach` loop to go through every user
    - An `if` statement to check if the user matches the filter
    - A new empty list to collect the matching results
    
    In the NEXT project (172), we will do the exact same thing using LINQ .Where().
    For now, we do it the "manual" way so you understand what is happening step by step.
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
// 2. GET ALL (No Filter) — Returns everyone
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    return Results.Ok(Db.Users);
});

// ─────────────────────────────────────────────────────────────────────────
// 3. GET — Filter by City (Manual foreach + if)
// URL Example: /users/filter/city?city=Dhaka
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/filter/city", (string city) =>
{
    // Step 1: Create an empty list to hold the matching results
    var result = new List<User>();

    // Step 2: Loop through every single user in the database
    foreach (var user in Db.Users)
    {
        // Step 3: Check if this user's City matches the filter
        if (user.City.Equals(city, StringComparison.OrdinalIgnoreCase))
        {
            // Step 4: If it matches, add it to the result list
            result.Add(user);
        }
    }

    // Step 5: If no users were found, return 404
    if (result.Count == 0)
        return Results.NotFound(new { Message = $"No users found in city: {city}" });

    return Results.Ok(new { Message = $"Users in {city}", Users = result });
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET — Filter by Age (Manual foreach + if)
// URL Example: /users/filter/age?age=21
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/filter/age", (int age) =>
{
    // Step 1: Create an empty list for results
    var result = new List<User>();

    // Step 2: Loop through every user
    foreach (var user in Db.Users)
    {
        // Step 3: Check if age matches
        if (user.Age == age)
        {
            result.Add(user);
        }
    }

    if (result.Count == 0)
        return Results.NotFound(new { Message = $"No users found with age: {age}" });

    return Results.Ok(new { Message = $"Users aged {age}", Users = result });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then try:
    
    1. GET ALL (no filter):
       curl http://localhost:5000/users
       
    2. FILTER by City:
       curl "http://localhost:5000/users/filter/city?city=Dhaka"
       (Returns Maysha, Marium, Rasel)
       
       curl "http://localhost:5000/users/filter/city?city=Sylhet"
       (Returns only Zaman)
       
       curl "http://localhost:5000/users/filter/city?city=London"
       (Returns 404 - No users found)
       
    3. FILTER by Age:
       curl "http://localhost:5000/users/filter/age?age=21"
       (Returns Maysha and Marium)
       
       curl "http://localhost:5000/users/filter/age?age=22"
       (Returns Sony and Rasel)
       
    NOTICE: This is exactly what LINQ .Where() does automatically!
    In Project 172, we will replace the foreach + if with one simple line.
*/
