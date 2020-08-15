using System.ComponentModel.DataAnnotations;

namespace Carbon.Models.Core
{
    public class DependentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
