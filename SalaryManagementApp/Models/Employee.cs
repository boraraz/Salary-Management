using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementApp.Models
{
	public class Employee
	{
		[Key]

		public int EId { get; set; }
		[Required]

		public string Name { get; set; }

		public string Address { get; set; }

		public DateTime DOB { get; set; }

		public DateTime Designation { get; set; }

		public float Salary { get; set; }

        public MedAllow medAllow { get; set; }

        public TravAllow travAllow { get; set; }

    }
}

