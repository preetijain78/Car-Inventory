using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext db { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public TEntity GetById(object Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            var entity = db.Set<TEntity>().Find(Id);
            db.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
