using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class LatestPostsController : Controller
    {
        // GET: NewestPosts
        PostService postService = new PostService();

        public PartialViewResult LatestPostsPartial()
        {
            var model = postService.GetList();
            return PartialView(model);
        }
    }
}