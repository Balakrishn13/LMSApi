using LMD.Data.Models;
using LMS.Data.DAO;
using System.Collections.Generic;

namespace LMD.Data.Helper
{
    public interface IUserHelper
    {
        List<CourseDAO> GetAllCourse(Course course);
    }
}
