namespace MudDemo.Client.Models;

public class UserModel
{
    public string Avatar { get; set; } = "./sample-data/avatar.png";
    public string DisplayName { get; set; } = "MudBlazor";
    public string Email { get; set; } = "muddemo@demo.com.au";
    public string Role { get; set; } = "Admin";
}