using LMS.Helper;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Handler
{
    public class AdminHandler: IAdminHandler
    {
        private readonly IAdminHelper _adminHelper;

        public bool Handler(Registor registor)
        {
            return _adminHelper.Registor(registor);
        }
    }
}
