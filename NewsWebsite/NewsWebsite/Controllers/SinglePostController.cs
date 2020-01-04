using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class SinglePostController : Controller
    {
        // GET: SinglePost
        public ActionResult Index(long id)
        {
            PostService postService = new PostService();
            CategoryService categoryService = new CategoryService();
            var data = postService.GetById(id);
            var category = categoryService.GetById(Convert.ToInt64(data.CategoryId));
            ViewBag.CategoryName = category.CategoryName;
            return View(data);
        }
    }
}