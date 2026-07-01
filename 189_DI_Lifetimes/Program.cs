// 189. Dependency Injection Lifetimes
/*
    NEW CONCEPT: Transient vs Scoped vs Singleton
    
    When you register a service in Dependency Injection, you must tell .NET 
    HOW LONG that service should live. There are 3 options:
    
    1. TRANSIENT (`AddTransient`): 
       A brand new instance is created EVERY SINGLE TIME you ask for it.
       Use for: Lightweight, stateless services.
       
    2. SCOPED (`AddScoped`): 
       A new instance is created ONCE per HTTP Request. 
       If you ask for it 5 times during the same request, you get the exact same instance.
       Use for: Database connections (Entity Framework relies heavily on Scoped).
       
    3. SINGLETON (`AddSingleton`): 
       Created exactly ONCE when the app starts. Shared by EVERYONE forever.
       Use for: Caching, global configurations, fake in-memory databases.
*/

var builder = WebApplication.CreateBuilder(args);

// Register the 3 different lifetimes
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

var app = builder.Build();

// Notice we ask for TWO of each service in the exact same request!
app.MapGet("/lifetimes", (
    ITransientService trans1, ITransientService trans2,
    IScopedService scope1, IScopedService scope2,
    ISingletonService single1, ISingletonService single2) =>
{
    return new
    {
        Explanation = "Notice how Transient changes EVERY time. Scoped is identical within THIS request (but changes if you refresh). Singleton NEVER changes!",
        
        Transient = new 
        { 
            FirstCall = trans1.GetOperationId(), 
            SecondCall = trans2.GetOperationId() 
        },
        Scoped = new 
        { 
            FirstCall = scope1.GetOperationId(), 
            SecondCall = scope2.GetOperationId() 
        },
        Singleton = new 
        { 
            FirstCall = single1.GetOperationId(), 
            SecondCall = single2.GetOperationId() 
        }
    };
});

app.Run();

// ─────────────────────────────────────────────────────────────────────────
// Interfaces & Implementations (MUST BE AT THE BOTTOM OF PROGRAM.CS)
// ─────────────────────────────────────────────────────────────────────────
// We use a Guid (random unique ID) to prove if an object is new or reused!
public interface ITransientService { Guid GetOperationId(); }
public interface IScopedService { Guid GetOperationId(); }
public interface ISingletonService { Guid GetOperationId(); }

public class TransientService : ITransientService
{
    private readonly Guid _id;
    public TransientService() { _id = Guid.NewGuid(); }
    public Guid GetOperationId() => _id;
}

public class ScopedService : IScopedService
{
    private readonly Guid _id;
    public ScopedService() { _id = Guid.NewGuid(); }
    public Guid GetOperationId() => _id;
}

public class SingletonService : ISingletonService
{
    private readonly Guid _id;
    public SingletonService() { _id = Guid.NewGuid(); }
    public Guid GetOperationId() => _id;
}

/*
    HOW TO TEST:
    
    Run `dotnet run` in the terminal.
    
    1. First request:
       curl http://localhost:5000/lifetimes
       - Transient 1 and 2 will be DIFFERENT.
       - Scoped 1 and 2 will be THE SAME.
       - Singleton 1 and 2 will be THE SAME.
       
    2. Second request (run the curl command again!):
       curl http://localhost:5000/lifetimes
       - Transient changed completely.
       - Scoped changed completely (because it's a NEW request).
       - Singleton DID NOT CHANGE! It is exactly the same as the first request!
*/
