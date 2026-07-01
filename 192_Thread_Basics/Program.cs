// 192. Thread Basics
/*
    NEW CONCEPT: What is a Thread?
    
    REAL WORLD ANALOGY:
    Imagine a restaurant kitchen with ONE chef (= one thread).
    
    A customer orders food. The chef starts cooking.
    While the chef is waiting for water to boil (= waiting for database),
    the chef just STANDS THERE doing nothing.
    
    No other customer can be served! The chef is "blocked".
    
    This is exactly what happens in a computer program.
    Program has a "thread" — a single worker that executes your code.
    When the thread is waiting (for a file, database, network), it blocks everything.
    
    ─────────────────────────────────────────────────────────────────────
    WHAT IS Thread.Sleep(milliseconds)?
    
    It literally forces the thread to STOP and do NOTHING for that many milliseconds.
    It is used to SIMULATE a slow operation (like a database query or API call).
    
    2000 milliseconds = 2 seconds of doing nothing.
    ─────────────────────────────────────────────────────────────────────
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// EXAMPLE 1: A Fast Endpoint (No Waiting)
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/fast", () =>
{
    // No waiting — thread does the work instantly
    var result = $"Fast response! Thread finished at: {DateTime.Now:T}";
    Console.WriteLine($"[FAST] Done at {DateTime.Now:T}");
    return Results.Ok(result);
});

// ─────────────────────────────────────────────────────────────────────────
// EXAMPLE 2: A Slow Endpoint using Thread.Sleep (BLOCKING)
// Thread.Sleep = "make this thread stand still and do NOTHING"
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/slow", () =>
{
    Console.WriteLine($"[SLOW] Starting at {DateTime.Now:T}... thread is now BLOCKED!");

    // This simulates a slow database call that takes 3 seconds
    // While this runs, the thread cannot do ANYTHING else
    Thread.Sleep(3000);  // 3000 milliseconds = 3 seconds of doing nothing!

    Console.WriteLine($"[SLOW] Done at {DateTime.Now:T}");
    return Results.Ok($"Slow response (blocked for 3 seconds)! Done at: {DateTime.Now:T}");
});

// ─────────────────────────────────────────────────────────────────────────
// EXAMPLE 3: Thread Info — See what thread number is handling requests
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/thread-info", () =>
{
    var threadId = Thread.CurrentThread.ManagedThreadId;
    var info = $"Your request was handled by Thread #{threadId}";
    Console.WriteLine($"[THREAD INFO] {info}");
    return Results.Ok(info);
});

app.Run();

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. FAST endpoint:
       curl http://localhost:5000/fast
       → Responds instantly!
       
    2. SLOW endpoint (Thread.Sleep — BLOCKS!):
       curl http://localhost:5000/slow
       → Takes 3 full seconds before responding.
       → Watch the terminal — see how it prints "BLOCKED!" then waits, then "Done"
       
    3. THREAD INFO:
       curl http://localhost:5000/thread-info
       curl http://localhost:5000/thread-info
       curl http://localhost:5000/thread-info
       → You might see different thread numbers each time!
       
    ─────────────────────────────────────────────────────────────────────
    THE PROBLEM WITH THREAD.SLEEP IN APIS:
    
    Open 2 terminals. Run this in BOTH at the same time:
    Terminal 1: curl http://localhost:5000/slow
    Terminal 2: curl http://localhost:5000/fast  ← Try this while Terminal 1 waits!
    
    Notice: Terminal 2 ALSO gets delayed! Because the thread is BLOCKED by Terminal 1.
    This is the problem. ONE slow request can hold up everyone else!
    
    In Project 193, we will learn about Tasks which is the solution to this problem.
    ─────────────────────────────────────────────────────────────────────
*/
