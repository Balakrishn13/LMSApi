using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Handler
{
   public interface IAdminHandler
    {
        bool Registor(Registor registor);
    }
}
