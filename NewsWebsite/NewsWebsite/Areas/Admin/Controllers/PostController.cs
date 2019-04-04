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
            return View("CreateHandle");
        }
    }
}