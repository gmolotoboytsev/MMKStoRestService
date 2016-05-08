using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MMKStoRestService.Controllers
{
    public class UserController : ApiController
    {
        private static stoEntities dataContext = new stoEntities();

        // GET: api/User
        public List<user> Get()
        {
            var query = from user in dataContext.user
                        select user;

            return query.ToList();
        }

        // PUT: api/User
        public string Put(user user)
        {
            user newuser = dataContext.user.Add(user);
            dataContext.SaveChanges();
            return newuser.id.ToString();
        }

        // DELETE: api/User
        public string Delete(service us)
        {
            var del_user = (from user in dataContext.user
                           where user.id == us.id
                           select user).SingleOrDefault();
            dataContext.user.Remove(del_user);
            dataContext.SaveChanges();
            return true.ToString();
        }

    }
}
