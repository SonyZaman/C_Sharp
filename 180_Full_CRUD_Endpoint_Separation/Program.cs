// 180. Full CRUD: Endpoint Separation + LINQ + DTOs
/*
    MILESTONE: Endpoint Separation
    
    Look at how beautiful and clean this Program.cs file is!
    Because we used an Extension Method in `UserEndpoints.cs`,
    our entire API fits in just 4 lines of code here.
    
    This is EXACTLY how professional Minimal APIs are structured.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ONE LINE to map all 5 CRUD endpoints!
app.MapUserEndpoints();

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    It works exactly like 178 and 179!
    
    1. GET ALL:    curl http://localhost:5000/users
    2. GET ONE:    curl http://localhost:5000/users/1
    3. CREATE:     curl -X POST http://localhost:5000/users -H "Content-Type: application/json" -d '{"Name":"Zaman","Email":"zaman@test.com","SecretPassword":"123"}'
    4. UPDATE:     curl -X PUT http://localhost:5000/users/1 -H "Content-Type: application/json" -d '{"Name":"Sony Updated","Email":"sony@new.com"}'
    5. DELETE:     curl -X DELETE http://localhost:5000/users/1
*/
