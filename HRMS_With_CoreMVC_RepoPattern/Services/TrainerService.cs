using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TrainerService : ITrainerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TrainerService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        

        public Trainer GetById(int id)
        {
            return _context.Trainer.Find(id);
        }

        public string Add(Trainer t)
        {
            if (t.imagename != null)
            {
                t.ProfilePicture = SaveImage(t.imagename);
            }

            _context.Trainer.Add(t);
            _context.SaveChanges();

            return "Trainer added successfully!";
        }

        public string Update(Trainer t)
        {
            var existing = _context.Trainer.Find(t.TrainerId);
            if (existing == null)
            {
                return "Trainer not found.";
            }

            existing.FirstName = t.FirstName;
            existing.LastName = t.LastName;
            existing.Role = t.Role;
            existing.Email = t.Email;
            existing.Description = t.Description;
            existing.Status = t.Status;
            existing.Phone = t.Phone;

            if (t.imagename != null)
            {
                existing.ProfilePicture = SaveImage(t.imagename);
            }

            _context.SaveChanges();

            return "Trainer updated successfully!";
        }

        public string Delete(int id)
        {
            var trainer = _context.Trainer.Find(id);
            if (trainer == null)
            {
                return "Trainer not found.";
            }

            _context.Trainer.Remove(trainer);
            _context.SaveChanges();

            return "Trainer deleted successfully!";
        }

        private string SaveImage(IFormFile file)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/uploads/" + fileName;
        }

        public List<Trainer> FetchAll()
        {
            return _context.Trainer.ToList();
        }

        public List<Role> FetchAllRoles()
        {
            return _context.Role.ToList();
        }
    }
    
}
