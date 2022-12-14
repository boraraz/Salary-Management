using System;
using Microsoft.EntityFrameworkCore;
using SalaryManagementApp.Models;

namespace SalaryManagementApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Salary> Salaries => Set<Salary>();

    }
}

