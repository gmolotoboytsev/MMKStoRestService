using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMKStoRestService.Controllers.Repositories
{
    interface IRepository<T> : IDisposable where T : class
    {
        bool Add(T item);
        bool Delete(T item);
        List<T> GetAll();
    }
}
