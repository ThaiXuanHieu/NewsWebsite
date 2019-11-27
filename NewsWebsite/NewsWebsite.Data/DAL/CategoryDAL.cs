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
