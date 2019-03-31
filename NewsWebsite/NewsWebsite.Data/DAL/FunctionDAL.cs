using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class FunctionDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Function GetById(long Id)
        {
            //Get from database
            var function = context.Functions
                .Where(i => i.Id == Id && i.IsDeleted == false)//
                .FirstOrDefault();
            return function;
        }

        public bool Update(Function model)
        {
            try
            {
                //Get item Function with Id from database
                var item = context.Functions.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;
                item.Function1 = model.Function1;
                item.Level = model.Level;
                item.ParentId = model.ParentId;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifieTime = model.ModifieTime;
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

        public bool Create(Function model)
        {
            try
            {
                //Initialization empty item
                var item = new Function();

                //Set value for item with value from model
                item.Id = model.Id;
                item.Function1 = model.Function1;
                item.Level = model.Level;
                item.ParentId = model.ParentId;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifieTime = model.ModifieTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Status = model.Status;

                //Add item to entity
                context.Functions.Add(item);
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
                var item = context.Functions.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Functions.Remove(item);

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
