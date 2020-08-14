using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carbon.Core.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        public Benefit Benefit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PercentDiscount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FlatDiscount { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
