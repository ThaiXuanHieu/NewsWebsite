using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Core
{
    public class UserLoginModel
    {
        [StringLength(5)]
        
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
