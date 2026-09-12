using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
