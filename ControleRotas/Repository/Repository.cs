using ControleRotas.Context;
using ControleRotas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleRotas.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        readonly RouteContext _db;

        public Repository(RouteContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao inserir. ", ex);
            }
            
        }       

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                IEnumerable<T> query = _db.Set<T>().Where(expression);
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao localizar. ", ex);
            }
            
        }
		
		public T GetById(Expression<Func<T, bool>> expression)
        {
            try
            {
                T query = _db.Set<T>().First(expression);
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao obter por id. ", ex);
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                IEnumerable<T> query = _db.Set<T>().ToList();
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao obter todos. ", ex);
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _db.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao remover. ", ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //implementacao
                CommitChanges();
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao atualizar. ", ex);
            }
        }

        public void CommitChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao salvar. ", ex);
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
