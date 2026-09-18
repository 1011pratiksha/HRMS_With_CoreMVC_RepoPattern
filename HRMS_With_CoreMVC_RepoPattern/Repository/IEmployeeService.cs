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
        Task<List<User>> GetAllEmployees();
        Task<User> GetEmployeeById( int id);
        Task<User> AddEmployee(User user);
        Task<User> EditEmployee(User user);
        Task<bool> DeleteEmployeeById(int id);
    }
}
