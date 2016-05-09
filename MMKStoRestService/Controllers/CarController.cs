using MMKStoRestService.Controllers.Repositories;
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
        private static CarRepository db = new CarRepository();

        // GET: api/Car
        public List<car> Get() {
            return db.GetAll();
        }

        // POST: api/Car
        public List<car> Post(user user)
        {
            return db.GetAllUserCar(user);
        }

        // PUT: api/Car
        public bool Put(car car)
        {
            return db.Add(car);
        }

        // DELETE: api/Car
        public bool Delete(car cr)
        {
            return db.Delete(cr);
        }
    }
}
