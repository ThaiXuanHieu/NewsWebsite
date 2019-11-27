using NewsWebsite.Data.Entities;
using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private PostService postService = new PostService();

        public ActionResult Index()
        {
            var data = postService.GetList();
            return View(data);
        }

        public ActionResult CreateHandle()
        {
            CategoryService categoryService = new CategoryService();
            var model = categoryService.GetList();
            return View(model);
        }

        public ActionResult CreateAction(Post model)
        {
            model.CreatedBy = Convert.ToInt64(Session["UserId"]);
            if (ModelState.IsValid)
            {
                try
                {
                    var action = postService.Create(model);
                    if (action)
                    {
                        return Redirect("/Admin/Post/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }
            return View("CreateHandle");
        }

        public ActionResult EditPost(long id)
        {
            CategoryService categoryService = new CategoryService();
            var model = postService.GetById(id);
            var category = categoryService.GetById(Convert.ToInt64(model.CategoryId));
            var categories = categoryService.GetList();
            List<string> categoryName = new List<string>();
            foreach (var item in categories)
            {
                categoryName.Add(item.CategoryName);
            }
            ViewBag.ListCategoryName = new SelectList(categoryName, category.CategoryName);
            return View(model);
        }
        public ActionResult EditPostAction(Post model)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var action = postService.Update(model);
                    if (action)
                    {
                        return Redirect("/Admin/Post/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sửa thất bại");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Sửa thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Sửa thất bại");
            }
            return View("EditPost");
        }
    }
}