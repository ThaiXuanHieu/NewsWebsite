using Facebook;
using NewsWebsite.Core;
using NewsWebsite.Data.Entities;
using NewsWebsite.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebsite.Controllers
{
    public class AccountController : Controller
    {

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UserLoginModel model)
        {
            UserService userService = new UserService();

            if (ModelState.IsValid)
            {
                var action = userService.LoginByCredential(model.Username, model.Password);

                if (action == null)
                {
                    ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
                }
                else
                {
                    Session["UserId"] = action.Id;
                    Session["Username"] = action.Username;
                    Session["Fullname"] = action.LastName + " " + action.FirstName;
                    return Redirect("/Home/Index");
                }
            }
            else
            {
                ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
            }

            return View("Index");
        }

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",

            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name etc
                dynamic me = fb.Get("me?fields=first_name, last_name, id, email");
                long id = Int64.Parse(me.id);
                string firstName = me.first_name;
                string lastName = me.last_name;

                var user = new User();
                user.Id = id;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.CreatedTime = DateTime.Now;
                var action = new UserService().CreateForFacebook(user);
                if (action)
                {
                    Session["UserId"] = user.Id;
                    Session["Username"] = user.Username;
                    Session["Fullname"] = user.LastName + " " + user.FirstName;
                }
            }
            return Redirect("/Home/Index");
        }

        public ActionResult Register(UserRegisterModel model)
        {
            UserService userService = new UserService();
            if (ModelState.IsValid)
            {
                if (userService.CkeckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else
                {
                    User user = new User();
                    user.Username = model.UserName;
                    string passwordSalt = PasswordHash.GeneratePasswordSalt();
                    user.PasswordSalt = passwordSalt;
                    user.PasswordEncrypted = PasswordHash.EncryptionPasswordWithSalt(model.Password, passwordSalt);
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    var action = userService.Create(user);
                    if (action)
                    {
                        ViewBag.Message = "Đăng ký thành công";
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");

                    }
                }

            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/Home/Index");
        }
    }
}