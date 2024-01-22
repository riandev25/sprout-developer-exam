using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.WebApp.Data;
using System.Threading;
using Sprout.Exam.Business.Factory.SalaryCalculatorFactory;


namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EfCoreEmployeesRepository _repository;
        public EmployeesController(EfCoreEmployeesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _repository.GetEmployees(cancellationToken);
                return Ok(employees);
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message );
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _repository.GetEmployeeById(id, cancellationToken);
                return Ok(employee);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _repository.EditEmployee(input, cancellationToken);
                return Ok(employee);
            } catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeDto input, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var id = await _repository.CreateEmployee(input, cancellationToken);
                return Created($"/api/employees/{id}", id);
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _repository.DeleteEmployee(id, cancellationToken);
                return Ok(employee);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate([FromBody] CalculateSalaryDto input, CancellationToken cancellationToken)
        {
            Console.WriteLine(input.AbsentDays);
            try
            {
                // Validate input parameters
                if (input.Id <= 0 || input.AbsentDays < 0 || input.WorkedDays < 0)
                {
                    ModelState.AddModelError("InvalidInput", "Id, absent days, and worked days must be non-negative.");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = await _repository.GetEmployeeById(input.Id, cancellationToken);
                if (employee is null)
                {
                    return NotFound();
                }

                EmployeeType employeeType = (EmployeeType)employee.TypeId;
                var salaryCalculatorFactory = SalaryCalculatorFactory.CreateSalaryCalculator(employeeType);

                var salary = salaryCalculatorFactory.CalculateSalary(input.AbsentDays, input.WorkedDays);
                return Created($"/api/employees/{employee.Id}/calculate", salary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
