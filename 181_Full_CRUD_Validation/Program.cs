// 181. Full CRUD: Validation Constraints + LINQ + DTOs
/*
    MILESTONE: Automatic Validation
    
    This is EXACTLY the same as Project 180, but we added `MiniValidation`.
    
    Instead of manually checking `if (string.IsNullOrWhiteSpace(input.Name))` 
    in our endpoints, we just added `[Required]` to our DTOs!
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapUserEndpoints();

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    Try to CREATE a user with missing or invalid data:
    curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "", "Email": "not-an-email"}'
    
    Notice how it automatically returns a 400 Bad Request with all the errors!
*/
