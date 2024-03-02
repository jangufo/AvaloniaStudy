using AvaloniaDemo1.Models;

namespace AvaloniaDemo1.DataServer;

public class DataServer
{
    public User GetCurrentUser() => new() { Id = 1, Name = "Abandon", NickName = "Abandon", Password = "pw1" };
}