using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class PostDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Post GetById(long Id)
        {
            //Get from database
            var post = context.Posts
                .Where(i => i.Id == Id && i.IsDeleted == false)
                .FirstOrDefault();
            return post;
        }

        public bool Update(Post model)
        {
            try
            {
                //Get item Post with Id from database
                var item = context.Posts.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;
                item.CategoryId = model.CategoryId;
                item.Title = model.Title;
                item.Content = model.Content;
                item.Summary = model.Summary;
                item.Resource = model.Resource;
                item.Image = model.Image;
                item.View = model.View;
                item.Tags = model.Tags;
                item.PostStatus = model.PostStatus;
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

        public bool Create(Post model)
        {
            try
            {
                //Initialization empty item
                var item = new Post();

                //Set value for item with value from model
                item.Id = model.Id;
                item.CategoryId = model.CategoryId;
                item.Title = model.Title;
                item.Content = model.Content;
                item.Summary = model.Summary;
                item.Resource = model.Resource;
                item.Image = model.Image;
                item.View = model.View;
                item.Tags = model.Tags;
                item.PostStatus = model.PostStatus;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.IsDeleted = model.IsDeleted;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                //Add item to entity
                context.Posts.Add(item);
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
                var item = context.Posts.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Posts.Remove(item);

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
