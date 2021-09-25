using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;  
using System.Linq; 

namespace EmployeesAPI.Context
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions options) : base(options)
        {   }

        public List<Employee> GetDbList(){
            return Employees.Local.ToList<Employee>();
        }
    }
}