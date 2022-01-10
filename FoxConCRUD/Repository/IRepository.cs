using FoxConCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FoxConCRUD.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get( dynamic Id );
        List<T> GetList( Expression<Func<T, bool>> where = null );
        void Insert( T entity );
        void Update( T entity );
        void Delete( T entity );
    }
}