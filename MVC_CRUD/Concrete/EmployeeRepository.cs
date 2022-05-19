using MVC_CRUD.Data;
using MVC_CRUD.Interface;
using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVC_CRUD.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<bool> CreateUpdateEmployee(EmployeeDepartmentViewModel empDeptViewModel)
        {
            using (EMSEntities1 ems = new EMSEntities1())
            {
                if (empDeptViewModel.EmployeeId == 0)
                {
                    var myResult = ems.Employees.Add(empDeptViewModel.ToViewModel());
                    return await ems.SaveChangesAsync() > 0 ? true : false;
                }
                else
                {
                    var myResult = ems.Employees.Where(y => y.Id == empDeptViewModel.EmployeeId).FirstOrDefault();
                    myResult.FirstName = empDeptViewModel.FirstName;
                    myResult.LastName = empDeptViewModel.LastName;
                    myResult.State = empDeptViewModel.State;
                    myResult.City = empDeptViewModel.City;
                    myResult.DeptId = empDeptViewModel.DepartmentId;

                    return await ems.SaveChangesAsync() > 0 ? true : false;
                }
            }
        }

        public Task<bool> DeleteEmployee(int employeeId)
        {
           
            using (EMSEntities1 ems = new EMSEntities1())
            {
                var emp = ems.Employees.Where(y => y.Id == employeeId).FirstOrDefault();
                ems.Employees.Remove(emp);
               return Task.FromResult(ems.SaveChanges()>0?true:false);
            }
        }

        public Task<EmployeeDepartmentViewModel> GetEmployeeById(int employeeId)
        {
            using (EMSEntities1 ems = new EMSEntities1())
            {
                var emp = ems.Employees.Where(y=>y.Id==employeeId).FirstOrDefault();
                return Task.FromResult(emp.ToViewModel());
            }
        }

        public Task<List<EmployeeDepartmentViewModel>> GetEmployees()
        {
            List<EmployeeDepartmentViewModel> employees = new List<EmployeeDepartmentViewModel>();
            using (EMSEntities1 ems = new EMSEntities1())
            {
                var emp = ems.Employees.ToList();
                var dept = ems.departments.ToList();

                employees = emp.Join(dept, y => y.DeptId, x => x.ID, (x, y) => new EmployeeDepartmentViewModel()
                {
                    EmployeeId = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    City = x.City,
                    State = x.State,
                    DepartmentName = y.DeptName,
                    DepartmentId = x.DeptId.Value
                }).ToList();
            }
            return Task.FromResult(employees);
        }
    }
}