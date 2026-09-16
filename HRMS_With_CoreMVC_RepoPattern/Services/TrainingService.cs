using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TrainingService : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;
        public TrainingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(Training t, string createdBy)
        {
            t.CreatedAt = DateTime.Now;
            t.CreatedBy = string.IsNullOrEmpty(createdBy) ? "System" : createdBy;

            await _context.Training.AddAsync(t);
            await _context.SaveChangesAsync();

            return "Training added successfully!";
        }

        public async Task<string> Delete(int id)
        {
            var t = await _context.Training.FindAsync(id);
            if (t == null)
            {
                return "Training Not Found";
            }
            _context.Training.Remove(t);
            await _context.SaveChangesAsync();
            return "Training deleted successfully!";
        }

        public async Task<List<Training>> FetchAll()
        {
            return await _context.Training
                .Include(t => t.Trainer)
                .Include(t => t.TrainingType)
                .Include(t => t.User)
                .OrderByDescending(t => t.StartDate)
                .ToListAsync();
        }

        public async Task<List<Trainer>> FetchAllTrainers()
        {
            return await _context.Trainer.ToListAsync();
        }

        public async Task<List<TrainingType>> FetchAllTrainingTypes()
        {
            return await _context.TrainingType.ToListAsync();
        }

        public async Task<List<User>> FetchAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<Training> FetchById(int id)
        {
            return await _context.Training.FindAsync(id);
        }

        public async Task<string> Update(Training t)
        {
            var existing = await _context.Training.FindAsync(t.TrainingId);
            if (existing == null)
            {
                return "Training Not Found";
            }
            else
            {
                existing.TrainerId = t.TrainerId;
                existing.TrainingTypeId = t.TrainingTypeId;
                existing.UserId = t.UserId;
                existing.TrainingCost = t.TrainingCost;
                existing.Description = t.Description;
                existing.Status = t.Status;
                existing.StartDate = t.StartDate;
                existing.EndDate = t.EndDate;
            }

            await _context.SaveChangesAsync();
            return "Training updated successfully!";
        }
    }
}
