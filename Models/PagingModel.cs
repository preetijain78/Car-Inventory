using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PagingModel<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> DataSource { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
    }
}
