using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.DAL
{
    public class UserRoleRelationshipDAL
    {
        DefaultDbContext context;

        public UserRoleRelationshipDAL()
        {
            context = new DefaultDbContext();
        }

        public UserRoleRelationship GetById(long id)
        {
            return context.UserRoleRelationships.Where(i => i.UserId == id).FirstOrDefault();
            
        }
    }
}
