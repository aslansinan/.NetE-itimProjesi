using System.Collections.Generic;
using System.Linq;
namespace WebApplication2.Models
{
    public interface IEmployeeRepostory
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
    }
}
