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

        public string AddResignation(Resignation r)
        {
            context.Resignation.Add(r);
            context.SaveChanges();
            return "Added Successfully";
        }

        public string DeleteResignation(int id)
        {
            Resignation r = context.Resignation.Find(id);

            if (r != null)
            {
                context.Resignation.Remove(r);
                context.SaveChanges();
                return "Delete Successfully";
            }

            return "Resignation not found";
        }

        public Resignation GetResignationById(int id)
        {
            return context.Resignation.Find(id);
        }

        public List<Resignation> GetResignations()
        {
            return context.Resignation
                .Include(r => r.User)
                .Include(r => r.Department)
                .ToList();
        }

        public string UpdateResignation(Resignation r)
        {
            context.Resignation.Update(r);
            context.SaveChanges();

            return "Updated Successfully";
        }
    }
}