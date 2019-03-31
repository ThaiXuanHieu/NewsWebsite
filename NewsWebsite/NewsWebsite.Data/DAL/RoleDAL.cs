using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class RoleDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Role GetById(long Id)
        {
            //Get from database
            var role = context.Roles
                .Where(i => i.Id == Id && i.IsDeleted == false)//
                .FirstOrDefault();
            return role;
        }

        public bool Update(Role model)
        {
            try
            {
                //Get item Role with Id from database
                var item = context.Roles.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;
                item.Role1 = model.Role1;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Status = model.Status;
                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Role model)
        {
            try
            {
                //Initialization empty item
                var item = new Role();

                //Set value for item with value from model
                item.Id = model.Id;
                item.Role1 = model.Role1;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Status = model.Status;

                //Add item to entity
                context.Roles.Add(item);
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
                var item = context.Roles.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Roles.Remove(item);

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
