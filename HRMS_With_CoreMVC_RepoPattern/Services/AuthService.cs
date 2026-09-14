using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Identity;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext db;
        private readonly PasswordHasher<User> passwordHasher;

        public AuthService(ApplicationDbContext db)
        {
            this.db = db;
            passwordHasher = new PasswordHasher<User>();
        }

        public void SignUp(User us)
        {
            us.PasswordHash = passwordHasher.HashPassword(us, us.PasswordHash);

            db.User.Add(us);
            db.SaveChanges();
        }

        public string SignIn(string Email, string Password)
        {
            var data = db.User
                .Where(x => x.Email.Equals(Email))
                .SingleOrDefault();

            if (data != null)
            {
                var result = passwordHasher.VerifyHashedPassword(
                    data,
                    data.PasswordHash,
                    Password
                );

                if (result == PasswordVerificationResult.Success)
                {
                    var role = db.Role
                        .Where(x => x.RoleId.Equals(data.RoleId))
                        .SingleOrDefault();

                    if (role != null)
                    {
                        if (role.RoleName.Equals("Admin"))
                        {
                            return "Admin";
                        }

                        if (role.RoleName.Equals("Manager"))
                        {
                            return "Manager";
                        }

                        if (role.RoleName.Equals("Employee"))
                        {
                            return "Employee";
                        }
                    }
                }
            }

            return "";
        }
    }
}

