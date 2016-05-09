using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace MMKStoRestService.Controllers.Repositories
{
    public class OrderRepository : IRepository<orders>
    {
        private static stoEntities dataContext = new stoEntities();
        private static CarRepository car_db = new CarRepository();

        public bool Add(orders item)
        {
            try
            {
                dataContext.orders.Add(item);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }

        }

        public bool Delete(orders item)
        {
            try
            {
                var del_order = (from orders in dataContext.orders
                                where orders.id == item.id
                                select orders).SingleOrDefault();
                dataContext.orders.Remove(del_order);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }

        }

        public List<orders> GetAll()
        {
            var query = from orders in dataContext.orders
                        select orders;
            return query.ToList();
        }

        public List<orders> GetAllUserOrders(user user)
        {
            List<car> cars = car_db.GetAllUserCar(user);

            List<orders> result = new List<orders>();

            foreach(car car in cars)
            {
                result.Add(GetCarOrder(car));
            }

            return result;

        }

        public orders GetCarOrder(car item)
        {
            var order = (from orders in dataContext.orders
                             where orders.c_id == item.id
                             select orders).SingleOrDefault();
            return order;
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}