using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    public class UserDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public User GetByUsername(string username)
        {
            //Get from database
            var user = context.Users
                .Where(i => i.Username == username && i.IsDeleted == false)
                .FirstOrDefault();
            return user;
        }

        public bool Update(User model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Users.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Username = model.Username;
                item.PasswordEncrypted = model.PasswordEncrypted;
                item.PasswordSalt = model.PasswordSalt;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Sex = model.Sex;
                item.DateOfBirth = model.DateOfBirth;
                item.PhoneNumber = model.PhoneNumber;
                item.Email = model.Email;
                item.Address = model.Address;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(User model)
        {
            try
            {
                //Initialization empty item
                var item = new User();

                //Set value for item with value from model
                item.Username = model.Username;
                item.PasswordEncrypted = model.PasswordEncrypted;
                item.PasswordSalt = model.PasswordSalt;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Sex = model.Sex;
                item.DateOfBirth = model.DateOfBirth;
                item.PhoneNumber = model.PhoneNumber;
                item.Email = model.Email;
                item.Address = model.Address;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                //Add item to entity
                context.Users.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.Users.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Users.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
