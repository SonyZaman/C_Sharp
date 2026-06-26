// 148. Returning HTML and Files
/*
    NEW CONCEPT: Results.Content() and Results.File()
    
    We learned how to return Plain Text (146) and JSON (147).
    But what if you want to return a raw HTML page? Or a File download (like a PDF or image)?
    
    You can use the built-in `Results` static class to return almost any type of content!
    
    1. Results.Content(string content, string contentType)
       Lets you return a string, but specify EXACTLY what format it is (like "text/html" for web pages).
       
    2. Results.File(string filePath, string contentType, string fileDownloadName)
       Reads a file from the server's hard drive and sends it to the user as a download.
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// 1. Returning HTML using Results.Content
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/html", () => 
{
    string htmlString = @"
        <html>
            <head><title>My HTML Page</title></head>
            <body style='font-family: Arial; text-align: center; margin-top: 50px;'>
                <h1 style='color: blue;'>Hello from ASP.NET Core!</h1>
                <p>This is a real HTML page returned directly from an API endpoint.</p>
            </body>
        </html>";

    // We explicitly tell the browser: "This is HTML, so render it as a web page!"
    return Results.Content(htmlString, "text/html");
});


// ─────────────────────────────────────────────────────────────────────────
// 2. Returning a File using Results.File
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/download", () =>
{
    // Make sure you have a file named 'sample.txt' in the same folder!
    string filePath = "sample.txt";

    // If the file doesn't exist, we can't return it!
    if (!System.IO.File.Exists(filePath))
    {
        return Results.NotFound("The file was not found on the server.");
    }

    // Results.File automatically reads the file and streams it to the user.
    // "text/plain" is the MIME type (what kind of file it is).
    // "downloaded_sample.txt" is the name the user will see when it saves to their computer.
    return Results.File(System.IO.Path.GetFullPath(filePath), "text/plain", "downloaded_sample.txt");
});

app.Run();

/*
    HOW TO TEST:
    1. Run: dotnet run
    2. Open browser:
       → http://localhost:5000/html
         (You will see a beautifully rendered HTML page with a blue heading!)
       → http://localhost:5000/download
         (Your browser will immediately download a file named 'downloaded_sample.txt'!)
*/
