using FluentAssertions;
using Microsoft.VisualBasic;
using Sprout.Exam.Business.Factory.SalaryCalculatorFactory;
using Sprout.Exam.Common.Enums;
using Xunit;

namespace Sprout.Exam.Business.Tests.Unit
{
    public class CalculateSalaryFactoryTests
    {
        [Fact]
        public void RegularSalaryCalculator_ReturnsSalaryForHalfDayAbsence()
        {
            // Arrange
            var calculator = new RegularSalaryCalculator();
            decimal absentDays = 2.5M;
            decimal workedDays = 0;

            // Act
            decimal result = calculator.CalculateSalary(absentDays, workedDays);

            // Assert
            result.Should().BePositive();
            result.Should().Be(15327.5M);
        }

        [Fact]
        public void ContractualSalaryCalculator_ReturnsSalaryForFullWorkedDays()
        {
            // Arrange
            var calculator = new ContractualSalaryCalculator();
            decimal absentDays = 0;
            decimal workedDays = 4;

            // Act
            decimal result = calculator.CalculateSalary(absentDays, workedDays);

            // Assert
            result.Should().BePositive();
            result.Should().Be(2000);
        }

        [Fact]
        public void FactorySalaryCalculator_ReturnsSalaryForCertainEmployeeType()
        {
            // Arrange
            int employeeTypeId = 2; // Regular = 1, Contractual = 2
            EmployeeType employeeType = (EmployeeType)employeeTypeId;
            var salaryCalculatorFactory = SalaryCalculatorFactory.CreateSalaryCalculator(employeeType);
            decimal absentDays = 0;
            decimal workedDays = 6;

            // Act
            var result = salaryCalculatorFactory.CalculateSalary(absentDays, workedDays);

            // Arrange
            result.Should().BePositive();
            result.Should().Be(3000);
        }
    }
}
