using NewsWebsite.Data.Entities;
using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
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
        [ValidateInput(false)]
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

        [ValidateInput(false)]
        public ActionResult EditPostHandle(Post model)
        {
            model.CreatedBy = Convert.ToInt64(Session["UserId"]);
            model.CreatedTime = DateTime.Now;
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

            if(action)
            {
                return RedirectToAction("Index");
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