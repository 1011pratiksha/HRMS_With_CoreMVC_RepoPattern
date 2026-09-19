using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IFileUploadRepository
    {
        Task<List<FileUpload>> FetchAll();
        Task<FileUpload> FetchById(int id);
        Task<string> Add(FileUpload f, IFormFile file);
        Task<string> Delete(int id);

        Task<List<User>> FetchAllUser();
        Task<List<AddAdminDocName>> FetchAllDocNames();
    }
}
