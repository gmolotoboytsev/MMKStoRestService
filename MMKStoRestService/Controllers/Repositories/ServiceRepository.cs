using MMKStoRestService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace MMKStoRestService.Controllers.Repositories
{
    public class ServiceRepository : IRepository<service>
    {
        private static stoEntities dataContext = new stoEntities();

        public bool Add(service item)
        {
            try
            {
                dataContext.service.Add(item);
                dataContext.SaveChanges();
                return true;
            }
            catch(EntityException ex)
            {
                return false;
            }
          
        }

        public bool Delete(service item)
        {
            try
            {
                var del_ser = (from service in dataContext.service
                               where service.id == item.id
                               select service).SingleOrDefault();
                dataContext.service.Remove(del_ser);
                dataContext.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                return false;
            }
           
        }

        public List<service> GetAll()
        {
            var query = from service in dataContext.service
                        select service;
            return query.ToList();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}