using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class FileUploadService : IFileUploadRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public FileUploadService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<string> Add(FileUpload f, IFormFile file)
        {
            if(file != null)
            {
                f.FilePath = SaveFile(file);
            }
            await _context.FileUpload.AddAsync(f);
            await _context.SaveChangesAsync();
            return "File uploaded successfully";
        }

        public async Task<string> Delete(int id)
        {
            var file = await _context.FileUpload.FindAsync(id);
            if(file == null)
            {
                return "File not found";
            }
            _context.FileUpload.Remove(file);
            await _context.SaveChangesAsync();
            return "File deleted successfully";
        }

        public async Task<List<FileUpload>> FetchAll()
        {
            return await _context.FileUpload.ToListAsync();
        }

        public async Task<List<AddAdminDocName>> FetchAllDocNames()
        {
            return await _context.addAdminDocNames.ToListAsync();
        }

        public async Task<List<User>> FetchAllUser()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> FetchUserById(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<List<AddEmployeeDocName>> FetchAllEmployeeDocNames()
        {
            return await _context.addEmployeeDocNames.ToListAsync();
        }

        public async Task<FileUpload> FetchById(int id)
        {
            return await _context.FileUpload.FindAsync(id);
        }

        private string SaveFile(IFormFile file)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(_env.WebRootPath, "uploads");
            if(!Directory.Exists(folderPath))
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
    }
}
