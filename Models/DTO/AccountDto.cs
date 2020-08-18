using System;
using System.Globalization;

namespace Carbon.Models.DTO
{
    public class GetAccountDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string FormattedAmount => Amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
