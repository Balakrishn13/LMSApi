using LMS.Helper;
using LMS.Models;


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
    }
}
