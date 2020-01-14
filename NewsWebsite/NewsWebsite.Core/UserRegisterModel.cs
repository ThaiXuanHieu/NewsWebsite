using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Core
{
    public class UserRegisterModel
    {
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Họ không được để trống")]
        public string FirstName { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string LastName { get; set; }
    }
}
