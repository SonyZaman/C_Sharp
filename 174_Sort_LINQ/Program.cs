// 174. GET with Sort: LINQ .OrderBy()
/*
    NEW CONCEPT: Sorting with LINQ
    
    In Project 173, we manually sorted a list. It was a lot of work! 
    We had to copy the list and write complex `string.Compare` functions.
    
    In this project, we use LINQ to do the exact same thing in just ONE line.
    
    COMPARISON (Sorting A-Z):
    
    ── Manual (173 style) ──────────────────────────────────────────────
    var sortedList = new List<User>(Db.Users);
    sortedList.Sort((userA, userB) => string.Compare(userA.Name, userB.Name));
    
    ── LINQ .OrderBy() (174 style) ─────────────────────────────────────
    var sortedList = Db.Users.OrderBy(u => u.Name).ToList();
    
    LINQ `.OrderBy()` automatically creates a new list (so it's safe for your database) 
    and handles all the comparison logic for you automatically!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model & Fake Database (exact same as Project 173)
// ─────────────────────────────────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Zaman",  Age = 23 },
        new User { Id = 2, Name = "Maysha", Age = 21 },
        new User { Id = 3, Name = "Sony",   Age = 22 },
        new User { Id = 4, Name = "Marium", Age = 20 }
    };
}

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 2. GET ALL (Unsorted)
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    return Results.Ok(Db.Users);
});

// ─────────────────────────────────────────────────────────────────────────
// 3. GET — Sort by Name (Ascending A-Z) using LINQ .OrderBy()
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/sort/name-asc", () =>
{
    // ONE LINE replaces the copy + manual string.Compare from Project 173!
    // .OrderBy() loops through and sorts them A-Z automatically.
    var sortedList = Db.Users
        .OrderBy(u => u.Name)
        .ToList();

    return Results.Ok(new { Message = "Sorted A-Z (using LINQ)", Users = sortedList });
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET — Sort by Name (Descending Z-A) using LINQ .OrderByDescending()
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/sort/name-desc", () =>
{
    // Want Z-A? Just use .OrderByDescending() instead!
    var sortedList = Db.Users
        .OrderByDescending(u => u.Name)
        .ToList();

    return Results.Ok(new { Message = "Sorted Z-A (using LINQ)", Users = sortedList });
});

app.Run();

/*
    HOW TO TEST:
    
    The test commands are IDENTICAL to Project 173 — the results will be the same!
    
    Run `dotnet run` in the terminal, then try:
    
    1. UNSORTED (Original Order: Zaman, Maysha, Sony, Marium):
       curl http://localhost:5000/users
       
    2. SORTED A-Z (Marium, Maysha, Sony, Zaman):
       curl http://localhost:5000/users/sort/name-asc
       
    3. SORTED Z-A (Zaman, Sony, Maysha, Marium):
       curl http://localhost:5000/users/sort/name-desc
       
    The output is EXACTLY the same as 173. LINQ just saved us from writing a lot of code!
*/
