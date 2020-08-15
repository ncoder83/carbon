using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Models.DTO
{
    public class AddBenefitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerYear { get; set; }
        public decimal CostPerDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class GetBenefitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerYear { get; set; }
        public decimal CostPerDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class UpdateBenefitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerYear { get; set; }
        public decimal CostPerDependent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
