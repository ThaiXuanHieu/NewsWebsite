using NewsWebsite.Data.Entities;
using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        // GET: Admin/Category
        public ActionResult Index()
        {
            
            var data = categoryService.GetList();
            return View(data);
        }

        public ActionResult Create(Category model)
        {

            model.CreatedBy = Convert.ToInt64(Session["UserID"]);
            model.CreatedTime = DateTime.Now;

            if(ModelState.IsValid)
            {
                try
                {
                    var action = categoryService.Create(model);
                    if(action)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Update(Category model)
        {
            model.CreatedBy = Convert.ToInt64(Session["UserID"]);
            model.CreatedTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    var action = categoryService.Update(model);
                    if (action)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sửa thất bại");
                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Sửa thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Sửa thất bại");
            }
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(long id)
        {
            var action = categoryService.Delete(id);
            var data = categoryService.GetList();
            if(data == null)
            {
                return HttpNotFound();
            }
            if(action)
            {
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return Json("Xóa thất bại", JsonRequestBehavior.AllowGet);
            }
        }
    }


}