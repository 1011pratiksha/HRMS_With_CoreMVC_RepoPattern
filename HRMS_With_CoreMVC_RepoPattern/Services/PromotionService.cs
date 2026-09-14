using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class PromotionService : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;

        public PromotionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Promotion> FetchGetAll()
        {
            return _context.Promotion.Include(p => p.User).OrderByDescending(p => p.Date).ToList();
        }

        public Promotion GetById(int id)
        {
            return _context.Promotion.Find(id);
        }

        public string Add(Promotion p)
        {
            _context.Promotion.Add(p);
            _context.SaveChanges();
            return "Promotion added successfully!";
        }

        public string Update(Promotion p)
        {
            var existing = _context.Promotion.Find(p.PromotionId);
            if (existing == null)
            {
                return "Promotion not found.";
            }
            else
            {
                existing.UserID = p.UserID;
                existing.DesignationFrom = p.DesignationFrom;
                existing.DesignationTo = p.DesignationTo;
                existing.Date = p.Date;
            }

            _context.SaveChanges();
            return "Promotion updated successfully!";
        }

        public string Delete(int id)
        {
            var promotion = _context.Promotion.Find(id);
            if (promotion == null)
            {
                return "Promotion not found.";
            }
            else
            {
                _context.Promotion.Remove(promotion);
                _context.SaveChanges();
                return "Promotion deleted successfully!";
            }
        }

        public List<User> FetchAllUsers()
        {
            return _context.User.ToList();
        }

        public List<Designation> FetchAllDesignations()
        {
            return _context.Designations.ToList();
        }

    }
}
