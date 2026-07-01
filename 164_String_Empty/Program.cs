// 164. String Empty vs string.IsNullOrEmpty
/*
    NEW CONCEPT: What is string.Empty?
    
    
    1. `string.Empty` is exactly the same as typing `""`. 
       It just means a blank string.
       
    2. Why do we write `public string Name { get; set; } = string.Empty;`?
       If you don't do this, the default value of a string is `null`.
       By setting it to `string.Empty`, you ensure the string is never `null` by default, 
       which prevents your app from crashing with a "Null Reference Exception".
       
    3. `string.IsNullOrEmpty()` is a METHOD that checks if a string is `null` OR `string.Empty` ("").
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

public class User
{
    // Setting a default value so Name is NEVER null!
    // This is the exact same thing as writing: = "";
    public string Name { get; set; } = string.Empty; 
}

app.MapPost("/users/check-empty", (User newUser) => 
{
    // Because we used '= string.Empty;' in the class above, 
    // if the user doesn't send a Name, it will be "" (string.Empty), not null!

    if (newUser.Name == string.Empty)
    {
        return Results.BadRequest(new { Error = "Name is string.Empty (blank)!" });
    }
    
    // Better way to check (also catches if they send "   " spaces)
    if (string.IsNullOrWhiteSpace(newUser.Name))
    {
        return Results.BadRequest(new { Error = "Name cannot be blank or just spaces!" });
    }
    
    return Results.Ok(new { Message = $"Success! Your name is: '{newUser.Name}'" });
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run`. 
    
    1. Send a request with NO name (It will use our default string.Empty):
       curl -X POST http://localhost:5000/users/check-empty -H "Content-Type: application/json" -d '{}'
       
    2. Send a request with just spaces (Caught by IsNullOrWhiteSpace):
       curl -X POST http://localhost:5000/users/check-empty -H "Content-Type: application/json" -d '{"Name": "    "}'
*/
