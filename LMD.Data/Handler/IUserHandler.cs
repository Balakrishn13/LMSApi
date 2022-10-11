using LMD.Data.Models;
using LMS.Data.DAO;
using System.Collections.Generic;

namespace LMD.Data.Handler
{
    public interface IUserHandler
    {
        List<CourseDAO> GetAllCourse(Course course);
    }
}
