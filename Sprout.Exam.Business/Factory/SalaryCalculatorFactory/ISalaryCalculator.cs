using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Factory.SalaryCalculatorFactory
{
    public interface ISalaryCalculator
    {
        decimal CalculateSalary(decimal absentDays, decimal workedDays);
    }
}
