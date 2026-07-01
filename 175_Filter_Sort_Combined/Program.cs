// 175. GET with Filter + Sort Combined
/*
    NEW CONCEPT: Chaining LINQ Methods
    
    You have learned `.Where()` to filter (Project 172).
    You have learned `.OrderBy()` to sort (Project 174).
    
    But what if a user wants BOTH at the same time?
    Example: "Give me all users from Dhaka, AND sort them alphabetically by Name!"
    
    The true power of LINQ is that you can "chain" methods together.
    You just put a dot after the first method and call the next one!
    
    Example:
    Db.Users
      .Where(u => u.City == "Dhaka")   // 1. First, keep only Dhaka users
      .OrderBy(u => u.Name)            // 2. Then, sort those remaining users
      .ToList();                       // 3. Finally, return as a List
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
        new User { Id = 1, Name = "Zaman",   Age = 25, City = "Dhaka" },
        new User { Id = 2, Name = "Maysha",  Age = 21, City = "Dhaka" },
        new User { Id = 3, Name = "Sony",    Age = 22, City = "Chittagong" },
        new User { Id = 4, Name = "Marium",  Age = 20, City = "Dhaka" },
        new User { Id = 5, Name = "Rasel",   Age = 28, City = "Chittagong" }
    };
}

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 2. GET ALL (No Filter, No Sort)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    return Results.Ok(Db.Users);
});

// ─────────────────────────────────────────────────────────────────────────
// 3. GET — Filter AND Sort Combined!
// We use Optional Parameters (Project 166) for `city` and `sortBy`
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/search", (string? city, string? sortBy) =>
{
    // Start with all users
    // (We use IEnumerable here because we haven't called .ToList() yet)
    IEnumerable<User> query = Db.Users;

    // 1. Apply Filter (if user provided a city)
    if (!string.IsNullOrWhiteSpace(city))
    {
        query = query.Where(u => u.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }

    // 2. Apply Sort (if user provided a sortBy)
    if (sortBy?.ToLower() == "name")
    {
        query = query.OrderBy(u => u.Name);
    }
    else if (sortBy?.ToLower() == "age")
    {
        query = query.OrderBy(u => u.Age);
    }

    // 3. Finally, execute the query and turn it into a List!
    var result = query.ToList();

    if (result.Count == 0)
        return Results.NotFound(new { Message = "No users matched your search." });

    return Results.Ok(new { Message = "Search successful", Users = result });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then try these powerful combinations!
    
    1. Only Filter:
       curl "http://localhost:5000/users/search?city=Dhaka"
       (Returns: Zaman, Maysha, Marium — unsorted)
       
    2. Only Sort:
       curl "http://localhost:5000/users/search?sortBy=age"
       (Returns everyone, from youngest to oldest: Marium, Maysha, Sony, Zaman, Rasel)
       
    3. FILTER AND SORT COMBINED! 🔥
       curl "http://localhost:5000/users/search?city=Dhaka&sortBy=name"
       (Returns ONLY Dhaka users, sorted A-Z: Marium, Maysha, Zaman)
*/
