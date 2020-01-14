using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsWebsite.Core;
using NewsWebsite.Data.DAL;
using NewsWebsite.Data.Entities;

namespace NewsWebsite.Service
{
    public class UserService
    {
        public User LoginByCredential(string username, string password)
        {
            UserDAL userDAL = new UserDAL();

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = userDAL.GetByUsername(username);
            if (user == null)
            {
                return null;
            }

            var passwordSalt = user.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == user.PasswordEncrypted)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public bool Create(User model)
        {
            UserDAL userDAL = new UserDAL();
            try
            {
                if(model == null)
                {
                    return false;
                }
                var create = userDAL.Create(model);
                return create;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CreateForFacebook(User model)
        {
            UserDAL userDAL = new UserDAL();
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = userDAL.CreateForFacebook(model);
                return create;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CkeckUserName(string username)
        {
            UserDAL userDAL = new UserDAL();
            if (String.IsNullOrEmpty(username))
            {
                return false;
            }
            var count = userDAL.GetByUsername(username);
            if(count != null)
            {
                return true;
            }
            return false;
        }

        public bool CkeckEmail(string email)
        {
            UserDAL userDAL = new UserDAL();
            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            var count = userDAL.GetByEmail(email);
            if (count != null)
            {
                return true;
            }
            return false;
        }
    }
}
