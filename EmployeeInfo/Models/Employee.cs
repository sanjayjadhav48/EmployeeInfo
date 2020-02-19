using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;


namespace EmployeeInfo.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<EmployeeDbContext>(new EmployeeDbInit());
        }
        public DbSet<Employee> Employees { get; set; } 
    }

    public class EmployeeDbInit : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            IList<Employee> DefaultEmployee = new List<Employee>();
            DefaultEmployee.Add(new Employee() { Id = 1, Name = "Sanjay", Branch = "Mumbai", Department="IT" });
            DefaultEmployee.Add(new Employee() { Id = 2, Name = "Pravin", Branch = "Mumbai", Department = "Sales" });
            DefaultEmployee.Add(new Employee() { Id = 3, Name = "Sachin", Branch = "Pune", Department = "HR" });
            DefaultEmployee.Add(new Employee() { Id = 4, Name = "Rupali", Branch = "Pune", Department = "Account" });
            DefaultEmployee.Add(new Employee() { Id = 5, Name = "John", Branch = "Delhi", Department = "Sales" });
            DefaultEmployee.Add(new Employee() { Id = 6, Name = "Pradipt", Branch = "Delhi", Department = "HR" });
            DefaultEmployee.Add(new Employee() { Id = 7, Name = "Vijay", Branch = "London", Department = "Account" });
            DefaultEmployee.Add(new Employee() { Id = 8, Name = "Jay", Branch = "London", Department = "IT" });

            context.Employees.AddRange(DefaultEmployee);

            base.Seed(context);

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
    }
}