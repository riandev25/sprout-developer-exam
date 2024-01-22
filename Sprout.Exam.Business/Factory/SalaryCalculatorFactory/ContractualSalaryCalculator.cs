using System;

namespace Sprout.Exam.Business.Factory.SalaryCalculatorFactory
{
    public class ContractualSalaryCalculator : ISalaryCalculator
    {
        private const decimal RatePerDay = 500m;

        public decimal CalculateSalary(decimal absentDays, decimal workedDays)
        {
            decimal salary = RatePerDay * workedDays;
            return Math.Round(salary, 2, MidpointRounding.AwayFromZero);
        }
    }
}
