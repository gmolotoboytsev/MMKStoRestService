using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace MMKStoRestService.Controllers.Repositories
{
    public class CarRepository : IRepository<car>
    {
        private static stoEntities dataContext = new stoEntities();

        public bool Add(car item)
        {
            try
            {
                dataContext.car.Add(item);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }

        }

        public bool Delete(car item)
        {
            try
            {
                var del_car = (from car in dataContext.car
                               where car.id == item.id
                               select car).SingleOrDefault();
                dataContext.car.Remove(del_car);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }

        }

        public List<car> GetAll()
        {
            var query = from car in dataContext.car
                        select car;
            return query.ToList();
        }

        public List<car> GetAllUserCar(user user)
        {
            var query = from car in dataContext.car
                        where car.user_id == user.id
                        select car;
            return query.ToList();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}