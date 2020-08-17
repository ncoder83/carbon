using Carbon.Core.Models;
using System;

namespace Carbon.Models.DTO
{
    public class GetDiscountDto
    {
        public int Id { get; set; }
        public Benefit Benefit { get; set; }
        public decimal PercentDiscount { get; set; }
        public decimal FlatDiscount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class AddDiscountDto
    {        
        public Benefit Benefit { get; set; }
        public decimal PercentDiscount { get; set; }
        public decimal FlatDiscount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }     
    }

    public class UpdateDiscountDto
    {        
        public Benefit Benefit { get; set; }
        public decimal PercentDiscount { get; set; }
        public decimal FlatDiscount { get; set; }
        public string Description { get; set; }        
        public DateTime UpdatedDate { get; set; }
    }
}
