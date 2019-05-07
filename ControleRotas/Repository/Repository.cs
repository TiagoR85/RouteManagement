using ControleRotas.Context;
using ControleRotas.Exceptions;
using ControleRotas.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleRotas.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly RouteContext Context;

        public Repository(RouteContext context) => Context = context;

        public virtual void Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao inserir. ", ex);
            }
        }       

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>().Where(expression);
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao localizar. ", ex);
            }
            
        }

        public virtual T GetById(int id)
        {
            try
            {
                T query = Context.Set<T>().Find(id);
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao obter por id. ", ex);
            }
        }

        public virtual T GetById(Expression<Func<T, bool>> expression)
        {
            try
            {
                T query = Context.Set<T>().First(expression);
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao obter por id. ", ex);
            }
            
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                IEnumerable<T> query = Context.Set<T>().ToList();
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao obter todos. ", ex);
            }
        }

        public void Remove(int id)
        {
            try
            {
                T query = Context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao remover. ", ex);
            }
        }

        public virtual void Remove(T entity)
        {
            try
            {
                Context.Set<T>().Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao remover. ", ex);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                Context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao atualizar. ", ex);
            }
        }

        public virtual void UpdateAttach(T entity)
        {
            try
            {
                Context.Set<T>().Attach(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao atualizar. ", ex);
            }
        }

        public virtual void Save()
        {
            try
            {
                Context.SaveChanges();
                Dispose();
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao salvar. ", ex);
            }
        }

        public virtual void SetActive(int id, bool active) { }

        private void Dispose()
        {
            Context.Dispose();
        }
    }
}
