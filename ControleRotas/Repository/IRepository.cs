using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleRotas.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
		T GetById(Expression<Func<T, bool>> expression);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
		void CommitChanges();
    }
}
