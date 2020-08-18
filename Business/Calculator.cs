namespace Carbon.Business
{
    public class Calculator
    {
        public static decimal TotalPaidYearly(int numberOfPaychecks, decimal amountPerPaycheck)
        {
            var total = numberOfPaychecks * amountPerPaycheck;
            if (total <= 0)
                return 0.00m;
            return total;
        }

        public static decimal TotalFromBenefit(decimal benefitCost, decimal costPerDependents, int numberOfDependents, decimal discount = 0)
        {
            var totalBenefit = benefitCost + (numberOfDependents * costPerDependents);
            var totalDiscount = totalBenefit * discount * 0.01m;
            return totalBenefit - totalDiscount;  
        }

        public static decimal TotalDiscount(string name)
        {
            name = name.Trim();
            return name[0].ToString().ToLower() == "a" ? 10.00m : 0.00m;           
        }
    }
}
