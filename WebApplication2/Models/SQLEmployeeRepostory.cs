using System.Collections.Generic;
using WebApplication2.Models;

namespace EmployeeManangement.Models
{
    public class SQLEmployeeRepostory : IEmployeeRepostory
    {
        private AppDbContext context;

        public SQLEmployeeRepostory(AppDbContext context)
        {
            this.context = context
        }
        public Employee Add(Employee employee)
        {
           context.Employees.Add(employee);
            context.SaveChangesAsync();
            return employee;
        }

        public Employee Delete(int id)
        {
          Employee employee =  context.Employees.Find(id);
          if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChangesAsync();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChangesAsync();
            return employeeChanges;
        }
    }
}
