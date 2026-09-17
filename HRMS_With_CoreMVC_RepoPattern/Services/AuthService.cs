using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task SignUp(User us)
        {
            us.PasswordHash = passwordHasher.HashPassword(us, us.PasswordHash);

            await db.User.AddAsync(us);
            await db.SaveChangesAsync();
        }

        public async Task<string?> SignIn(string Email, string Password)
        {
            var data = await db.User
      .Where(x => x.Email.Equals(Email))
      .SingleOrDefaultAsync();
            if (data != null)
            {
                var result = passwordHasher.VerifyHashedPassword(
                    data,
                    data.PasswordHash,
                    Password
                );

                if (result == PasswordVerificationResult.Success)
                {
                    var role = await db.Role
                        .Where(x => x.RoleId.Equals(data.RoleId))
                        .SingleOrDefaultAsync();

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

            return null;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.User
                .Where(x => x.Email.Equals(email))
                .SingleOrDefaultAsync();
        }
    }
}

