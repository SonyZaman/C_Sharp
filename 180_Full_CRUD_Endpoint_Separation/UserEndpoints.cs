// 180. Full CRUD: Endpoint Separation + LINQ + DTOs
/*
    This file contains the Models, Fake Database, DTOs, and Endpoints.
    By moving this out of Program.cs, our application architecture becomes
    much cleaner and more professional.
*/

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string SecretPassword { get; set; }
}

public static class Db
{
    public static int NextId = 3;
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony",   Email = "sony@test.com",   SecretPassword = "pass1" },
        new User { Id = 2, Name = "Maysha", Email = "maysha@test.com", SecretPassword = "pass2" }
    };
}

public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string SecretPassword { get; set; }
}

public class UpdateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public static class UserEndpoints
{
    // The magical Extension Method that glues these endpoints onto `WebApplication app`
    public static void MapUserEndpoints(this WebApplication app)
    {
        var usersGroup = app.MapGroup("/users");

        // GET ALL
        usersGroup.MapGet("/", () =>
        {
            var responseList = Db.Users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            return Results.Ok(responseList);
        });

        // GET BY ID
        usersGroup.MapGet("/{id:int}", (int id) =>
        {
            var foundUser = Db.Users.FirstOrDefault(u => u.Id == id);
            if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

            var dto = new UserResponseDto
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Email = foundUser.Email
            };

            return Results.Ok(dto);
        });

        // CREATE
        usersGroup.MapPost("/", (CreateUserDto input) =>
        {
            if (string.IsNullOrWhiteSpace(input.Name)) return Results.BadRequest("Name is required");
            if (string.IsNullOrWhiteSpace(input.Email)) return Results.BadRequest("Email is required");

            var newUser = new User
            {
                Id = Db.NextId++,
                Name = input.Name,
                Email = input.Email,
                SecretPassword = input.SecretPassword
            };

            Db.Users.Add(newUser);

            var responseDto = new UserResponseDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email
            };

            return Results.Created($"/users/{newUser.Id}", responseDto);
        });

        // UPDATE
        usersGroup.MapPut("/{id:int}", (int id, UpdateUserDto input) =>
        {
            var foundUser = Db.Users.FirstOrDefault(u => u.Id == id);
            if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

            if (string.IsNullOrWhiteSpace(input.Name)) return Results.BadRequest("Name is required");

            foundUser.Name = input.Name;
            foundUser.Email = input.Email;

            var responseDto = new UserResponseDto
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Email = foundUser.Email
            };

            return Results.Ok(responseDto);
        });

        // DELETE
        usersGroup.MapDelete("/{id:int}", (int id) =>
        {
            var foundUser = Db.Users.FirstOrDefault(u => u.Id == id);
            if (foundUser == null) return Results.NotFound(new { Error = "User not found" });

            Db.Users.Remove(foundUser);

            return Results.Ok(new { Message = $"User {id} deleted successfully" });
        });
    }
}
