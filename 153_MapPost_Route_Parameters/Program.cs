// 153. MapPost with Route Parameters
/*
    NEW CONCEPT: Using POST with a Route Parameter {id}
    
    You can combine MapPost (receiving a JSON body) with Route Parameters!
    
    Why would you do this?
    Imagine an API to add a comment to a specific blog post.
    The URL tells you WHICH blog post (Route Parameter).
    The Body tells you WHAT the comment says (JSON Body).
    
    Example URL: POST /blogs/99/comments
    Body: { "Text": "Great article!" }
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

public class Comment
{
    public string Text { get; set; }
    public string Author { get; set; }
}

// ─────────────────────────────────────────────────────────────────────────
// NEW CONCEPT: Combining Route Parameter (int blogId) with Body (Comment newComment)
// ─────────────────────────────────────────────────────────────────────────
app.MapPost("/blogs/{blogId}/comments", (int blogId, Comment newComment) => 
{
    Console.WriteLine($"[SERVER] Adding comment to Blog #{blogId}");
    Console.WriteLine($"[SERVER] Comment text: {newComment.Text}");
    
    return Results.Ok(new 
    { 
        Message = $"Comment successfully added to Blog #{blogId}!", 
        AddedComment = newComment 
    });
});

app.Run();

/*
    HOW TO TEST (Using cURL in a new terminal):
    
    curl -X POST http://localhost:5000/blogs/42/comments \
         -H "Content-Type: application/json" \
         -d '{"Text": "This is a fantastic blog post!", "Author": "SonyZaman"}'
*/
