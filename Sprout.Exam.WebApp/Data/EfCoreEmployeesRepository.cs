using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business;
using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Data
{
    public class EfCoreEmployeesRepository: IEmployeesRepository
    {
        private readonly ApplicationDbContext _context;
        public EfCoreEmployeesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeDto>> GetEmployees(CancellationToken cancellationToken)
        {
            var employeesResults = await _context.Employee
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return employeesResults;
        }
        public async Task<int> CreateEmployee(CreateEmployeeDto input, CancellationToken cancellationToken)
        {
            var newEmployee = new EmployeeDto
            {
                FullName = input.FullName,
                Birthdate = input.Birthdate,
                Tin = input.Tin,
                TypeId = input.TypeId
            };

            _context.Employee.Add(newEmployee);

            await _context.SaveChangesAsync(cancellationToken);

            return newEmployee.Id;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employee
                .Where(e => e.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee not found");
            }
            return employee;
        }

        public async Task<EmployeeDto> EditEmployee(EditEmployeeDto input, CancellationToken cancellationToken)
        {
            var existingEmployee = await _context.Employee
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (existingEmployee is null)
            {
                throw new ArgumentNullException(nameof(existingEmployee), "Employee not found");
            }
            existingEmployee.FullName = input.FullName;
            existingEmployee.Birthdate = input.Birthdate;
            existingEmployee.Tin = input.Tin;
            existingEmployee.TypeId = input.TypeId;
            await _context.SaveChangesAsync(cancellationToken);

            return existingEmployee;
        }

        public async Task<int> DeleteEmployee(int id, CancellationToken cancellationToken)
        {
            var existingEmployee = await _context.Employee
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (existingEmployee is null)
            {
                throw new ArgumentNullException(nameof(existingEmployee), "Employee not found");
            }
            var deletedEmployeeId = existingEmployee.Id;
            _context.Employee.Remove(existingEmployee);
            await _context.SaveChangesAsync(cancellationToken);
            return deletedEmployeeId;
        }
    }
}
