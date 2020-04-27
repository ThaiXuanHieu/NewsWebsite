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
                var login = userService.LoginByCredential(model.Username, model.Password);

                if (login == null)
                {
                    ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
                }
                else
                {
                    
                    var checkRole = userService.CheckRole(login);
                    if(checkRole == true)
                    {
                        Session["UserId"] = login.Id;
                        Session["Username"] = login.Username;
                        Session["Fullname"] = login.LastName + " " + login.FirstName;
                        return Redirect("/Admin/Home/Index");
                    }
                    else
                    {
                        Session["UserId"] = login.Id;
                        Session["Username"] = login.Username;
                        Session["Fullname"] = login.LastName + " " + login.FirstName;
                        return Redirect("/Home/Index");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
            }

            return View("Index");
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