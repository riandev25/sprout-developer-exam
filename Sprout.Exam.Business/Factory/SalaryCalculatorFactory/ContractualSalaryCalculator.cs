using System;

namespace Sprout.Exam.Business.Factory.SalaryCalculatorFactory
{
    public class ContractualSalaryCalculator : ISalaryCalculator
    {
        public decimal CalculateSalary(decimal absentDays, decimal workedDays)
        {
            decimal ratePerDay = 500M;
            decimal salary = ratePerDay * workedDays;
            salary = decimal.Round(salary, 2, MidpointRounding.AwayFromZero);
            return salary;
        }
    }
}
