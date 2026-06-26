// 143. Web Development Basics: Architecture
/*
    ╔══════════════════════════════════════════════════════════════════════════╗
    ║                        WEB DEVELOPMENT ARCHITECTURE                      ║
    ╚══════════════════════════════════════════════════════════════════════════╝

    ═══════════════════════════════════════════════
    1. THE CLIENT (Front-End)
    ═══════════════════════════════════════════════
    The user's Web Browser (Chrome), Mobile App (iOS/Android), or Desktop App.
    It handles the User Interface (UI).
    
    Front-End Technologies:
    ┌─────────────────┬──────────────────────────────────────────┐
    │ Technology      │ Used For                                 │
    ├─────────────────┼──────────────────────────────────────────┤
    │ HTML/CSS        │ Website structure and styling            │
    │ JavaScript      │ Website interactivity                    │
    │ React / Angular │ Modern Single Page Applications (SPAs)   │
    │ Swift / Kotlin  │ Native iOS / Android Mobile apps         │
    │ Flutter / MAUI  │ Cross-platform Mobile apps               │
    └─────────────────┴──────────────────────────────────────────┘
    
    The Front-End CANNOT talk directly to the Database.
    It MUST always go through the Back-End API!
    
    
    ═══════════════════════════════════════════════
    2. THE SERVER (Back-End)
    ═══════════════════════════════════════════════
    The powerful computer in a data center that listens for requests 24/7.
    
    What the Back-End does:
    - Business Logic      (e.g., calculating order totals)
    - Authentication      (e.g., checking if you are logged in)
    - Authorization       (e.g., checking if you are an Admin)
    - Data Validation     (e.g., ensuring a username is not empty)
    - Talking to Database (e.g., querying SQL)
    
    Back-End Technologies (where C# lives!):
    ┌───────────────────┬──────────────────────────────────────────┐
    │ Technology        │ Language                                 │
    ├───────────────────┼──────────────────────────────────────────┤
    │ ASP.NET Core      │ C# ← YOU WILL USE THIS                   │
    │ Spring Boot       │ Java                                     │
    │ Django            │ Python                                   │
    │ Express           │ JavaScript (Node.js)                     │
    │ Laravel           │ PHP                                      │
    └───────────────────┴──────────────────────────────────────────┘
    
    
    ═══════════════════════════════════════════════
    3. THE DATABASE
    ═══════════════════════════════════════════════
    The permanent storage system that remembers data even after the server restarts.
    
    Two main types:
    ┌──────────────────────┬─────────────────────────────────────────────────────┐
    │ Type                 │ Examples & Best For                                 │
    ├──────────────────────┼─────────────────────────────────────────────────────┤
    │ Relational (SQL)     │ SQL Server, PostgreSQL, MySQL                       │
    │                      │ Best for: structured data, banking, e-commerce      │
    │                      │ Data is stored in strict rows & columns (tables)    │
    ├──────────────────────┼─────────────────────────────────────────────────────┤
    │ Non-Relational(NoSQL)│ MongoDB, Redis, Cassandra                           │
    │                      │ Best for: flexible data, real-time apps, big data   │
    │                      │ Data is stored as flexible JSON documents           │
    └──────────────────────┴─────────────────────────────────────────────────────┘
    
    
    ═══════════════════════════════════════════════
    4. THE API (Application Programming Interface)
    ═══════════════════════════════════════════════
    The API is the "Waiter" in the restaurant analogy:
    
    🧑 YOU (Customer)     = The CLIENT (Browser / App)
    🍽️  WAITER            = The API  
    👨‍🍳 KITCHEN           = The DATABASE
    
    The Client never enters the kitchen. The Waiter (API) takes the order and
    brings the food (data) back as JSON!
    
    ┌──────────────┐       HTTP Request         ┌────────────────┐      SQL Query     ┌────────────────┐
    │              │ ─────── GET /users ──────> │                │ ─── SELECT * ───>  │                │
    │   CLIENT     │                            │  ASP.NET Core  │                    │    DATABASE    │
    │ (React App)  │ <──── 200 OK + JSON ─────  │      API       │ <── Row Data ────  │  (SQL Server)  │
    └──────────────┘                            └────────────────┘                    └────────────────┘
    
    
    ═══════════════════════════════════════════════
    5. URL (Uniform Resource Locator)
    ═══════════════════════════════════════════════
    The address of a specific resource on the internet.
    
    Anatomy of a URL:
    
    https://api.mywebsite.com:443/users/101?sort=asc#section2
    │       │                 │   │         │         │
    │       │                 │   │         │         └── Fragment (jumps to a section)
    │       │                 │   │         └──────────── Query String (filters/options)
    │       │                 │   └────────────────────── Path (the resource location)
    │       │                 └────────────────────────── Port (443 is default for HTTPS)
    │       └──────────────────────────────────────────── Domain Name
    └──────────────────────────────────────────────────── Protocol (HTTP/HTTPS)
    
    
    ═══════════════════════════════════════════════
    6. HTTP vs HTTPS
    ═══════════════════════════════════════════════
    HTTP  = HyperText Transfer Protocol       (Data sent as plain text - NOT SECURE!)
    HTTPS = HyperText Transfer Protocol Secure (Data is ENCRYPTED using SSL/TLS)
    
    ALWAYS use HTTPS in production! Browsers show a red padlock warning for HTTP sites.
    
    
    ═══════════════════════════════════════════════
    7. COMPLETE REAL-WORLD FLOW (Instagram Example)
    ═══════════════════════════════════════════════
    
    Step 1: [CLIENT] User opens the Instagram app and pulls down to refresh.
    Step 2: [CLIENT] App sends: GET https://api.instagram.com/v1/feed  + Auth Token
    Step 3: [SERVER] ASP.NET receives the request. Validates the Auth Token.
    Step 4: [SERVER] If valid, queries the Database: SELECT top 10 posts...
    Step 5: [DATABASE] Returns the raw data rows to the server.
    Step 6: [SERVER] Converts the data into a JSON array string.
    Step 7: [SERVER] Sends back: 200 OK + JSON body to the Client.
    Step 8: [CLIENT] Reads the JSON, renders pictures and likes on the screen!
*/
