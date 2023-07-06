using Repository_Pattern.Models;

namespace Repository_Pattern.Interface
{
    public interface IEmployeeRepo
    {
        Employee GetEmployeeById(int id);
        List<Employee>GetEmployees();
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);  
        void CreateEmployee(Employee employee);
    }
}
