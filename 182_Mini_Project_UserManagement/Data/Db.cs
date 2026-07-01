using MiniProject.Models;

namespace MiniProject.Data;

public static class Db
{
    public static int NextId = 3;
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Sony",   Email = "sony@test.com",   SecretPassword = "pass1" },
        new User { Id = 2, Name = "Maysha", Email = "maysha@test.com", SecretPassword = "pass2" }
    };
}
