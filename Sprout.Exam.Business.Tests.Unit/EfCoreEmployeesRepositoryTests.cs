using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using NSubstitute;
using Sprout.Exam.Business.DataTransferObjects;
using FluentAssertions;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Tests.Unit
{
    public class EfCoreEmployeesRepositoryTests
    {
        [Fact]
        public async Task GetEmployees_ReturnsEmployeesList()
        {
            // Arrange
            var _context = Substitute.For<IEmployeesRepository>();
            var token = new CancellationTokenSource().Token;
            List<EmployeeDto> employees = new()
            {
                new() { Id = 1, FullName = "John Doe", Birthdate = new DateTime(1990, 5, 15), Tin = "123456789", TypeId = 1 },
                new() { Id = 2, FullName = "Jane Smith", Birthdate = new DateTime(1985, 8, 22), Tin = "987654321", TypeId = 2 },
            };
            _ = _context.GetEmployees(token).Returns(employees);

            // Act
            var result = await _context.GetEmployees(token);

            // Assert
            _ = result.Should().NotBeNull();
            _ = result.Should().BeOfType<List<EmployeeDto>>();
            _ = result.Count.Should().Be(2);
            _ = result[0].FullName.Should().Be("John Doe");
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsEmployee()
        {
            // Arrange
            var _context = Substitute.For<IEmployeesRepository>();
            var token = new CancellationTokenSource().Token;
            EmployeeDto expectedEmployee = new() { Id = 1, FullName = "Jane Smith", Birthdate = new DateTime(1985, 8, 22), Tin = "987654321", TypeId = 1 };
            int inputEmployeeId = 1;
            _context.GetEmployeeById(inputEmployeeId, token).Returns(expectedEmployee);

            // Act
            var result = await _context.GetEmployeeById(1, token);

            // Assert
            _ = result.Should().NotBeNull();
            _ = result.Should().BeOfType<EmployeeDto>();
            _ = result.Id.Should().Be(expectedEmployee.Id);
            _ = result.FullName.Should().Be(expectedEmployee.FullName);
            _ = result.Birthdate.Should().Be(expectedEmployee.Birthdate);
            _ = result.Tin.Should().Be(expectedEmployee.Tin);
            _ = result.TypeId.Should().Be(expectedEmployee.TypeId);
        }

        [Fact]
        public async Task CreateEmployee_ReturnsCreatedEmployee()
        {
            // Arrange
            var _context = Substitute.For<IEmployeesRepository>();
            var token = new CancellationTokenSource().Token;
            int expectedEmployeeId = 3;
            CreateEmployeeDto createEmployeeInput = new() { FullName = "Jane Smith", Birthdate = new DateTime(1985, 8, 22), Tin = "987654321", TypeId = 1 };
            _context.CreateEmployee(createEmployeeInput, token).Returns(expectedEmployeeId);

            // Arrange
            var result = await _context.CreateEmployee(createEmployeeInput, token);

            // Assert
            _ = result.Should().BeGreaterThan(0);
            _ = result.Should().Be(expectedEmployeeId);
        }

        [Fact]
        public async Task EditEmployee_ReturnsEditedEmployee()
        {
            // Arrange
            var _context = Substitute.For<IEmployeesRepository>();
            var token = new CancellationTokenSource().Token;
            EmployeeDto expectedEmployee = new() { Id = 1, FullName = "Jane Smith", Birthdate = new DateTime(1985, 8, 22), Tin = "987654321", TypeId = 1 };
            EditEmployeeDto editEmployee = new() { Id = 1, FullName = "Jane Smith", Birthdate = new DateTime(1985, 8, 22), Tin = "987654321", TypeId = 1 };

            _context.EditEmployee(editEmployee, token).Returns(expectedEmployee);

            // Act
            var result = await _context.EditEmployee(editEmployee, token);

            // Assert
            _ = result.Should().NotBeNull();
            _ = result.Should().BeOfType<EmployeeDto>();
            _ = result.Id.Should().Be(expectedEmployee.Id);
            _ = result.FullName.Should().Be(expectedEmployee.FullName);
            _ = result.Birthdate.Should().Be(expectedEmployee.Birthdate);
            _ = result.Tin.Should().Be(expectedEmployee.Tin);
            _ = result.TypeId.Should().Be(expectedEmployee.TypeId);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsDeletedEmployeeId()
        {
            // Arrange
            var _context = Substitute.For<IEmployeesRepository>();
            var token = new CancellationTokenSource().Token;
            int expectedEmployeeId = 2;
            int inputEmployeeId = 2;
            _context.DeleteEmployee(inputEmployeeId, token).Returns(expectedEmployeeId);

            // Act
            var result = await _context.DeleteEmployee(inputEmployeeId, token);

            // Assert
            _ = result.Should().BeGreaterThan(0);
            _ = result.Should().Be(expectedEmployeeId);
        }
    }

}
