using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public interface IAuthService
    {
        Task SignUp(User us);

        Task<string?> SignIn(string Email, string Password);
    }
}