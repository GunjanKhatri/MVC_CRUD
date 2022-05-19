using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Interface
{
    public interface IDepartmentRepository
    {
        /// <summary>
        ///  This will get information of department
        /// </summary>
        /// <returns>this is will return list of department</returns>
        Task<List<SelectListItem>> GetDepartments();
    }
}
