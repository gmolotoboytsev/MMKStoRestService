using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Script.Services;
using System.Web;
using MMKStoRestService.Controllers.Repositories;

namespace MMKStoRestService.Controllers
{
   
    public class ServiceController : ApiController
    {
        private static ServiceRepository db = new ServiceRepository();

        // GET: api/Service
        public List<service> Get()
        {
            return db.GetAll();
        }

        // PUT: api/Service
        public bool Put(service service)
        {
            return db.Add(service);
        }

        // DELETE: api/Service
        public bool Delete(service service)
        {
            return db.Delete(service)
        }

    }
}
