using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDepartmentViewModel>> GetEmployees();

        Task<bool> CreateUpdateEmployee(EmployeeDepartmentViewModel emp);

        Task<bool> DeleteEmployee(int employeeId);

        Task<EmployeeDepartmentViewModel> GetEmployeeById(int employeeId);
    }
}
