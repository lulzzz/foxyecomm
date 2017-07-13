using System;
using System.Data;

namespace FoxyEcomm.Orm.Interfaces
{
    public interface IDapperDbContext : IDisposable
    {
        IDbConnection Connection { get; }

        void OpenConnection();

        IDbTransaction BeginTransaction();
    }
}