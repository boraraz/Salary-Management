using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagementApp.Models
{
	public class Account
	{
        [Key]

        public int AccId { get; set; }
        [Required]

        public string Mail { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}

