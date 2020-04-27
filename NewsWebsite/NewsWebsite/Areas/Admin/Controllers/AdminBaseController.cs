using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        // GET: Admin/AdminBase
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] == null || Session["UserId"].ToString() == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }

       
    }
}