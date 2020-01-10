using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    public class CategoryDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Category GetById(long Id)
        {
            //Get from database
            var category = context.Categories
                .Where(i => i.Id == Id && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return category;
        }

        public Category GetByMetaTitle(string metatitle)
        {
            //Get from database
            var category = context.Categories
                .Where(i => i.MetaTitle == metatitle && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return category;
        }

        public IEnumerable<Category> GetList()
        {
            var Category = context.Categories
               .Where(i => i.IsDeleted == false || i.IsDeleted.Equals(null))
               .ToList();
            return Category;
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
                var category = new Category();

                //Set value for item with value from model

                category.CategoryName = model.CategoryName;
                category.Level = model.Level;
                category.ParentId = model.ParentId;
                category.CreatedBy = model.CreatedBy;
                category.CreatedTime = model.CreatedTime;
                category.ModifiedBy = model.ModifiedBy;
                category.ModifiedTime = model.ModifiedTime;
                category.IsDeleted = model.IsDeleted;
                category.DeletedBy = model.DeletedBy;
                category.DeletedTime = model.DeletedTime;
                //Add item to entity
                context.Categories.Add(category);
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
