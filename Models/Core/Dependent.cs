using System;
using System.ComponentModel.DataAnnotations;

namespace Carbon.Core.Models
{
    public class Dependent
    {
        [Key]
        public int Id { get; set; }
     
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Relationship { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
