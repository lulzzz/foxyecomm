using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using FoxyEcomm.Orm.Extensions;
using FoxyEcomm.Orm.Helpers;
using FoxyEcomm.Orm.Interfaces;
using FoxyEcomm.Orm.Models;
using FoxyEcomm.Orm.SqlGenerator;

namespace FoxyEcomm.Orm.Providers
{
    public class MsSqlDataProvider : IDapperRepository
    {
        
        private readonly SqlConnection _connection;

        private ISqlGenerator<TEntity> SqlGenerator<TEntity>() where TEntity : class
        {
            return new SqlGenerator<TEntity>(ESqlConnector.Mssql);
        }


        public MsSqlDataProvider(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }


        private class DontMap
        {
        }

        #region Find

        public virtual TEntity Find<TEntity>(IDbTransaction transaction = null) where TEntity : class
        {
            try
            {
                return Find<TEntity>(null, transaction);
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            try
            {
                return FindAll(predicate, transaction).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual TEntity Find<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1);
                return
                    ExecuteJoinQuery<TEntity, TChild1, DontMap, DontMap, DontMap, DontMap, DontMap>(queryResult, transaction,
                        tChild1).FirstOrDefault();
            }
            catch (Exception ex)
            {
                 return default(TEntity);
            }
        }

