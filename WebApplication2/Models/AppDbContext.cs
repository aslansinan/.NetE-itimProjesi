﻿using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace EmployeeManangement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}