using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Factory.SalaryCalculatorFactory
{
    public class ContractualSalaryCalculator : ISalaryCalculator
    {
        public decimal CalculateSalary(decimal absentDays = 0, decimal workedDays = 0)
        {
            int ratePerDay = 500;
            decimal salary = ratePerDay * workedDays;
            return salary;
        }
    }
}
