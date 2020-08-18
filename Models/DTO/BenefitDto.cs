using System;
using System.Globalization;

namespace Carbon.Models.DTO
{
    public class GetBenefitDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal CostPerYear { get; set; }
        public string FormattedCostPerYear => CostPerYear.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        public decimal CostPerDependent { get; set; }
        public string FormattedCostPerDependent => CostPerDependent.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        public DateTime CreatedDate { get; set; }
        public string FormattedCreatedDate => CreatedDate.ToString("MMM dd yyyy");
        public DateTime UpdatedDate { get; set; } 
    }

    public class AddBenefitDto
    {        
        public string Title { get; set; }
        public decimal CostPerYear { get; set; }
        public decimal CostPerDependent { get; set; }
        public DateTime CreatedDate { get; set; }        
    }

    
    public class UpdateBenefitDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal CostPerYear { get; set; }
        public decimal CostPerDependent { get; set; }        
        public DateTime UpdatedDate { get; set; }
    }
}
