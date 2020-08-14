using System;
using System.ComponentModel.DataAnnotations;

namespace Carbon.Core.Models
{
    public class EmployeeBenefit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Benefit Benefit { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
