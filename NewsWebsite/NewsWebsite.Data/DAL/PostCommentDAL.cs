using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class PostCommentDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public PostComment GetById(long Id)
        {
            //Get from database
            var postComment = context.PostComments
                .Where(i => i.Id == Id)//&& i.IsDeleted == false
                .FirstOrDefault();
            return postComment;
        }

        public bool Update(PostComment model)
        {
            try
            {
                //Get item PostComment with Id from database
                var item = context.PostComments.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(PostComment model)
        {
            try
            {
                //Initialization empty item
                var item = new PostComment();

                //Set value for item with value from model
                item.Id = model.Id;

                //Add item to entity
                context.PostComments.Add(item);
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
                var item = context.PostComments.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.PostComments.Remove(item);

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
