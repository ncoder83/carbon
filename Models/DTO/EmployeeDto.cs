using Carbon.Business;
using Carbon.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Carbon.Models.DTO
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }        
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public decimal YearlySalary => Calculator.TotalPaidYearly(26, 2000);
        public string FormattedYearlySalary => YearlySalary.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        public decimal TotalBenefitCost { get; set; }
        public string FormattedBenefitCost => TotalBenefitCost.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        public string FormattedStartDate => StartDate.ToString("MMM dd yyyy");
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public string FormattedEndDate => EndDate.ToString("MMM dd yyyy");
        public DateTime CreatedDate { get; set; }
        public string FormattedCreatedDate => CreatedDate.ToString("MMM dd yyyy");
        public DateTime UpdatedDate { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
        public int TotalDependents => Dependents.Count;
        public bool IsActive => DateTime.Now >= StartDate && DateTime.Now < EndDate;
        public string FullName => FirstName + " " + MiddleName + " " + LastName;
    }

    public class AddEmployeeDto
    {        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BenefitId { get; set; }
        public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
    }

    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
        public DateTime UpdatedDate { get; set; }
        public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
