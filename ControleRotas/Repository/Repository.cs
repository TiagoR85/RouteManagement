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
        private readonly RouteContext Context;

        public Repository(RouteContext context) => Context = context;

        public void Add(T entity)
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

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                IEnumerable<T> query = Context.Set<T>().Where(expression);
                return query;
            }
            catch (Exception ex)
            {

                throw new ExceptionApp("Erro ao localizar. ", ex);
            }
            
        }

        public T GetById(int id)
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

        public T GetById(Expression<Func<T, bool>> expression)
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

        public IEnumerable<T> GetAll()
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

        public void Remove(T entity)
        {
            try
            {
                //Context.Set<T>().Remove(entity);
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
                Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var instance = Activator.CreateInstance(entity.GetType());
                Save();
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao atualizar. ", ex);
            }
        }

        public void UpdateAttach(T entity)
        {
            try
            {
                Context.Set<T>().Attach(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new ExceptionApp("Erro ao atualizar. ", ex);
            }
        }

        public void Save()
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

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
