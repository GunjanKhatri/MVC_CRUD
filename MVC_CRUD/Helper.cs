using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD
{
    public static class Helper
    {
        public static Employee ToViewModel(this EmployeeDepartmentViewModel empDeptViewModel)
        {
            Employee emp = new Employee();
            emp.Id = empDeptViewModel.EmployeeId;
            emp.FirstName = empDeptViewModel.FirstName;
            emp.LastName = empDeptViewModel.LastName;
            emp.City = empDeptViewModel.City;
            emp.State = empDeptViewModel.State;
            emp.DeptId = empDeptViewModel.DepartmentId;

            return emp;
        }

        public static EmployeeDepartmentViewModel ToViewModel(this Employee employee)
        {
            EmployeeDepartmentViewModel emp = new EmployeeDepartmentViewModel();
            emp.EmployeeId = employee.Id;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.City = employee.City;
            emp.State = employee.State;
            emp.DepartmentId = employee.DeptId.Value;

            return emp;
        }

        public static SelectListItem ToViewModel(this department dept)
        {
            SelectListItem selectListItem = new SelectListItem();
            selectListItem.Text = dept.DeptName;
            selectListItem.Value = dept.ID.ToString();

            return selectListItem;
        }

        public static List<SelectListItem> ToViewModel(this List<department> departments)
        {
            var myResult = departments.Select(y => y.ToViewModel()).ToList();
            return myResult;
        }
    }
}