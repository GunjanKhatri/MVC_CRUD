using MVC_CRUD.Data;
using MVC_CRUD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public async Task<List<SelectListItem>> GetDepartments()
        {
            using(EMSEntities1 ems= new EMSEntities1())
            {
                var myResult = ems.departments.ToList().ToViewModel();
                return myResult;
            }
        }
    }
}