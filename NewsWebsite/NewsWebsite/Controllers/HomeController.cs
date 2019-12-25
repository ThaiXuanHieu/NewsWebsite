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
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoriesPartial()
        {
            CategoryService catagoriesService = new CategoryService();
            var model = catagoriesService.GetList();

            return PartialView(model);
        }

        public PartialViewResult LatestPostsPartial()
        {
            PostService postService = new PostService();
            var model = postService.GetList();
            return PartialView(model);
        }

        public PartialViewResult TagsPartial()
        {
            PostService postService = new PostService();
            var model = postService.GetList();
            return PartialView(model);
        }
    }
}