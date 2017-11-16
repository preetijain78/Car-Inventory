﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object Id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object Id);

        void SaveChanges();
    }
}
