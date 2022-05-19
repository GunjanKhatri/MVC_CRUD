using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC_CRUD.Interface
{
    public interface INotification
    {
        Task SendNotificationToEmployee();
    }
}