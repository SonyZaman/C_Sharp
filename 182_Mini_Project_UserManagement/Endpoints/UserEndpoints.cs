using MiniValidation;
using MiniProject.Models;
using MiniProject.Data;
using MiniProject.DTOs;

namespace MiniProject.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var usersGroup = app.MapGroup("/users");

        // GET ALL (with optional filtering and sorting, just to show off!)
        usersGroup.MapGet("/", (string? search) =>
        {
            IEnumerable<User> query = Db.Users;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u => u.Name.Contains(search, StringComparison.OrdinalIgnoreCase) 
                                      || u.Email.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            var responseList = query
                .OrderBy(u => u.Name)
                .Select(u => new UserResponseDto
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
            if (!MiniValidator.TryValidate(input, out var errors))
                return Results.ValidationProblem(errors);

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

            if (!MiniValidator.TryValidate(input, out var errors))
                return Results.ValidationProblem(errors);

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
