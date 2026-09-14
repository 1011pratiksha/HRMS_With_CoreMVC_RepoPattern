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

        public string AddTermination(Termination t)
        {
            context.Termination.Add(t);
            context.SaveChanges();

            return "Added Successfully";
        }

        public List<Termination> GetTerminations()
        {
            return context.Termination
                .Include(t => t.User)
                .ToList();
        }

        public Termination GetTerminationById(int id)
        {
            return context.Termination
                .Include(t => t.User)
                .FirstOrDefault(t => t.TerminationId == id);
        }

        public string UpdateTermination(Termination t)
        {
            context.Termination.Update(t);
            context.SaveChanges();

            return "Updated Successfully";
        }

        public string DeleteTermination(int id)
        {
            Termination t = context.Termination.Find(id);

            if (t != null)
            {
                context.Termination.Remove(t);
                context.SaveChanges();

                return "Delete Successfully";
            }

            return "Termination not found";
        }
    }
}