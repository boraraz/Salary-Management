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

        public float Tax { get; set; }

        public float SalaryFrom { get; set; }

        public float SalaryTo { get; set; }

		public float YearlyBonusPercentage { get; set; }
    }
}

