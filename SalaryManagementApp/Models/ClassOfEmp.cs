using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementApp.Models
{
	public class ClassOfEmp
	{
		[Key]

		public int CId { get; set; }
		[Required]

		public string ClassName { get; set; }

		public float Salary { get; set; }

		public float NetSalary { get; set; }

		public MedAllow medAllow { get; set; }

		public TravAllow travAllow { get; set; }

    }
}

