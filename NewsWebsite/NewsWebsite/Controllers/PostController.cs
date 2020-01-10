using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(string alias)
        {
            PostService postService = new PostService();
            CategoryService categoryService = new CategoryService();
            var data = postService.GetByAlias(alias);
            var category = categoryService.GetById(Convert.ToInt64(data.CategoryId));
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.MostReadPost = postService.GetList();
            return View(data);
        }

        public PartialViewResult LatestPostsPartial()
        {
            PostService postService = new PostService();
            var model = postService.GetList();
            return PartialView(model);
        }

        public PartialViewResult MostReadPostsPartial()
        {
            PostService postService = new PostService();
            var model = postService.GetList();
            return PartialView(model);
        }
    }
}