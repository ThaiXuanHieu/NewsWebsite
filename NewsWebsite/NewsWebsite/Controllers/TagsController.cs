using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class TagsController : Controller
    {
        // GET: Tags
        PostService postService = new PostService();

        public PartialViewResult TagsPartial()
        {
            var model = postService.GetList();
            return PartialView(model);
        }

    }
}