// 144. REST APIs Explained
/*
    ╔══════════════════════════════════════════════════════════════════════════╗
    ║                                  REST API                                ║
    ╚══════════════════════════════════════════════════════════════════════════╝

    REST = Representational State Transfer
    A "RESTful API" uses standard HTTP Methods to perform CRUD operations.
    
    CRUD ←→ HTTP MAPPING:
    ┌────────────┬──────────────┬────────────────────────────────────┐
    │ CRUD       │ HTTP Method  │ What it does                       │
    ├────────────┼──────────────┼────────────────────────────────────┤
    │ Create     │   POST       │ Add a brand new record             │
    │ Read       │   GET        │ Fetch existing data                │
    │ Update     │   PUT/PATCH  │ Modify an existing record          │
    │ Delete     │   DELETE     │ Remove a record permanently        │
    └────────────┴──────────────┴────────────────────────────────────┘


    ═══════════════════════════════════════════════
    1. THE 5 HTTP METHODS (Verbs)
    ═══════════════════════════════════════════════

     HTTP METHOD   URL ENDPOINT        ACTION                 Request Body?
    ┌───────────┬──────────────────┬──────────────────────┬───────────────┐
    │  GET      │  /api/users      │  Get ALL users       │     No        │
    │  GET      │  /api/users/101  │  Get specific user   │     No        │
    │  POST     │  /api/users      │  Create a new user   │  Yes (JSON)   │
    │  PUT      │  /api/users/101  │  Replace user 101    │  Yes (JSON)   │
    │  PATCH    │  /api/users/101  │  Update user 101     │  Yes (JSON)   │
    │  DELETE   │  /api/users/101  │  Delete user 101     │     No        │
    └───────────┴──────────────────┴──────────────────────┴───────────────┘

    PUT vs PATCH difference:
    ┌─────────┬──────────────────────────────────────────────────────────────┐
    │ PUT     │ Replaces the ENTIRE object.                                  │
    │         │ If you forget to send the "Name" field, it becomes null!     │
    ├─────────┼──────────────────────────────────────────────────────────────┤
    │ PATCH   │ Updates ONLY the fields you send.                            │
    │         │ Send just { "Email": "new@email.com" } → only email updates. │
    └─────────┴──────────────────────────────────────────────────────────────┘


    ═══════════════════════════════════════════════
    2. HTTP STATUS CODES (The Server's Response)
    ═══════════════════════════════════════════════

    2xx = SUCCESS
    ┌──────┬───────────────────────┬────────────────────────────────────────┐
    │ 200  │ OK                    │ General success (used with GET)        │
    │ 201  │ Created               │ New resource was created (POST)        │
    │ 204  │ No Content            │ Success, but nothing to return (DELETE)│
    └──────┴───────────────────────┴────────────────────────────────────────┘

    4xx = CLIENT ERROR (You did something wrong)
    ┌──────┬───────────────────────┬────────────────────────────────────────┐
    │ 400  │ Bad Request           │ You sent invalid or malformed JSON     │
    │ 401  │ Unauthorized          │ You are not logged in (no token)       │
    │ 403  │ Forbidden             │ Logged in, but you lack permission     │
    │ 404  │ Not Found             │ URL or resource does not exist         │
    │ 409  │ Conflict              │ Duplicate (e.g., email already exists) │
    │ 422  │ Unprocessable Entity  │ Data is valid JSON but fails validation│
    └──────┴───────────────────────┴────────────────────────────────────────┘

    5xx = SERVER ERROR (The C# backend crashed)
    ┌──────┬───────────────────────┬────────────────────────────────────────┐
    │ 500  │ Internal Server Error │ Unhandled exception in your C# code    │
    │ 502  │ Bad Gateway           │ A proxy/load balancer got a bad reply  │
    │ 503  │ Service Unavailable   │ Server is down or overloaded           │
    └──────┴───────────────────────┴────────────────────────────────────────┘


    ═══════════════════════════════════════════════
    3. THE 6 GUIDING PRINCIPLES OF REST
    ═══════════════════════════════════════════════
    To be truly "RESTful", an API MUST follow these 6 architectural constraints:

    ┌───┬──────────────────────────┬─────────────────────────────────────────────────────────┐
    │ # │ Principle                │ What it means in practice                               │
    ├───┼──────────────────────────┼─────────────────────────────────────────────────────────┤
    │ 1 │ Client-Server            │ Front-End and Back-End are totally separate systems.    │
    │   │ Architecture             │ They only talk via HTTP + JSON. Neither knows how       │
    │   │                          │ the other is built internally.                          │
    ├───┼──────────────────────────┼─────────────────────────────────────────────────────────┤
    │ 2 │ Statelessness            │ The server has NO memory between requests.              │
    │   │                          │ Every request must include its own authentication       │
    │   │                          │ token (JWT). The server does not store sessions.        │
    ├───┼──────────────────────────┼─────────────────────────────────────────────────────────┤
    │ 3 │ Cacheability             │ GET responses should declare if the browser can         │
    │   │                          │ cache them using HTTP headers (Cache-Control).          │
    │   │                          │ This reduces server load and speeds up the app.         │
    ├───┼──────────────────────────┼─────────────────────────────────────────────────────────┤
    │ 4 │ Layered System           │ The client doesn't know if it talks directly to the     │
    │   │                          │ server or to a load balancer, security proxy, or CDN.   │
    ├───┼──────────────────────────┼─────────────────────────────────────────────────────────┤
    │ 5 │ Uniform Interface        │ URLs must be consistent and resource-based.             │
    │   │                          │ Use nouns NOT verbs: /users NOT /getUsers               │
    │   │                          │ Use plural nouns:     /users NOT /user                  │
    │   │                          │ Nest resources:       /users/101/orders                 │
    ├───┼──────────────────────────┼─────────────────────────────────────────────────────────┤
    │ 6 │ Code on Demand (Optional)│ The server can send executable code (e.g. JavaScript)   │
    │   │                          │ to the client to extend its functionality.              │
    └───┴──────────────────────────┴─────────────────────────────────────────────────────────┘


    ═══════════════════════════════════════════════
    4. AUTHENTICATION (How Logins Work in REST)
    ═══════════════════════════════════════════════
    Since REST is stateless, there are no "sessions". Instead we use TOKENS.
    
    JWT = JSON Web Token (the industry standard)
    
    Flow:
    Step 1: Client sends POST /api/auth/login  { username, password }
    Step 2: Server checks credentials → if valid, generates a JWT token string
    Step 3: Server sends JWT back to the Client
    Step 4: Client stores the JWT (in memory or localStorage)
    Step 5: On every future request, Client sends the token in the Header:
    
            Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
    
    Step 6: Server reads the token, validates it, and processes the request.
    
    
    ═══════════════════════════════════════════════
    5. REST API URL NAMING BEST PRACTICES
    ═══════════════════════════════════════════════

    ✅ GOOD (RESTful)             ❌ BAD (not RESTful)
    GET    /api/users             GET    /api/getUsers
    GET    /api/users/101         GET    /api/getUserById?id=101
    POST   /api/users             POST   /api/createUser
    PUT    /api/users/101         PUT    /api/updateUser/101
    DELETE /api/users/101         DELETE /api/deleteUser/101
    GET    /api/users/101/orders  GET    /api/getOrdersForUser/101
*/
