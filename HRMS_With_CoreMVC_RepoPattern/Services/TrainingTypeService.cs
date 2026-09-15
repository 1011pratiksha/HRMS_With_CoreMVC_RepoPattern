using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TrainingTypeService : ITrainingTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public TrainingTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(TrainingType t)
        {
            _context.TrainingType.Add(t);
            _context.SaveChanges();
            return "Training Type Added Successfully";
        }

        public async Task<string> Delete(int id)
        {
            var t = _context.TrainingType.Find(id);
            if(t == null)
            {
                return "Training Type Not Found";
            }
            _context.TrainingType.Remove(t);
            _context.SaveChanges();
            return "Training Type Deleted Successfully";
        }

        public async Task<List<TrainingType>> FetchAll()
        {
            return _context.TrainingType.ToList();
        }

        public async Task<TrainingType> FetchById(int id)
        {
            return _context.TrainingType.Find(id);
        }

        public async Task<string> Update(TrainingType t)
        {
            var existing = _context.TrainingType.Find(t.TrainingTypeId);
            if(existing == null)
            {
                return "Training Type Not Found";
            }
            else
            {
                existing.TrainingTypeName = t.TrainingTypeName;
                existing.Description = t.Description;
                existing.Status = t.Status;
            }
            _context.SaveChanges();
            return "Training Type Updated Successfully";
        }
    }
}
