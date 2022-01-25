using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace EmployeeManangement.Models
{
    public static  class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = 1,
                  Name = "Serdar",
                  Email = "serdargmail.com",
                  Department = Dept.HR
              },
              new Employee
               {
                   Id = 2,
                   Name = "Ali",
                   Email = "ali@gmail.com",
                   Department = Dept.IT
               }
              );
        }
    }
}
