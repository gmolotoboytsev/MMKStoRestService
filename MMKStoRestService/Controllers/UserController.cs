﻿using MMKStoRestService.Controllers.Repositories;
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
        private static UserRepository db = new UserRepository();

        // GET: api/User
        public List<user> Get()
        {
            return db.GetAll();
        }

        // POST: api/User
        public bool Post(user user)
        {
            return db.isUserExist(user);
        }

        // PUT: api/User
        public bool Put(user user)
        {
            return db.Add(user);
        }

        // DELETE: api/User
        public bool Delete(user us)
        {
            return db.Delete(us);
        }

    }
}
