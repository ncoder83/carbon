using Carbon.Core.Models;
using Carbon.Models.Core;
using Microsoft.EntityFrameworkCore;

namespace Carbon.DataLayer.Context
{
    /// <summary>
    /// This class is our glue to our database
    /// </summary>
    public class CarbonDbContext : DbContext
    {
        public CarbonDbContext(DbContextOptions<CarbonDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// The tables that represents our data are defined below
        /// </summary>
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountHistory> AccountHistories { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<DependentType> DependentTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }
        public DbSet<Employer> Employers { get; set; }
    }
}
