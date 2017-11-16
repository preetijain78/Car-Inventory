using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class CarRepository : Repository<Models.Car>, ICarRepository
    {
        public DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public CarRepository()
        {
            this.db = new DatabaseContext();
        }

        public PagingModel<Models.Car> GetCars(int pageSize, int page, string sort, string sortDir, string Search)
        {
            IQueryable<Models.Car> data = context.Cars;
            if (!string.IsNullOrEmpty(Search))
            {
                data = data.Where(d => d.Brand.Contains(Search) || d.Model.Contains(Search));
            }
            switch (sort)
            {
                case "Brand":
                    data = sortDir == "asc" ? data.OrderBy(d => d.Brand) : data.OrderByDescending(d => d.Brand);
                    break;
                case "Model":
                    data = sortDir == "asc" ? data.OrderBy(d => d.Model) : data.OrderByDescending(d => d.Model);
                    break;
                case "Year":
                    data = sortDir == "asc" ? data.OrderBy(d => d.Year) : data.OrderByDescending(d => d.Year);
                    break;
                case "Price":
                    data = sortDir == "asc" ? data.OrderBy(d => d.Price) : data.OrderByDescending(d => d.Price);
                    break;
                case "New":
                    data = sortDir == "asc" ? data.OrderBy(d => d.New) : data.OrderByDescending(d => d.New);
                    break;
                default:
                    data = sortDir == "asc" ? data.OrderBy(d => d.CarId) : data.OrderByDescending(d => d.CarId);
                    break;
            }

            int cout = data.Count();
            data = data.Skip((page - 1) * pageSize).Take(pageSize);

            PagingModel<Models.Car> model = new PagingModel<Models.Car>();
            model.DataSource = data;
            model.PageSize = pageSize;
            model.TotalRows = cout;
            return model;
        }
    }
}
