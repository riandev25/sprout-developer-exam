using Sprout.Exam.Common.Enums;
using System;


namespace Sprout.Exam.Business.Factory.SalaryCalculatorFactory
{
    public static class SalaryCalculatorFactory
    {
        public static ISalaryCalculator CreateSalaryCalculator(EmployeeType employeeType)
        {
            ISalaryCalculator calculatorDetails = employeeType switch
            {
                EmployeeType.Regular => new RegularSalaryCalculator(),
                EmployeeType.Contractual => new ContractualSalaryCalculator(),
                _ => throw new ArgumentException("Invalid employee type", nameof(employeeType)),
            };
            return calculatorDetails;
        }
    }
}
