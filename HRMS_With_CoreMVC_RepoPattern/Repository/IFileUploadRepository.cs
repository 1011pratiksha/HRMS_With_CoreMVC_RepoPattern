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
        Task<User> FetchUserById(int id);
        Task<List<AddAdminDocName>> FetchAllDocNames();
        Task<AddAdminDocName> FetchAdminDocNameById(int id);
        Task<string> UpdateAdminDocName(AddAdminDocName a);
        Task<List<AddEmployeeDocName>> FetchAllEmployeeDocNames();
        Task<AddEmployeeDocName> FetchEmployeeDocNameById(int id);
        Task<string> UpdateEmployeeDocName(AddEmployeeDocName a);
        Task<string> AddAdminDocName(AddAdminDocName a);
        Task<string> AddEmployeeDocName(AddEmployeeDocName a);
        Task<string> DeleteAdminDocName(int id);
        Task<string> DeleteEmployeeDocName(int id);
    }
}