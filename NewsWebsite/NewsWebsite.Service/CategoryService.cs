using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsWebsite.Data.DAL;
using NewsWebsite.Data.Entities;

namespace NewsWebsite.Service
{
    public class CategoryService
    {
        private CategoryDAL categoryDAL = new CategoryDAL();

        public bool Create(Category model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = categoryDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Category model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = categoryDAL.Update(model);
                return update;
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
                var update = categoryDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public Category GetById(long id)
        {
            return categoryDAL.GetById(id);
        }

        public Category GetByMetaTitle(string metatitle)
        {
            return categoryDAL.GetByMetaTitle(metatitle);
        }

        public IEnumerable<Category> GetList()
        {
            return categoryDAL.GetList();
        }
    }
}
