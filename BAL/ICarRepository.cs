using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICarRepository : IRepository<Car>
    {
        PagingModel<Car> GetCars(int pageSize, int page, string sort, string sortDir, string search);
    }    
}
