using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoxyEcomm.Orm.Interfaces
{
    public interface IDapperRepository
    {
        
        TEntity Find<TEntity>(IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity, TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity, TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity, TChild1, TChild2, TChild3, TChild4>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class;

        TEntity Find<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class;


        Task<TEntity> FindAsync<TEntity>(IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity, TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3, TChild4>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class;

        Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity>(IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;


        IEnumerable<TEntity> FindAll<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null) where TEntity : class;


        IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity , TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;


        Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class;


        Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class;

        bool Insert<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class;

        Task<bool> InsertAsync<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class;

        bool Delete<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class;

        Task<bool> DeleteAsync<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class;

        bool Update<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class;

        Task<bool> UpdateAsync<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAllBetween<TEntity>(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAllBetween<TEntity>(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate = null, IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAllBetween<TEntity>(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class;

        IEnumerable<TEntity> FindAllBetween<TEntity>(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class;

        Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null) where TEntity : class;
    }
}