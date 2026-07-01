// 186. Centralized API Response Wrapper
/*
    NEW CONCEPT: ApiResponse<T> Wrapper
    
    Enterprise APIs standardise their responses. 
    Frontend developers hate when one endpoint returns `{"id": 1, "name": "Sony"}` 
    and another returns `{"error": "User not found"}`. The structure is different!
    
    We fix this by creating a GENERIC wrapper class called `ApiResponse<T>`.
    Every single endpoint will return this exact same shape, whether it succeeds or fails.
    
    Notice the `<T>`? That is a C# Generic. It means "The data inside can be anything 
    (a User, a List of Users, a string), but the wrapper around it is always the same."
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var usersGroup = app.MapGroup("/users");

// ─────────────────────────────────────────────────────────────────────────
// 1. Endpoints using the Wrapper
// ─────────────────────────────────────────────────────────────────────────

// GET ALL
usersGroup.MapGet("/", () =>
{
    // Instead of returning the list directly, we WRAP it!
    var response = ApiResponse<List<User>>.Success(Db.Users, "Users retrieved successfully.");
    return Results.Ok(response);
});

// GET BY ID
usersGroup.MapGet("/{id:int}", (int id) =>
{
    var user = Db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null) 
    {
        var errorResponse = ApiResponse<User>.Failure(new List<string> { $"User with ID {id} not found." }, "Not Found");
        return Results.NotFound(errorResponse);
    }

    // Wrap the single user!
    var response = ApiResponse<User>.Success(user, "User found.");
    return Results.Ok(response);
});

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// 2. Classes (Must be at bottom of file in C# 9+)
// ─────────────────────────────────────────────────────────────────────────

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }           // Generics! Can be one User, or a List<User>!
    public List<string> Errors { get; set; } 

    // Helper method for Success
    public static ApiResponse<T> Success(T data, string message = "Success")
    {
        return new ApiResponse<T>
        {
            IsSuccess = true,
            Message = message,
            Data = data,
            Errors = null
        };
    }

    // Helper method for Failure
    public static ApiResponse<T> Failure(List<string> errors, string message = "Validation Failed")
    {
        return new ApiResponse<T>
        {
            IsSuccess = false,
            Message = message,
            Data = default, // null
            Errors = errors
        };
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class Db
{
    public static int NextId = 3;
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony" },
        new User { Id = 2, Name = "Maysha" }
    };
}


/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. GET ALL USERS (Notice the beautiful standard format!):
       curl http://localhost:5000/users
       
       Output:
       {
         "isSuccess": true,
         "message": "Users retrieved successfully.",
         "data": [ {"id":1,"name":"Sony"}, {"id":2,"name":"Maysha"} ],
         "errors": null
       }
       
    2. GET INVALID USER (Notice the exact same format, even for errors!):
       curl http://localhost:5000/users/99
       
       Output:
       {
         "isSuccess": false,
         "message": "Not Found",
         "data": null,
         "errors": [ "User with ID 99 not found." ]
       }
*/
