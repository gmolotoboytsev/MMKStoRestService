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

namespace MMKStoRestService.Controllers
{
   
    public class ServiceController : ApiController
    {
        private static stoEntities dataContext = new stoEntities();

        // GET: api/Service
        public List<service> Get()
        {
            var query = from service in dataContext.service
                        select service;

            return query.ToList();
        }

        // PUT: api/Service
        public string Put(service service)
        {
            service newservice = dataContext.service.Add(service);
            dataContext.SaveChanges();
            return newservice.id.ToString();
        }

        // DELETE: api/Service
        public string Delete(service ser)
        {
            var del_ser = (from service in dataContext.service
                       where service.id == ser.id
                       select service).SingleOrDefault();
            dataContext.service.Remove(del_ser);
            dataContext.SaveChanges();
            return true.ToString();
        }

    }
}
