using LMS.DAO;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Helper
{
   public interface IAdminHelper
    {
        bool Registor(Registor registor);

        bool AddCourse(AddCourse addCourse);

        bool DeleteCourse(string courseId);

        bool Activate(string courseId);

        List<CourseDAO> GetAllCourse(string isActive);
    }
}
