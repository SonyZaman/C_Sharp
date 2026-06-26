// 159. Parameter Binding Attributes ([FromBody], [FromRoute], etc.)
/*
    NEW CONCEPT: Explicit Parameter Binding
    
    In previous projects, ASP.NET Core "guessed" where data came from.
    While ASP.NET Core is smart, guessing can sometimes lead to bugs. 
    Professional developers often use EXPLICIT ATTRIBUTES to tell the API 
    EXACTLY where the data must come from.
    
    1. [FromRoute]  -> Must come from the URL path
    2. [FromQuery]  -> Must come from the URL query string
    3. [FromHeader] -> Must come from HTTP Headers
    4. [FromBody]   -> Must come from the JSON Body
*/

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Data Model & Fake Database
// ─────────────────────────────────────────────────────────────────────────
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public static class Db
{
    public static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Mouse", Price = 49.99m },
        new Product { Id = 3, Name = "Keyboard", Price = 89.99m }
    };
    public static int NextId = 4;
}

// ─────────────────────────────────────────────────────────────────────────
// 2. [FromRoute] - Explicitly binding from the URL Path
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/products/route/{id}", ([FromRoute] int id) => 
{
    var product = Db.Products.FirstOrDefault(p => p.Id == id);
    if (product == null) return Results.NotFound(new { Message = $"[FromRoute] Product ID {id} not found." });

    return Results.Ok(new { Message = $"[FromRoute] Product ID found", Product = product });
});

// ─────────────────────────────────────────────────────────────────────────
// 3. [FromQuery] - Explicitly binding from the URL Query String
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/products/search", ([FromQuery] string searchTerm) => 
{
    var products = Db.Products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    
    if (products.Count == 0) return Results.NotFound(new { Message = $"[FromQuery] No products found for: {searchTerm}" });

    return Results.Ok(new { Message = $"[FromQuery] Products found for: {searchTerm}", Products = products });
});

// ─────────────────────────────────────────────────────────────────────────
// 4. [FromHeader] - Explicitly binding from HTTP Headers
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/products/secure", ([FromHeader(Name = "X-Api-Key")] string apiKey) => 
{
    if (apiKey != "SecretKey123")
    {
        return Results.Unauthorized(); // 401 if wrong key
    }
    
    return Results.Ok(new { Message = "[FromHeader] API Key accepted! Access granted.", Products = Db.Products });
});

// ─────────────────────────────────────────────────────────────────────────
// 5. [FromBody] - Explicitly binding from the JSON Body
// ─────────────────────────────────────────────────────────────────────────
app.MapPost("/products/add", ([FromBody] Product newProduct) => 
{
    newProduct.Id = Db.NextId++;
    Db.Products.Add(newProduct);

    return Results.Ok(new 
    { 
        Message = "[FromBody] Product successfully added to DB!",
        ProductData = newProduct
    });
});

app.Run();

/*
    HOW TO TEST (run `dotnet run` in one terminal, and these in another):
    
    1. Test [FromRoute]:
       curl http://localhost:5000/products/route/1
       
    2. Test [FromQuery]:
       curl "http://localhost:5000/products/search?searchTerm=Laptop"
       
    3. Test [FromHeader] (Good Key):
       curl http://localhost:5000/products/secure -H "X-Api-Key: SecretKey123"
       
    4. Test [FromHeader] (Bad Key):
       curl http://localhost:5000/products/secure -H "X-Api-Key: WrongKey"
       
    5. Test [FromBody]:
       curl -X POST http://localhost:5000/products/add \
            -H "Content-Type: application/json" \
            -d '{"Name": "Gaming Monitor", "Price": 299.99}'

    6. Verify [FromBody] (Check if it was added):
       curl http://localhost:5000/products/route/4
*/
