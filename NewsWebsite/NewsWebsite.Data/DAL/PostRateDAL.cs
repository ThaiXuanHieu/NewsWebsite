using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    class PostRateRateDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public PostRate GetById(long Id)
        {
            //Get from database
            var postRate = context.PostRates
                .Where(i => i.Id == Id)//&& i.IsDeleted == false
                .FirstOrDefault();
            return postRate;
        }

        public bool Update(PostRate model)
        {
            try
            {
                //Get item PostRate with Id from database
                var item = context.PostRates.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Id = model.Id;
                item.PostId = model.PostId;
                item.RatedBy = model.RatedBy;
                item.Mark = model.Mark;
                item.RatedTime = model.RatedTime;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(PostRate model)
        {
            try
            {
                //Initialization empty item
                var item = new PostRate();

                //Set value for item with value from model
                item.Id = model.Id;
                item.PostId = model.PostId;
                item.RatedBy = model.RatedBy;
                item.Mark = model.Mark;
                item.RatedTime = model.RatedTime;
                //Add item to entity
                context.PostRates.Add(item);
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
                var item = context.PostRates.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.PostRates.Remove(item);

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
