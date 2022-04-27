namespace Services.Shared.Models;

public class RegisterUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; } 
    public string FirstName{ get; set; }
    public string LastName { get; set; }
      
}