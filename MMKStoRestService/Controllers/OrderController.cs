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
    public class OrderController : ApiController
    {

        private static OrderRepository db = new OrderRepository();

        // GET: api/Order
        public List<orders> Get()
        {
            return db.GetAll();
        }

        // POST: api/Order
        public List<orders> Post(user user)
        {
            return db.GetAllUserOrders(user);
        }

        // PUT: api/User
        public bool Put(orders order)
        {
            return db.Add(order);
        }

        // DELETE: api/User
        public bool Delete(orders or)
        {
            return db.Delete(or);
        }

    }
}
