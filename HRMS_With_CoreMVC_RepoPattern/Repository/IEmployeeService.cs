using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEmployeeService
    {
        //for add role
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);

        Task<Role> AddRole(Role role);
        Task<Role> EditRole(Role role); 
        Task<Role> DeleteRole(int id);

        //for add department
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department department);
        Task<Department> EditDepartment(Department department);
        Task<Department> DeleteDepartment(int id);

        //-----for add designation
        Task < List < Designation >> GetAllDesignations();
        Task<Designation> GetDesignationById(int id);
        Task<Designation> AddDesignation(Designation designation);
        Task<Designation> EditDesignation(Designation designation);
        Task<Designation> DeleteDesignation(int id);

        ///---- for employee list
        Task<List<User>> GetAllEmployees(
    DateTime? startDate,
    DateTime? endDate,
    int? designationId,
    string? status,
    string? sorting);
        Task<User> GetEmployeeById( int id);
        Task<User> AddEmployee(User user);
        Task<User> EditEmployee(User user);
        Task<bool> DeleteEmployeeById(int id);

        //----for employee grid data
        Task<List<EmployeeGridViewModel>> GetEmployeeGridData(); Task<EmployeeBankDetails> GetBankDetails(int userId);

        //----- employee profile details
        Task<User> GetUserProfile(int userId);
        Task<User> EditEmployeeProfile(User user);
        Task<List<EmployeeFamilyDetail>> GetFamilyDetails(int userId);
        Task<List<EducationDetails>> GetEducationDetails(int userId);
        Task<List<Experience>> GetExperiences(int userId);

        //----- Employee Bank Details
        Task<EmployeeBankDetails> AddBankDetails(EmployeeBankDetails bankDetails);
        Task<EmployeeBankDetails> EditBankDetails(EmployeeBankDetails bankDetails);

        Task<EmployeeFamilyDetail> AddFamilyDetails(EmployeeFamilyDetail familyDetails);
        Task<EmployeeFamilyDetail> EditFamilyDetails(EmployeeFamilyDetail familyDetails);

        Task<EducationDetails> AddEducationDetails(EducationDetails educationDetails);
        Task<EducationDetails> EditEducationDetails(EducationDetails educationDetails);

        Task<Experience> AddExperience(Experience experience);
        Task<Experience> EditExperience(Experience experience);

    }
}
