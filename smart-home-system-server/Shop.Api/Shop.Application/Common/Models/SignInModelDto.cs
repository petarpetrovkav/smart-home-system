namespace Shop.Application.Common.Models
{
    public record SignInModelDto(string Username, string Password, string Country,
                                   string Email, string ConfirmPassword, string FirstName, string LastName);
}
