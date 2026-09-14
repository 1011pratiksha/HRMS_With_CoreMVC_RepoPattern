using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public interface IAuthService
    {
        void SignUp(User us);

        string SignIn(string Email, string Password);
    }
}