using System;
using System.Linq;
using System.Threading.Tasks;
using FoxyEcomm.Identity.PostgreSql.Models;
using Microsoft.AspNet.Identity;

namespace FoxyEcomm.Identity.PostgreSql.Stores
{
    public class RoleStore<TRole> : IQueryableRoleStore<TRole>
        where TRole : IdentityRole
    {
        private RoleTable RoleTable;
        public PostgreSqlDatabase Database { get; private set; }

        public IQueryable<TRole> Roles
        {
            get
            {
                var result = RoleTable.GetAllRolenames() as System.Collections.Generic.List<TRole>;                
                return result.AsQueryable();
            }
        }


        public RoleStore()
        {
            new RoleStore<TRole>(new PostgreSqlDatabase());
        }

        public RoleStore(PostgreSqlDatabase database)
        {
            this.Database = database;
            this.RoleTable = new RoleTable(database);
        }

        public Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            RoleTable.Insert(role);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            RoleTable.Delete(role.Id);

            return Task.FromResult<Object>(null);
        }

        public Task<TRole> FindByIdAsync(string roleid)
        {
            TRole result = RoleTable.GetRoleByid(roleid) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task<TRole> FindByNameAsync(string rolename)
        {
            TRole result = RoleTable.GetRoleByname(rolename) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            RoleTable.Update(role);

            return Task.FromResult<Object>(null);
        }

        public void Dispose()
        {
            if (Database != null)
            {
                Database.Dispose();
                Database = null;
            }
        }

    }
}
