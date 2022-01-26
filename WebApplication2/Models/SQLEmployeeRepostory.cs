using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApplication2.Models;

namespace EmployeeManangement.Models
{
    public class SQLEmployeeRepostory : IEmployeeRepostory
    {
        private AppDbContext context;
        private readonly ILogger<SQLEmployeeRepostory> logger;

        public SQLEmployeeRepostory(AppDbContext context,
                                    ILogger <SQLEmployeeRepostory> logger)
        {
            this.context = context;
            this.logger = logger;
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
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
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
