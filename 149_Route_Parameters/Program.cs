// 149. Route Parameters (Dynamic URLs)
/*
    NEW CONCEPT: Route Parameters {id}
    
    Until now, our URLs were "static" (fixed). 
    If we mapped "/user", it only responded to exactly "/user".
    
    But in real APIs, URLs are "dynamic". 
    Example: To get user 101, you request: /users/101
    
    How do we tell ASP.NET Core that the "101" part is a variable?
    We use curly braces in the route string: "/users/{id}"
    
    Then, we just add `int id` as a parameter to our Lambda function, 
    and ASP.NET Core will automatically extract the "101" from the URL 
    and pass it into our function! This is called "Model Binding".
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: {id} in the route, and `int id` in the Lambda
// ─────────────────────────────────────────────────────────────────────────

// 1. Single Route Parameter
app.MapGet("/users/{id}", (int id) => 
{
    // ASP.NET automatically pulled the 'id' from the URL!
    return Results.Ok(new 
    { 
        Message = $"You requested User ID: {id}",
        Found = true 
    });
});

// 2. Multiple Route Parameters
// Example URL: /products/electronics/item/42
app.MapGet("/products/{category}/item/{itemId}", (string category, int itemId) => 
{
    return Results.Ok(new 
    { 
        Category = category, 
        ProductID = itemId,
        Status = "In Stock"
    });
});

app.Run();

/*
         Notice what happens if you type letters where a number belongs:
       → http://localhost:5000/users/abc
         (ASP.NET Core automatically returns a 400 Bad Request error because 
          "abc" cannot be converted into an 'int'!)
*/
