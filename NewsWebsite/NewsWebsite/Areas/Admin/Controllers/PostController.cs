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

        public void SetViewBag(long? selectedID = null)
        {
            CategoryService categoryService = new CategoryService();

            ViewBag.CategoryId = new SelectList(categoryService.GetList(), "Id", "CategoryName", selectedID);
        }

        public ActionResult CreateHandle()
        {
            CategoryService categoryService = new CategoryService();
            SetViewBag();
            return View();
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
            SetViewBag(model.Id);
            return View("CreateHandle");
        }

        

        public ActionResult EditPost(long id)
        {
            CategoryService categoryService = new CategoryService();
            var model = postService.GetById(id);
            var category = categoryService.GetById(Convert.ToInt64(model.CategoryId));
            SetViewBag(category.Id);
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
            SetViewBag(model.Id);
            return View("EditPost");
        }

        public ActionResult DeletePost(long id)
        {
            var action = postService.Delete(id);
            var data = postService.GetList();
            if(data == null)
            {
                return HttpNotFound();
            }
            if(action)
            {
                return View("Index", data);
            }
            return View("Index");
        }

        public ActionResult SearchHandle(string searchString)
        {
            var data = postService.GetBySearchString(searchString);
            if(data == null)
            {
                return HttpNotFound();
            }
            return View("Index", data);
        }
    }
}