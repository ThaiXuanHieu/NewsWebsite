using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class HomeController : Controller
    {
        PostService postService = new PostService();

        public ActionResult Index()
        {
            return View();
        }
    }
}