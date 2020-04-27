using NewsWebsite.Data.DAL;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Service
{
    public class UserRoleRelationshipService
    {
        UserRoleRelationshipDAL userRoleRelationshipDAL;

        public UserRoleRelationshipService()
        {
            userRoleRelationshipDAL = new UserRoleRelationshipDAL();
        }

        public UserRoleRelationship GetById(long id)
        {
            return userRoleRelationshipDAL.GetById(id);
        }
    }
}
