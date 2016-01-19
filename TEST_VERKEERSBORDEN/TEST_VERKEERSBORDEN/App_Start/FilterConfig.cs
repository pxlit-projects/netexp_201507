using System.Web;
using System.Web.Mvc;

namespace TEST_VERKEERSBORDEN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
