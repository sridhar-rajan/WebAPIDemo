using System.Web;
using System.Web.Mvc;
using WebMVCConsumeWebAPI.Filters;

namespace WebMVCConsumeWebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            //filters.Add(new ErrorFilter());
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}
