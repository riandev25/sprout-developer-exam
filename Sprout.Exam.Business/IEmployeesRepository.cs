using Sprout.Exam.Business.DataTransferObjects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business
{
        public interface IEmployeesRepository
        {
            Task<List<EmployeeDto>> GetEmployees(CancellationToken cancellationToken);
            Task<EmployeeDto> GetEmployeeById(int id, CancellationToken cancellationToken);
            Task<int> CreateEmployee(CreateEmployeeDto input, CancellationToken cancellationToken);
            Task<EmployeeDto> EditEmployee(EditEmployeeDto input, CancellationToken cancellationToken);
            Task<int> DeleteEmployee(int id, CancellationToken cancellationToken);
        }

}
