using NewsWebsite.Core;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

namespace NewsWebsite.Data.DAL
{
    public class PostDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Post GetById(long Id)
        {
            //Get from database
            var post = context.Posts
                .Where(i => i.Id == Id && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return post;
        }

        public Post GetByAlias(string alias)
        {
            var post = context.Posts
               .Where(i => i.Alias.Contains(alias) && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
               .FirstOrDefault();
            return post;
        }

        public IEnumerable<Post> GetList()
        {
            var post = context.Posts
               .Where(i => i.IsDeleted == false || i.IsDeleted.Equals(null))
               .OrderByDescending(i => i.CreatedTime)
               .Take(6)
               .ToList();
            return post;
        }

        public IEnumerable<Post> GetBySearchString(string searchString)
        {
            var post = context.Posts
                        .Where(i => i.Title.Contains(searchString) && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                        .ToList();
            return post;
        }

        public bool Update(Post model)
        {
            try
            {
                //Get item Post with Id from database
                var item = context.Posts.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.CategoryId = model.CategoryId;
                item.Title = model.Title;
                item.Content = model.Content;
                item.Summary = model.Summary;
                item.Resource = model.Resource;
                item.Image = model.Image;
                item.Tags = model.Tags;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.IsDeleted = model.IsDeleted;

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
                var post = new Post();

                //Set value for item with value from model
                post.CategoryId = model.CategoryId;
                post.Title = model.Title;
                post.Alias = StringHelper.VNDecode(model.Title);
                post.Content = model.Content;
                post.Summary = model.Summary;
                post.Resource = model.Resource;
                post.Image = model.Image;
                post.Tags = model.Tags;
                post.CreatedBy = model.CreatedBy;
                post.CreatedTime = DateTime.Now;
                post.IsDeleted = false;
                post.PostStatus = 0;

                //Add item to entity
                context.Posts.Add(post);
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
