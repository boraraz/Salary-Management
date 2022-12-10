using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryManagementApp.Models
{
	public class Salary
	{
		[Key]

		public int SId { get; set; }
		[Required]

		public Employee Name { get; set; }
		[ForeignKey("Employee")]

		public float Salry { get; set; }
        [ForeignKey("Employee")]

        public float tax { get; set; }

        public float NetSalary { get; set; }
    }
}

