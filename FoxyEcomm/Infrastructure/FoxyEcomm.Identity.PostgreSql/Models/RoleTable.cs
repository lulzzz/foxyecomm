using System;
using System.Collections.Generic;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class RoleTable
    {
        private PostgreSqlDatabase _database;

        public RoleTable(PostgreSqlDatabase database)
        {
            _database = database;
        }

        public int Delete(string roleid)
        {
            string commandText = "DELETE FROM \"roles\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", roleid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(IdentityRole role)
        {
            string commandText = "INSERT INTO \"roles\" (\"id\", \"name\") VALUES (@id, @name)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", role.Name);
            parameters.Add("@id", role.Id);

            return _database.Execute(commandText, parameters);
        }

        public List<IdentityRole> GetAllRolenames()
        {
            List<IdentityRole> roles = new List<IdentityRole>();
            string commandText = "SELECT * FROM \"roles\"";
            var rows = _database.Query(commandText, new Dictionary<string, object>());

            foreach (var row in rows)
            {
                IdentityRole r = new IdentityRole(row["name"], row["id"]);
                roles.Add(r);
            }
            return roles;
        }

        public string GetRolename(string roleid)
        {
            string commandText = "SELECT \"name\" FROM \"roles\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", roleid);

            return _database.GetStrValue(commandText, parameters);
        }

        public string GetRoleid(string rolename)
        {
            string roleid = null;
            string commandText = "SELECT \"id\" FROM \"roles\" WHERE \"name\" = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@name", rolename } };

            var result = _database.QueryValue(commandText, parameters);
            if (result != null)
            {
                return Convert.ToString(result);
            }

            return roleid;
        }

        public IdentityRole GetRoleByid(string roleid)
        {
            var rolename = GetRolename(roleid);
            IdentityRole role = null;

            if (rolename != null)
            {
                role = new IdentityRole(rolename, roleid);
            }

            return role;

        }

        public IdentityRole GetRoleByname(string rolename)
        {
            var roleid = GetRoleid(rolename);
            IdentityRole role = null;

            if (roleid != null)
            {
                role = new IdentityRole(rolename, roleid);
            }

            return role;
        }

        public int Update(IdentityRole role)
        {
            string commandText = "UPDATE \"roles\" SET \"name\" = @name WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", role.Id);

            return _database.Execute(commandText, parameters);
        }
    }
}
