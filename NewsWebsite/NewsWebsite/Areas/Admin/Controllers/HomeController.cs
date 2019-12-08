using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            PostService postService = new PostService();
            var data = postService.GetList();
            return View(data);
        }

        
    }
}