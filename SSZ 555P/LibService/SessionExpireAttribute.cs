using System.Web.Mvc;
using System.Web;

namespace SSZ.LibService
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.Session["tabnumber"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/LogOff");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}