using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleRotas.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
		T GetById(Expression<Func<T, bool>> expression);
        T GetById(int id);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Update(T entity);
		void Save();
    }
}
