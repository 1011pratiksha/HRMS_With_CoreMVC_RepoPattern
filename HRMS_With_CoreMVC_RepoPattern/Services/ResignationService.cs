using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class ResignationService : IResignationRepository
    {
        private readonly ApplicationDbContext context;

        public ResignationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddResignation(Resignation r)
        {
            context.Resignation.Add(r);
            await context.SaveChangesAsync();
            return "Added Successfully";
        }

        public async Task<List<Resignation>> GetResignations()
        {
            return await context.Resignation
                .Include(x => x.User)
                .Include(x => x.Department)
                .ToListAsync();
        }

        public async Task<Resignation?> GetResignationById(int id)
        {
            return await context.Resignation
                .Include(x => x.User)
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.ResignationId == id);
        }

        public async Task<string> UpdateResignation(Resignation r)
        {
            context.Resignation.Update(r);
            await context.SaveChangesAsync();
            return "Updated Successfully";
        }

        public async Task<string> DeleteResignation(int id)
        {
            Resignation? r = await context.Resignation
                .FirstOrDefaultAsync(x => x.ResignationId == id);

            if (r != null)
            {
                context.Resignation.Remove(r);
                await context.SaveChangesAsync();
                return "Delete Successfully";
            }

            return "Resignation not found";
        }
    }
}