using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace MMKStoRestService.Controllers.Repositories
{
    public class UserRepository : IRepository<user>
    {
        private static stoEntities dataContext = new stoEntities();

        public bool Add(user item)
        {
            try
            {
                dataContext.user.Add(item);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }

        }

        public bool Delete(user item)
        {
            try
            {
                var del_user = (from user in dataContext.user
                               where user.id == item.id
                               select user).SingleOrDefault();
                dataContext.user.Remove(del_user);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }

        }

        public bool isUserExist(user item)
        {
            try
            {
                var del_user = (from user in dataContext.user
                                where user.id == item.id
                                select user).SingleOrDefault();
                if (del_user != null)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (EntityException ex)
            {
                return false;
            }
        }

        public List<user> GetAll()
        {
            var query = from user in dataContext.user
                        select user;
            return query.ToList();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

    }
}