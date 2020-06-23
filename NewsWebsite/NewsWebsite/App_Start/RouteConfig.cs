using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewsWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Account",
                url: "tai-khoan",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NewsWebsite.Controllers" }
            );
            
            routes.MapRoute(
                name: "Post",
                url: "{alias}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NewsWebsite.Controllers" }
            );

            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{metatitle}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NewsWebsite.Controllers" }
            );

            routes.MapRoute(
                name: "CreatePost",
                url: "Admin/tao-bai-viet",
                defaults: new { Areas = "Admin", controller = "Post", action = "CreateHandle", id = UrlParameter.Optional },
                namespaces: new[] { "NewsWebsite.Areas.Admin.Controllers" }
            );
            
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}", // => ""
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NewsWebsite.Controllers" }
            );
            
        }
    }
}
