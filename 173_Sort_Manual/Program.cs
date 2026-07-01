// 173. GET with Sort: Manual
/*
    NEW CONCEPT: Sorting a List Manually
    
    Sometimes you want your API to return data in a specific order, 
    like sorting users alphabetically by Name, or by Age from youngest to oldest.
    
    Before LINQ, sorting required using the built-in `List.Sort()` method.
    `Sort()` takes a comparison function that tells C# how to compare two users (User A and User B).
    
    Important Note: `Sort()` modifies the original list! 
    Because we don't want to accidentally change our Fake Database order forever, 
    we first make a COPY of the list, and then sort the copy.
    
    In Project 174, we will learn how LINQ `.OrderBy()` makes this much easier and safer!
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
// 2. GET ALL (Unsorted) — Returns the default database order
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", () =>
{
    return Results.Ok(Db.Users);
});

// ─────────────────────────────────────────────────────────────────────────
// 3. GET — Sort by Name (Ascending A-Z) using manual List.Sort()
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/sort/name-asc", () =>
{
    // Step 1: Create a brand new list that is a COPY of our database.
    // If we sort Db.Users directly, it will change the database forever!
    var sortedList = new List<User>(Db.Users);

    // Step 2: Use manual List.Sort() with a comparison function
    // string.Compare(a, b) sorts A to Z.
    sortedList.Sort((userA, userB) => string.Compare(userA.Name, userB.Name, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(new { Message = "Sorted A-Z", Users = sortedList });
});

// ─────────────────────────────────────────────────────────────────────────
// 4. GET — Sort by Name (Descending Z-A) using manual List.Sort()
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/sort/name-desc", () =>
{
    var sortedList = new List<User>(Db.Users);

    // To sort Z-A, we just flip userB and userA inside string.Compare!
    // string.Compare(b, a) sorts Z to A.
    sortedList.Sort((userA, userB) => string.Compare(userB.Name, userA.Name, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(new { Message = "Sorted Z-A", Users = sortedList });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal, then try:
    
    1. UNSORTED (Original Order: Zaman, Maysha, Sony, Marium):
       curl http://localhost:5000/users
       
    2. SORTED A-Z (Marium, Maysha, Sony, Zaman):
       curl http://localhost:5000/users/sort/name-asc
       
    3. SORTED Z-A (Zaman, Sony, Maysha, Marium):
       curl http://localhost:5000/users/sort/name-desc
       
    NOTICE: Manual sorting requires making a copy of the list and writing 
    complex `string.Compare` logic. In Project 174, LINQ will solve this perfectly!
*/
