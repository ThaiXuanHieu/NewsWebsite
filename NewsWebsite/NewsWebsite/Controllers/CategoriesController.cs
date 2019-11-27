using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public PartialViewResult CategoriesPartial()
        {
            CategoryService catagoriesService = new CategoryService();
            var model = catagoriesService.GetList();

            return PartialView(model);
        }

    }
}