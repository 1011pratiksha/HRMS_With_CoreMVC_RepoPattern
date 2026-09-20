using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TerminationService : ITerminationRepository
    {
        private readonly ApplicationDbContext context;

        public TerminationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddTermination(Termination t)
        {
            context.Termination.Add(t);
            await context.SaveChangesAsync();
            return "Added Successfully";
        }

        public async Task<List<Termination>> GetTerminations()
        {
            return await context.Termination
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<Termination?> GetTerminationById(int id)
        {
            return await context.Termination
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.TerminationId == id);
        }

        public async Task<string> UpdateTermination(Termination t)
        {
            context.Termination.Update(t);
            await context.SaveChangesAsync();
            return "Updated Successfully";
        }

        public async Task<string> DeleteTermination(int id)
        {
            Termination? t = await context.Termination
                .FirstOrDefaultAsync(x => x.TerminationId == id);

            if (t != null)
            {
                context.Termination.Remove(t);
                await context.SaveChangesAsync();
                return "Delete Successfully";
            }

            return "Termination not found";
        }
    }
}