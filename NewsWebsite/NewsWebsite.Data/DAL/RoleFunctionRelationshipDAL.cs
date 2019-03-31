using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class RoleFunctionRelationshipFunctionRelationshipDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public RoleFunctionRelationship GetById(long Id)
        {
            //Get from database
            var roleFunctionRelationship = context.RoleFunctionRelationships
                .Where(i => i.Id == Id && i.IsDeleted == false)//
                .FirstOrDefault();
            return roleFunctionRelationship;
        }

        public bool Update(RoleFunctionRelationship model)
        {
            try
            {
                //Get item RoleFunctionRelationship with Id from database
                var item = context.RoleFunctionRelationships.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;
                item.RoleId = model.RoleId;
                item.FunctionId = model.FunctionId;
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

        public bool Create(RoleFunctionRelationship model)
        {
            try
            {
                //Initialization empty item
                var item = new RoleFunctionRelationship();

                //Set value for item with value from model
                item.Id = model.Id;
                item.RoleId = model.RoleId;
                item.FunctionId = model.FunctionId;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;

                //Add item to entity
                context.RoleFunctionRelationships.Add(item);
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
                var item = context.RoleFunctionRelationships.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.RoleFunctionRelationships.Remove(item);

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
