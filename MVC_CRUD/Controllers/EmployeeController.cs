using MVC_CRUD.Concrete;
using MVC_CRUD.Interface;
using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            IEmployeeRepository employee = new EmployeeRepository();
            var myResult = await employee.GetEmployees();
            return View(myResult);
        }

        public async Task<ActionResult> Create()
        {
            EmployeeDepartmentViewModel employeeDepartmentViewModel = new EmployeeDepartmentViewModel();
            IDepartmentRepository deptRepo = new DepartmentRepository();
            employeeDepartmentViewModel.Data = await deptRepo.GetDepartments();

            return View(employeeDepartmentViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            IEmployeeRepository empRepo = new EmployeeRepository();
            SendNotification send = new SendNotification();
            var myResult = await empRepo.CreateUpdateEmployee(employeeDepartmentViewModel);
            send.SendNotificationToEmployee();
            if (myResult)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            IEmployeeRepository empRepo = new EmployeeRepository();
            var result= await empRepo.DeleteEmployee(employeeId);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditEmployee(int employeeId)
        {
            IEmployeeRepository empRepo = new EmployeeRepository();
            IDepartmentRepository deptRepo = new DepartmentRepository();
            var result = await empRepo.GetEmployeeById(employeeId);
            result.Data = await deptRepo.GetDepartments();

            return View("Create", result);
        }
    }
}