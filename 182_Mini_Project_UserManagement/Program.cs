// 182. Mini Project: Complete User Management API
/*
    GRADUATION PROJECT! 🎓
    
    Look at the left side of your IDE. Notice the folder structure?
    - Data/Db.cs
    - DTOs/UserDtos.cs
    - Endpoints/UserEndpoints.cs
    - Models/User.cs
    
    This is what a real, professional .NET project looks like.
    Because we organized everything into folders, Program.cs is only 4 lines long,
    and yet it powers a complete, validated, secure CRUD API!
*/

using MiniProject.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapUserEndpoints();

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. GET ALL (With cool LINQ filtering!):
       curl "http://localhost:5000/users?search=sony"
       
    2. CREATE (With MiniValidation!):
       curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name": "Zaman", "Email": "zaman@test.com", "SecretPassword": "password123"}'
       
    3. The rest of the endpoints (GET by ID, PUT, DELETE) all work perfectly too!
*/
