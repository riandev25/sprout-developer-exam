using System;
namespace Sprout.Exam.Business.Factory.SalaryCalculatorFactory
{
    public class RegularSalaryCalculator : ISalaryCalculator
    {
        public decimal CalculateSalary(decimal absentDays, decimal workedDays)
        {
            int baseSalary = 20000;
            decimal tax = 0.12m;

            decimal absentSalaryDeduction = baseSalary / 22 * absentDays;
            decimal taxSalaryDeduction = baseSalary * tax;
            decimal salary = baseSalary - absentSalaryDeduction - taxSalaryDeduction;

            return salary;
        }
    }
}
