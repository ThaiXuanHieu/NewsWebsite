using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string metatitle)
        {
            PostService postService = new PostService();
            CategoryService categoryService = new CategoryService();
            var category = categoryService.GetByMetaTitle(metatitle);
            var data = postService.GetByCategoryId(category.Id);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.MostReadPost = postService.GetList();
            return View(data);
        }
    }
}