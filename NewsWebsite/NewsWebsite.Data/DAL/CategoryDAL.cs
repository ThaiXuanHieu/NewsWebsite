using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class CategoryDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Category GetByCategoryName(string CategoryName)
        {
            //Get from database
            var category = context.Categories
                .Where(i => i.CategoryName == CategoryName && i.IsDeleted == false)
                .FirstOrDefault();
            return category;
        }

        public bool Update(Category model)
        {
            try
            {
                //Get item Category with Id from database
                var item = context.Categories.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.CategoryName = model.CategoryName;
                item.Level = model.Level;
                item.ParentId = model.ParentId;
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

        public bool Create(Category model)
        {
            try
            {
                //Initialization empty item
                var item = new Category();

                //Set value for item with value from model
                item.CategoryName = model.CategoryName;
                item.Level = model.Level;
                item.ParentId = model.ParentId;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Status = model.Status;
                //Add item to entity
                context.Categories.Add(item);
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
                var item = context.Categories.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Categories.Remove(item);

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
