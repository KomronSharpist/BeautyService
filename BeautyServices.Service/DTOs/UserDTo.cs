using BeautyServices.Domain.Enums;

namespace BeautyServices.Service.DTOs;

public class UserDTo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
