using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Models;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext():base("DefaultConnection")
        {

        }

        public DbSet<Car> Cars { get; set; }


        public Car usp_GetCar(int CarId)
        {
            return this.Database.SqlQuery<Car>("Exec usp_GetCar @CarId", new SqlParameter("CarId", CarId)).FirstOrDefault();

        }

        public Car fn_GetCar(int CarId)
        {
            return this.Database.SqlQuery<Car>("Select * from fn_GetCar(CarId)", new SqlParameter("CarId", CarId)).FirstOrDefault();

        }
    }
}
