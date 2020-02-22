using NewsWebsite.Data.DAL;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Service
{
    public class PostService
    {
        private PostDAL postDAL = new PostDAL();

        public bool Create(Post model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = postDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Post model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = postDAL.Update(model);
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
                var update = postDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public Post GetById(long id)
        {
            return postDAL.GetById(id);
        }

        public IEnumerable<Post> GetByCategoryId(long id)
        {
            return postDAL.GetByCategoryId(id);
        }

        public IEnumerable<string> GetListTitle(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                return null;
            }
            return postDAL.GetListTitle(searchString);
        }

        public IEnumerable<Post> GetBySearchString(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                return null;
            }
            return postDAL.GetBySearchString(searchString);
        }

        public Post GetByAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return null;
            }
            return postDAL.GetByAlias(alias);
        }

        public IEnumerable<Post> GetList()
        {
            return postDAL.GetList();
        }
    }
}
