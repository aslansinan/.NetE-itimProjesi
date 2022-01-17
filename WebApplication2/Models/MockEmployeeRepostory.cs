using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models
{
    public class MockEmployeeRepostory : IEmployeeRepostory
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepostory()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name ="Sinan",Department =Dept.IT,Email="sinan@gmail.com"},
                new Employee() { Id = 2, Name ="Ali", Department=Dept.HR,Email="ali@gmail.com"},
                new Employee(){ Id = 3, Name ="Serdar", Department = Dept.Payroll, Email="sr@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;

        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}

