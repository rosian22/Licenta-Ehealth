using EHealth.Helpers;
using System.Web;
using System.Web.Mvc;

namespace EHealth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalIdentityInjectorAttribute());
        }
    }
}
