using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsWebsite.Core;
using NewsWebsite.Data.DAL;

namespace NewsWebsite.Service
{
    class CustomerService
    {
        public bool LoginByCredential(string username, string password)
        {
            CustomerDAL userDAL = new CustomerDAL();

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = userDAL.GetByUsername(username);
            if (user == null)
            {
                return false;
            }

            var passwordSalt = user.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == user.PasswordEncrypted)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