        public virtual TEntity Find<TEntity, TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2);
                return
                    ExecuteJoinQuery<TEntity, TChild1, TChild2, DontMap, DontMap, DontMap, DontMap>(queryResult, transaction,
                        tChild1, tChild2).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual TEntity Find<TEntity, TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3);
                return
                    ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, DontMap, DontMap, DontMap>(queryResult, transaction,
                        tChild1, tChild2, tChild3).FirstOrDefault();
            }
            catch (Exception ex)
            {
                 return default(TEntity);
            }
        }


        public virtual TEntity Find<TEntity, TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3, tChild4);
                return
                    ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, DontMap, DontMap>(queryResult, transaction,
                        tChild1, tChild2, tChild3, tChild4).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }


        public virtual TEntity Find<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3, tChild4, tChild5);
                return
                    ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, DontMap>(queryResult, transaction,
                        tChild1, tChild2, tChild3, tChild4, tChild5).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual TEntity Find<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3, tChild4, tChild5,
                    tChild6);
                return
                    ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, DontMap>(queryResult, transaction,
                        tChild1, tChild2, tChild3, tChild4, tChild5, tChild6).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);

            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1>(Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(null, tChild1);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, DontMap, DontMap, DontMap, DontMap, DontMap>(queryResult,
                    transaction, tChild1)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);

            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate);
                return (await FindAllAsync<TEntity>(queryResult, transaction)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }

        }

        public virtual async Task<TEntity> FindAsync<TEntity>(IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(null);
                return (await FindAllAsync<TEntity>(queryResult, transaction)).FirstOrDefault();
            }
            catch (Exception ex)
            {
               return default(TEntity);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, DontMap, DontMap, DontMap, DontMap, DontMap>(queryResult,
                    transaction, tChild1)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, DontMap, DontMap, DontMap, DontMap>(queryResult,
                    transaction, tChild1, tChild2)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                 return default(TEntity);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, DontMap, DontMap, DontMap>(queryResult,
                    transaction, tChild1, tChild2, tChild3)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                 return default(TEntity);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3, tChild4);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, DontMap, DontMap>(queryResult,
                    transaction, tChild1, tChild2, tChild3, tChild4)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3, tChild4, tChild5);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, DontMap>(queryResult,
                    transaction, tChild1, tChild2, tChild3, tChild4, tChild5)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }

        public virtual async Task<TEntity> FindAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectFirst(predicate, tChild1, tChild2, tChild3, tChild4, tChild5,
                    tChild6);
                return
                (await ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(queryResult,
                    transaction, tChild1, tChild2, tChild3, tChild4, tChild5, tChild6)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                 return default(TEntity);
            }
        }

        #endregion Find

        #region FindAll

        public virtual IEnumerable<TEntity> FindAll<TEntity>(IDbTransaction transaction = null) where TEntity : class
        {
            return FindAll<TEntity>(predicate: null, transaction: transaction);
        }

        public virtual IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectAll(predicate);
                return _connection.Query<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
            }
            catch (Exception ex)
            {
                return default(IEnumerable<TEntity>);
            }
        }

        private IEnumerable<TEntity> FindAll<TEntity>(SqlQuery sqlQuery, IDbTransaction transaction = null) where TEntity : class
        {
            try
            {
                return _connection.Query<TEntity>(sqlQuery.GetSql(), sqlQuery.Param, transaction);
            }
            catch (Exception ex)
            {
                return default(IEnumerable<TEntity>);
            }
        }


        public virtual IEnumerable<TEntity> FindAll<TEntity, TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null) where TEntity : class
        {
            var queryResult = SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1);
            return ExecuteJoinQuery<TEntity, TChild1, DontMap, DontMap, DontMap, DontMap, DontMap>(queryResult, transaction,
                tChild1);
        }

        public virtual IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2);
            return ExecuteJoinQuery<TEntity, TChild1, TChild2, DontMap, DontMap, DontMap, DontMap>(sqlQuery, transaction, tChild1,
                tChild2);
        }

        public virtual IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3);
            return ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, DontMap, DontMap, DontMap>(sqlQuery, transaction, tChild1,
                tChild2, tChild3);
        }

        public virtual IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3, tChild4);
            return ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, DontMap, DontMap>(sqlQuery, transaction, tChild1,
                tChild2, tChild3, tChild4);
        }

        public virtual IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3, tChild4,
                tChild5);
            return ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, DontMap>(sqlQuery, transaction, tChild1,
                tChild2, tChild3, tChild4, tChild5);
        }

        public virtual IEnumerable<TEntity> FindAll<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3, tChild4,
                tChild5, tChild6);
            return ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(sqlQuery, transaction, tChild1,
                tChild2, tChild3, tChild4, tChild5, tChild6);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(IDbTransaction transaction = null) where TEntity : class
        {
            return FindAllAsync<TEntity>(predicate: null, transaction: transaction);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectAll(predicate);
                return FindAllAsync<TEntity>(queryResult, transaction);
            }
            catch (Exception ex)
            {
                return default(Task<IEnumerable<TEntity>>);
            }
        }

        private Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(SqlQuery sqlQuery, IDbTransaction transaction = null) where TEntity : class
        {
            try
            {
                return _connection.QueryAsync<TEntity>(sqlQuery.GetSql(), sqlQuery.Param, transaction);
            }
            catch (Exception ex)
            {
                return default(Task<IEnumerable<TEntity>>);
            }
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1>(
            Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null) where TEntity : class
        {
            var queryResult = SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1);
            return ExecuteJoinQueryAsync<TEntity, TChild1, DontMap, DontMap, DontMap, DontMap, DontMap>(queryResult, transaction,
                tChild1);
        }


        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2);
            return ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, DontMap, DontMap, DontMap, DontMap>(sqlQuery, transaction,
                tChild1, tChild2);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3);
            return ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, DontMap, DontMap, DontMap>(sqlQuery, transaction,
                tChild1, tChild2, tChild3);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3, tChild4);
            return ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, DontMap, DontMap>(sqlQuery, transaction,
                tChild1, tChild2, tChild3, tChild4);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3, tChild4,
                tChild5);
            return ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, DontMap>(sqlQuery, transaction,
                tChild1, tChild2, tChild3, tChild4, tChild5);
        }

        public virtual Task<IEnumerable<TEntity>> FindAllAsync
            <TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
                Expression<Func<TEntity, bool>> predicate,
                Expression<Func<TEntity, object>> tChild1,
                Expression<Func<TEntity, object>> tChild2,
                Expression<Func<TEntity, object>> tChild3,
                Expression<Func<TEntity, object>> tChild4,
                Expression<Func<TEntity, object>> tChild5,
                Expression<Func<TEntity, object>> tChild6,
                IDbTransaction transaction = null) where TEntity : class
        {
            var sqlQuery = new SqlGenerator<TEntity>().GetSelectAll(predicate, tChild1, tChild2, tChild3, tChild4,
                tChild5, tChild6);
            return ExecuteJoinQueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(sqlQuery, transaction,
                tChild1, tChild2, tChild3, tChild4, tChild5, tChild6);
        }

        private IEnumerable<TEntity> ExecuteJoinQuery<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            SqlQuery sqlQuery,
            IDbTransaction transaction,
            params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            try
            {
                var type = typeof(TEntity);

                var childPropertyNames = includes.Select(ExpressionHelper.GetPropertyName).ToList();
                var childProperties = childPropertyNames.Select(p => type.GetProperty(p)).ToList();

                if (SqlGenerator<TEntity>().KeySqlProperties.Length > 1)
                    throw new Exception("Joining with CompositeKeys isn't supported");

                var keyPropertyMeta = SqlGenerator<TEntity>().KeySqlProperties.FirstOrDefault();
                if (keyPropertyMeta == null)
                    throw new Exception("key not found");

                var keyProperty = keyPropertyMeta.PropertyInfo;
                var childKeyProperties = new List<PropertyInfo>();

                foreach (var property in childProperties)
                {
                    var childType = property.PropertyType.IsGenericType()
                        ? property.PropertyType.GenericTypeArguments[0]
                        : property.PropertyType;
                    var properties = childType.GetProperties().Where(ExpressionHelper.GetPrimitivePropertiesPredicate());
                    childKeyProperties.Add(properties.First(p => p.GetCustomAttributes<KeyAttribute>().Any()));
                }

                var lookup = new Dictionary<object, TEntity>();
                const bool buffered = true;

                var spiltOn = "Id";
                var childKeyNames = childKeyProperties.Select(p => p.Name).ToList();
                if (childKeyNames.Any(p => p != spiltOn))
                    spiltOn = string.Join(",", childKeyNames);

                switch (includes.Length)
                {
                    case 1:
                        _connection.Query<TEntity, TChild1, TEntity>(sqlQuery.GetSql(), (entity, child1) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty,
                                    childKeyProperties, childProperties, childPropertyNames, type, entity, child1),
                            sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 2:
                        _connection.Query<TEntity, TChild1, TChild2, TEntity>(sqlQuery.GetSql(),
                            (entity, child1, child2) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2), sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 3:
                        _connection.Query<TEntity, TChild1, TChild2, TChild3, TEntity>(sqlQuery.GetSql(),
                            (entity, child1, child2, child3) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3), sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 4:
                        _connection.Query<TEntity, TChild1, TChild2, TChild3, TChild4, TEntity>(sqlQuery.GetSql(),
                            (entity, child1, child2, child3, child4) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3, child4), sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 5:
                        _connection.Query<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TEntity>(
                            sqlQuery.GetSql(), (entity, child1, child2, child3, child4, child5) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3, child4, child5), sqlQuery.Param, transaction, buffered,
                            spiltOn);
                        break;

                    case 6:
                        _connection.Query<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6, TEntity>(
                            sqlQuery.GetSql(), (entity, child1, child2, child3, child4, child5, child6) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3, child4, child5, child6), sqlQuery.Param, transaction,
                            buffered, spiltOn);
                        break;

                    default:
                        throw new NotSupportedException();
                }

                return lookup.Values;
            }
            catch (Exception ex)
            {
                return default(IEnumerable<TEntity>);
            }
        }

        private async Task<IEnumerable<TEntity>> ExecuteJoinQueryAsync
            <TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
                SqlQuery sqlQuery,
                IDbTransaction transaction,
                params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            try
            {
                var type = typeof(TEntity);

                var childPropertyNames = includes.Select(ExpressionHelper.GetPropertyName).ToList();
                var childProperties = childPropertyNames.Select(p => type.GetProperty(p)).ToList();

                if (SqlGenerator<TEntity>().KeySqlProperties.Length > 1)
                    throw new Exception("Joining with CompositeKeys isn't supported");

                var keyPropertyMeta = SqlGenerator<TEntity>().KeySqlProperties.FirstOrDefault();
                if (keyPropertyMeta == null)
                    throw new Exception("key not found");

                var keyProperty = keyPropertyMeta.PropertyInfo;
                var childKeyProperties = new List<PropertyInfo>();

                foreach (var property in childProperties)
                {
                    var childType = property.PropertyType.IsGenericType()
                        ? property.PropertyType.GenericTypeArguments[0]
                        : property.PropertyType;
                    var properties = childType.GetProperties().Where(ExpressionHelper.GetPrimitivePropertiesPredicate());
                    childKeyProperties.Add(properties.First(p => p.GetCustomAttributes<KeyAttribute>().Any()));
                }

                var lookup = new Dictionary<object, TEntity>();
                const bool buffered = true;

                var spiltOn = "Id";
                var childKeyNames = childKeyProperties.Select(p => p.Name).ToList();
                if (childKeyNames.Any(p => p != spiltOn))
                    spiltOn = string.Join(",", childKeyNames);

                switch (includes.Length)
                {
                    case 1:
                        await _connection.QueryAsync<TEntity, TChild1, TEntity>(sqlQuery.GetSql(), (entity, child1) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty,
                                    childKeyProperties, childProperties, childPropertyNames, type, entity, child1),
                            sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 2:
                        await _connection.QueryAsync<TEntity, TChild1, TChild2, TEntity>(sqlQuery.GetSql(),
                            (entity, child1, child2) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2), sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 3:
                        await _connection.QueryAsync<TEntity, TChild1, TChild2, TChild3, TEntity>(sqlQuery.GetSql(),
                            (entity, child1, child2, child3) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3), sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 4:
                        await _connection.QueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TEntity>(
                            sqlQuery.GetSql(), (entity, child1, child2, child3, child4) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3, child4), sqlQuery.Param, transaction, buffered, spiltOn);
                        break;

                    case 5:
                        await _connection.QueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TEntity>(
                            sqlQuery.GetSql(), (entity, child1, child2, child3, child4, child5) =>
                                EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                    keyProperty, childKeyProperties, childProperties, childPropertyNames, type, entity,
                                    child1, child2, child3, child4, child5), sqlQuery.Param, transaction, buffered,
                            spiltOn);
                        break;

                    case 6:
                        await _connection
                            .QueryAsync<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6, TEntity>(
                                sqlQuery.GetSql(), (entity, child1, child2, child3, child4, child5, child6) =>
                                    EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(lookup,
                                        keyProperty, childKeyProperties, childProperties, childPropertyNames, type,
                                        entity, child1, child2, child3, child4, child5, child6), sqlQuery.Param,
                                transaction, buffered, spiltOn);
                        break;

                    default:
                        throw new NotSupportedException();
                }

                return lookup.Values;
            }
            catch (Exception ex)
            {
                return default(IEnumerable<TEntity>);
            }
        }

        private static TEntity EntityJoinMapping<TEntity, TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            IDictionary<object, TEntity> lookup, PropertyInfo keyProperty, IList<PropertyInfo> childKeyProperties,
            IList<PropertyInfo> childProperties, IList<string> propertyNames, Type entityType, TEntity entity,
            params object[] childs) where TEntity : class
        {
            var key = keyProperty.GetValue(entity);

            TEntity target;
            if (!lookup.TryGetValue(key, out target))
                lookup.Add(key, target = entity);

            for (var i = 0; i < childs.Length; i++)
            {
                var child = childs[i];
                var childProperty = childProperties[i];
                var propertyName = propertyNames[i];
                var childKeyProperty = childKeyProperties[i];

                if (childProperty.PropertyType.IsGenericType())
                {
                    var list = (IList)childProperty.GetValue(target);
                    if (list == null)
                    {
                        switch (i)
                        {
                            case 0:
                                list = new List<TChild1>();
                                break;

                            case 1:
                                list = new List<TChild2>();
                                break;

                            case 2:
                                list = new List<TChild3>();
                                break;

                            case 3:
                                list = new List<TChild4>();
                                break;

                            case 4:
                                list = new List<TChild5>();
                                break;

                            case 5:
                                list = new List<TChild6>();
                                break;

                            default:
                                throw new NotSupportedException();
                        }

                        childProperty.SetValue(target, list);
                    }

                    if (child == null)
                        continue;

                    var childKey = childKeyProperty.GetValue(child);
                    var exist = (from object item in list select childKeyProperty.GetValue(item)).Contains(childKey);
                    if (!exist)
                        list.Add(child);
                }
                else
                {
                    entityType.GetProperty(propertyName).SetValue(target, child);
                }
            }

            return target;
        }

        #endregion FindAll

        #region Insert

        public virtual bool Insert<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class
        {
            try
            {
                bool added;

                var queryResult = SqlGenerator<TEntity>().GetInsert(instance);

                if (SqlGenerator<TEntity>().IsIdentity)
                {
                    var newId =
                        _connection.Query<long>(queryResult.GetSql(), queryResult.Param, transaction).FirstOrDefault();
                    added = newId > 0;

                    if (added)
                    {
                        var newParsedId = Convert.ChangeType(newId,
                            SqlGenerator<TEntity>().IdentitySqlProperty.PropertyInfo.PropertyType);
                        SqlGenerator<TEntity>().IdentitySqlProperty.PropertyInfo.SetValue(instance, newParsedId);
                    }
                }
                else
                {
                    added = _connection.Execute(queryResult.GetSql(), instance, transaction) > 0;
                }

                return added;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> InsertAsync<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class
        {
            try
            {
                bool added;

                var queryResult = SqlGenerator<TEntity>().GetInsert(instance);

                if (SqlGenerator<TEntity>().IsIdentity)
                {
                    var newId =
                        (await _connection.QueryAsync<long>(queryResult.GetSql(), queryResult.Param, transaction))
                        .FirstOrDefault();
                    added = newId > 0;

                    if (added)
                    {
                        var newParsedId = Convert.ChangeType(newId,
                            SqlGenerator<TEntity>().IdentitySqlProperty.PropertyInfo.PropertyType);
                        SqlGenerator<TEntity>().IdentitySqlProperty.PropertyInfo.SetValue(instance, newParsedId);
                    }
                }
                else
                {
                    added = _connection.Execute(queryResult.GetSql(), instance, transaction) > 0;
                }

                return added;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Insert

        #region Delete

        public virtual bool Delete<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetDelete(instance);
                var deleted = _connection.Execute(queryResult.GetSql(), queryResult.Param, transaction) > 0;
                return deleted;
            }
            catch (Exception ex)
            {
               return false;
            }
        }

        public virtual async Task<bool> DeleteAsync<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetDelete(instance);
                var deleted = await _connection.ExecuteAsync(queryResult.GetSql(), queryResult.Param, transaction) > 0;
                return deleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Delete

        #region Update

        public virtual bool Update<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery sqlQuery = new SqlQuery();
            try
            {
                sqlQuery = SqlGenerator<TEntity>().GetUpdate(instance);
                var updated = _connection.Execute(sqlQuery.GetSql(), instance, transaction) > 0;
                return updated;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateAsync<TEntity>(TEntity instance, IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery sqlQuery = new SqlQuery();
            try
            {
                sqlQuery = SqlGenerator<TEntity>().GetUpdate(instance);
                var updated = await _connection.ExecuteAsync(sqlQuery.GetSql(), instance, transaction) > 0;
                return updated;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Update

        #region Beetwen

        private const string _dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public IEnumerable<TEntity> FindAllBetween<TEntity>(object from, object to,
            Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class
        {
            return FindAllBetween(from, to, btwField, null, transaction);
        }

        public IEnumerable<TEntity> FindAllBetween<TEntity>(object from, object to,
            Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate = null,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectBetween(from, to, btwField, predicate);
                return _connection.Query<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
            }
            catch (Exception ex)
            {
                return default(IEnumerable<TEntity>);
            }
        }

        public IEnumerable<TEntity> FindAllBetween<TEntity>(DateTime from, DateTime to,
            Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class
        {
            return FindAllBetween(from, to, btwField, null, transaction);
        }

        public IEnumerable<TEntity> FindAllBetween<TEntity>(DateTime from, DateTime to,
            Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            var fromString = from.ToString(_dateTimeFormat);
            var toString = to.ToString(_dateTimeFormat);
            return FindAllBetween(fromString, toString, btwField, predicate);
        }

        public Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(object from, object to,
            Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class
        {
            return FindAllBetweenAsync(from, to, btwField, null, transaction);
        }

        public Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(object from, object to,
            Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            SqlQuery queryResult = new SqlQuery();
            try
            {
                queryResult = SqlGenerator<TEntity>().GetSelectBetween(from, to, btwField, predicate);
                return _connection.QueryAsync<TEntity>(queryResult.GetSql(), queryResult.Param, transaction);
            }
            catch (Exception ex)
            {
                return default(Task<IEnumerable<TEntity>>);
            }
        }

        public Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(DateTime from, DateTime to,
            Expression<Func<TEntity, object>> btwField, IDbTransaction transaction = null) where TEntity : class
        {
            return FindAllBetweenAsync(from, to, btwField, null, transaction);
        }

        public Task<IEnumerable<TEntity>> FindAllBetweenAsync<TEntity>(DateTime from, DateTime to,
            Expression<Func<TEntity, object>> btwField, Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction = null) where TEntity : class
        {
            return FindAllBetweenAsync(from.ToString(_dateTimeFormat), to.ToString(_dateTimeFormat), btwField, predicate,
                transaction);
        }

        #endregion Beetwen

        #region IDisposable Support

        bool _disposedValue;


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {

                }
                _disposedValue = true;
            }
        }


        ~MsSqlDataProvider()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion


    }
}
