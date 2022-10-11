using LMD.Data.Helper;
using LMD.Data.Models;
using LMS.Data.DAO;
using System.Collections.Generic;

namespace LMD.Data.Handler
{
    public class UserHandler: IUserHandler
    {
        public readonly IUserHelper _userHelper;

        public UserHandler(IUserHelper userHelper)
        {
            this._userHelper = userHelper;
        }

        public List<CourseDAO> GetAllCourse(Course course)
        {
            return _userHelper.GetAllCourse(course);
        }
    }
}
