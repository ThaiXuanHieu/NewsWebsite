using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class UserRoleRelationshipDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public UserRoleRelationship GetById(long Id)
        {
            //Get from database
            var userRoleRelationship = context.UserRoleRelationships
                .Where(i => i.Id == Id && i.IsDeleted == false)//
                .FirstOrDefault();
            return userRoleRelationship;
        }

        public bool Update(UserRoleRelationship model)
        {
            try
            {
                //Get item UserRoleRelationship with Id from database
                var item = context.UserRoleRelationships.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;
                item.UserId = model.UserId;
                item.RoleId = model.RoleId;
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

        public bool Create(UserRoleRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new UserRoleRelationship();

                //Set value for item with value from model
                item.Id = model.Id;
                item.UserId = model.UserId;
                item.RoleId = model.RoleId;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;

                //Add item to entity
                context.UserRoleRelationships.Add(item);
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
                var item = context.UserRoleRelationships.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.UserRoleRelationships.Remove(item);

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
