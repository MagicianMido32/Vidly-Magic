using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //only works when there's an exception in your code , 404 static resources are handled by IIS
            filters.Add(new HandleErrorAttribute());
            //Global filter, authorize the whole app
            filters.Add(new AuthorizeAttribute());
            //Https only
            filters.Add(new RequireHttpsAttribute());
        }
    }
}