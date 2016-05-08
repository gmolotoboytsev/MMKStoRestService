using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MMKStoRestService.Controllers
{
    public class CarController : ApiController
    {
        private static stoEntities dataContext = new stoEntities();

        // GET: api/Car
        public List<car> Get()
        {
            var query = from car in dataContext.car
                        select car;

            return query.ToList();
        }

        // PUT: api/Car
        public string Put(car car)
        {
            car newcar = dataContext.car.Add(car);
            dataContext.SaveChanges();
            return newcar.id.ToString();
        }

        // DELETE: api/Car
        public string Delete(service cr)
        {
            var del_car = (from car in dataContext.car
                           where car.id == cr.id
                           select car).SingleOrDefault();
            dataContext.car.Remove(del_car);
            dataContext.SaveChanges();
            return true.ToString();
        }
    }
}
