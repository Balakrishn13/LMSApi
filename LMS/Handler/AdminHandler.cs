using LMS.DAO;
using LMS.Helper;
using LMS.Models;
using System.Collections.Generic;

namespace LMS.Handler
{
    public class AdminHandler: IAdminHandler
    {
       public readonly IAdminHelper _adminHelper;        
       
        public AdminHandler(IAdminHelper adminHelper)
        {
            this._adminHelper = adminHelper;
           
        }

        public bool Registor(Registor registor)
        {
            return _adminHelper.Registor(registor);
        }

        public bool AddCourse(AddCourse addCourse)
        {
            return _adminHelper.AddCourse(addCourse);
        }

        public bool DeleteCourse(string courseId)
        {
            return _adminHelper.DeleteCourse(courseId);
        }

        public List<CourseDAO> GetAllCourse(string isActive)
        {
            return _adminHelper.GetAllCourse(isActive);
        }

        public List<RegistorDAO> GetUser(Login login)
        {
            return _adminHelper.GetUser(login);
        }

        public bool Activate(string courseId)
        {
            return _adminHelper.Activate(courseId);
        }
    }
}
