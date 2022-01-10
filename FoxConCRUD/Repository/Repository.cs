using FoxConCRUD.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace FoxConCRUD.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FoxDbContext dbContext;

        public Repository( FoxDbContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public void Delete( T entity )
        {
            try
            {
                dbContext.Entry( entity ).State = EntityState.Deleted;
                dbContext.Set<T>().Remove( entity );
                dbContext.SaveChanges();
            }
            catch( Exception ex )
            {

                throw ex;
            }
        }

        public List<T> GetList( Expression<Func<T, bool>> where = null )
        {
            try
            {
                if( where == null )
                    return dbContext.Set<T>().ToList();

                return dbContext.Set<T>().Where( where ).ToList();
            }
            catch( Exception ex )
            {

                throw ex;
            }
        }

        public T Get( dynamic Id )
        {
            try
            {
                return dbContext.Set<T>().Find( Id );
            }
            catch( Exception ex )
            {

                throw ex;
            }
        }

        public void Insert( T entity )
        {
            try
            {
                dbContext.Set<T>().Add( entity );
                dbContext.SaveChanges();
            }
            catch( Exception ex )
            {

                throw ex;
            }
        }

        public void Update( T entity )
        {
            try
            {
                dbContext.Set<T>().AddOrUpdate( entity );
                dbContext.SaveChanges();
            }
            catch( Exception ex )
            {

                throw ex;
            }
        }
    }
}