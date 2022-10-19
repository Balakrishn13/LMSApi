using LMS.DAO;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Handler
{
    public interface IAdminHandler
    {
        bool Registor(Registor registor);

        bool AddCourse(AddCourse addCourse);

        bool DeleteCourse(string courseId);

        bool Activate(string courseId);

        List<CourseDAO> GetAllCourse(string isActive);

        List<RegistorDAO> GetUser(Login login);
    }
}
