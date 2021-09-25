using DepartmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;  
using System.Linq; 

namespace DepartmentsAPI.Context
{
    public class DepartmentContext :DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DepartmentContext(DbContextOptions options) : base(options)
        {   }
    }
}