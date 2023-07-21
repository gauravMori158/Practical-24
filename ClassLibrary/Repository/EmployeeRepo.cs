using ClassLibrary.Interface;
using ClassLibrary.Models;

namespace ClassLibrary.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDbContext context;
        public EmployeeRepo(EmployeeDbContext ctx)
        {
                context = ctx;
        }


        public void CreateEmployee(Employee employee)
        {
           
                context.Employees.Add(employee);
                context.SaveChanges();
           
        }
        public List<Employee> GetEmployees()
        {
            
                var employees = context.Employees.Where(e => e.Status == true).ToList();
                return employees;

            
        }
        public Employee GetEmployeeById(int id)
        {
           
                return context.Employees.Where(e => e.Status == true).FirstOrDefault(e => e.Id == id);
             
        }
        public void DeleteEmployee(int id)
        {
             var employee = context.Employees.Find(id);
                employee.Status = false;
                //context.Employees.Remove(employee);
                context.SaveChanges();
            
        }

        public void UpdateEmployee(Employee employee)
        {
             
                context.Employees.Update(employee);
                context.SaveChanges();

             
        }

    }
}
