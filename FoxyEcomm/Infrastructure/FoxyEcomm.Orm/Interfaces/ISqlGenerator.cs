using System;
using System.Linq.Expressions;
using System.Reflection;
using FoxyEcomm.Orm.SqlGenerator;

namespace FoxyEcomm.Orm.Interfaces
{
    public interface ISqlGenerator<TEntity> where TEntity : class
    {
        PropertyInfo[] AllProperties { get; }

        bool HasUpdatedAt { get; }

        PropertyInfo UpdatedAtProperty { get; }

        bool IsIdentity { get; }

        string TableName { get; }

        SqlPropertyMetadata IdentitySqlProperty { get; }

        SqlPropertyMetadata[] KeySqlProperties { get; }

        SqlPropertyMetadata[] SqlProperties { get; }

        SqlGeneratorConfig Config { get; }

        bool LogicalDelete { get; }

        string StatusPropertyName { get; }

        object LogicalDeleteValue { get; }

        SqlQuery GetInsert(TEntity entity);

        SqlQuery GetUpdate(TEntity entity);

        SqlQuery GetSelectFirst(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        SqlQuery GetSelectAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        SqlQuery GetSelectBetween(object from, object to, Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> expression = null);

        SqlQuery GetDelete(TEntity entity);
    }
}