using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IProductRepository : IRepository<Car>
    {
        PagingModel<Car> GetProducts(int pageSize, int page, string sort, string sortDir, string search);
    }
}
