// 190. Pagination using LINQ .Skip() and .Take()
/*
    NEW CONCEPT: Pagination
    
    Imagine your API has 10,000 users in the database.
    If someone calls `GET /users`, you cannot return all 10,000 at once!
    That would be extremely slow and would crash both the server and the client.
    
    The solution is PAGINATION: returning a small "page" of results at a time.
    
    Example: "Give me Page 1 (items 1-10), Page 2 (items 11-20), Page 3 (21-30)..."
    
    LINQ provides exactly two methods to do this:
    - `.Skip(n)`: Skip the first `n` items.
    - `.Take(n)`: Take the next `n` items.
    
    FORMULA:
    Skip = (pageNumber - 1) * pageSize
    Take = pageSize
    
    Example: Page 2 with 5 items per page:
    Skip = (2 - 1) * 5 = 5   → Skip the first 5 items
    Take = 5                  → Take the next 5 items
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 1. GET ALL with Pagination
// Query params: ?page=1&pageSize=3
// ─────────────────────────────────────────────────────────────────────────
usersGroup.MapGet("/", (int page = 1, int pageSize = 3) =>
{
    // Guard against bad values
    if (page < 1) page = 1;
    if (pageSize < 1) pageSize = 3;
    if (pageSize > 20) pageSize = 20; // Never allow more than 20 per page!

    var totalCount = Db.Users.Count;
    var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

    // THE MAGIC:
    // Skip = how many items to jump over
    // Take = how many items to grab after the skip
    var pagedUsers = Db.Users
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return Results.Ok(new PagedResult<User>
    {
        Page        = page,
        PageSize    = pageSize,
        TotalCount  = totalCount,
        TotalPages  = totalPages,
        Data        = pagedUsers
    });
});

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// 2. Classes (at the bottom — C# 9+ rule!)
// ─────────────────────────────────────────────────────────────────────────

// Generic Paged Result Wrapper (reusable for any type!)
public class PagedResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public List<T> Data { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class Db
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1,  Name = "Sony"     },
        new User { Id = 2,  Name = "Maysha"   },
        new User { Id = 3,  Name = "Zaman"    },
        new User { Id = 4,  Name = "Marium"   },
        new User { Id = 5,  Name = "Rasel"    },
        new User { Id = 6,  Name = "Rima"     },
        new User { Id = 7,  Name = "Karim"    },
        new User { Id = 8,  Name = "Sumaiya"  },
        new User { Id = 9,  Name = "Fahim"    },
        new User { Id = 10, Name = "Tania"    }
    };
}

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. PAGE 1 (Default — first 3 users):
       curl "http://localhost:5000/users"
       → Returns: Sony, Maysha, Zaman
       
    2. PAGE 2 (Next 3 users):
       curl "http://localhost:5000/users?page=2&pageSize=3"
       → Returns: Marium, Rasel, Rima
       
    3. PAGE 3 (Next 3 users):
       curl "http://localhost:5000/users?page=3&pageSize=3"
       → Returns: Karim, Sumaiya, Fahim
       
    4. PAGE 4 (Last page — only 1 user left):
       curl "http://localhost:5000/users?page=4&pageSize=3"
       → Returns: Tania
       
    NOTICE the response also tells you:
    - totalCount: 10 (total users in the database)
    - totalPages: 4 (how many pages exist)
    - page: which page you are currently on
    
    This is EXACTLY how every major API (GitHub, Twitter, etc.) works!
*/
