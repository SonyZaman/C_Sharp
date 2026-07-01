// 193. Task Basics
/*
    NEW CONCEPT: What is a Task?
    
    In Project 192, we saw the PROBLEM: Thread.Sleep() BLOCKS the thread.
    ONE slow request stops everyone else.
    
    The SOLUTION is a Task.
    
    REAL WORLD ANALOGY:
    Imagine the same restaurant kitchen, but now the chef is smarter.
    When the chef puts food in the oven (= starts a slow database call),
    instead of standing still, the chef says:
    "Oven, call me when you're done!" and goes to serve another customer.
    
    When the oven beeps (= database responds), the chef comes back and finishes the dish.
    
    A TASK is the "promise" that some work will be completed in the future.
    It does NOT block the thread while waiting.
    
    ─────────────────────────────────────────────────────────────────────
    KEY TYPES:
    
    Task           = a promise to do some work (no return value)
    Task<string>   = a promise to do work AND return a string when done
    Task<List<User>> = a promise to return a List<User> when done
    
    ─────────────────────────────────────────────────────────────────────
    KEY METHODS:
    
    Task.Delay(ms)         = wait for ms milliseconds WITHOUT blocking the thread
    Task.Run(() => ...)    = run some work on a background thread
    Task.WhenAll(t1, t2)   = wait for MULTIPLE tasks to finish
    Task.WhenAny(t1, t2)   = wait for WHICHEVER task finishes first
    ─────────────────────────────────────────────────────────────────────
*/

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─────────────────────────────────────────────────────────────────────────
// EXAMPLE 1: Task.Delay — Non-blocking wait
// Compare with Thread.Sleep(3000) from Project 192!
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/delay", async () =>
{
    Console.WriteLine($"[DELAY] Starting at {DateTime.Now:T}... thread is FREE for others!");

    // Task.Delay = wait for 3 seconds WITHOUT blocking the thread
    // The thread can handle other requests while waiting!
    await Task.Delay(3000);

    Console.WriteLine($"[DELAY] Done at {DateTime.Now:T}");
    return Results.Ok($"Non-blocking response! Done at: {DateTime.Now:T}");
});

// ─────────────────────────────────────────────────────────────────────────
// EXAMPLE 2: Task<T> — A task that returns a VALUE
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/task-with-value", async () =>
{
    // This task "promises" to return a string after 1 second
    Task<string> fetchNameTask = GetNameAsync();

    // You could do other work here while waiting...

    // When you need the value, await it!
    string name = await fetchNameTask;

    return Results.Ok($"Fetched name: {name}");
});

// ─────────────────────────────────────────────────────────────────────────
// EXAMPLE 3: Task.WhenAll — Run multiple tasks at the SAME time!
// ─────────────────────────────────────────────────────────────────────────
app.MapGet("/parallel", async () =>
{
    var startTime = DateTime.Now;
    Console.WriteLine($"[PARALLEL] Starting 3 tasks at the same time at {startTime:T}");

    // Instead of waiting 1+1+1 = 3 seconds SEQUENTIALLY...
    // We start ALL 3 tasks at once and wait for them ALL to finish!
    var task1 = SimulateDbCallAsync("Users", 1000);
    var task2 = SimulateDbCallAsync("Products", 1000);
    var task3 = SimulateDbCallAsync("Orders", 1000);

    // Wait for ALL 3 to complete
    var results = await Task.WhenAll(task1, task2, task3);

    var elapsed = (DateTime.Now - startTime).Seconds;
    Console.WriteLine($"[PARALLEL] All done in ~{elapsed} seconds!");

    return Results.Ok(new
    {
        TimeTaken = $"~{elapsed} second(s) (not 3!)",
        Results = results
    });
});

app.Run();


// ─────────────────────────────────────────────────────────────────────────
// Helper methods that return Tasks (at bottom — C# 9+ rule!)
// ─────────────────────────────────────────────────────────────────────────
async Task<string> GetNameAsync()
{
    await Task.Delay(1000); // Simulate 1 second database call
    return "Sony";
}

async Task<string> SimulateDbCallAsync(string tableName, int delayMs)
{
    await Task.Delay(delayMs);
    Console.WriteLine($"[DB] Fetched from {tableName} table!");
    return $"{tableName} data loaded";
}

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. NON-BLOCKING DELAY (compare with /slow from Project 192!):
       curl http://localhost:5000/delay
       Takes 3 seconds BUT the thread is free for other requests.
       
    2. TASK WITH RETURN VALUE:
       curl http://localhost:5000/task-with-value
       → Returns the name after 1 second.
       
    3. PARALLEL TASKS (3 x 1 second tasks finishing in ~1 second total!):
       curl http://localhost:5000/parallel
       → See how Task.WhenAll runs all 3 simultaneously?
       → Instead of 3 seconds (1+1+1), it takes only ~1 second!
       
    KEY SUMMARY:
    - Thread.Sleep(3000) → BLOCKS the thread for 3 seconds (bad!)
    - Task.Delay(3000)   → WAITS 3 seconds but thread stays FREE (good!)
    - Task<T>            → A promise to return a value T in the future
    - Task.WhenAll()     → Run multiple tasks in PARALLEL (huge performance win!)
    
    In Project 194, you will learn HOW to wait for a Task: the `async` and `await` keywords!
*/
