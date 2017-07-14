using System.Collections.Generic;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class UserRolesTable
    {
        private PostgreSqlDatabase _database;

        public UserRolesTable(PostgreSqlDatabase database)
        {
            _database = database;
        }

        public List<string> FindByUserid(string subscriberid)
        {
            List<string> roles = new List<string>();

            string commandText = "SELECT \"roles\".\"name\" FROM \"roles\" JOIN \"subscriberroles\" ON \"subscriberroles\".\"roleid\" = \"roles\".\"id\" WHERE \"subscriberroles\".\"subscriberid\" = @subscriberid;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@subscriberid", subscriberid);

            var rows = _database.Query(commandText, parameters);
            foreach(var row in rows)
            {
                roles.Add(row["name"]);
            }

            return roles;
        }

        public int Delete(string subscriberid, string role)
        {
            string commandText = "DELETE FROM \"subscriberroles\" WHERE \"subscriberid\" = @subscriberid AND \"roleid\" = @Role;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", subscriberid);
            parameters.Add("Role", role);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(string subscriberid)
        {
            string commandText = "DELETE FROM \"subscriberroles\" WHERE \"subscriberid\" = @subscriberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", subscriberid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(IdentityUser user, string roleid)
        {
            string commandText = "INSERT INTO \"subscriberroles\" (\"subscriberid\", \"roleid\") VALUES (@subscriberid, @roleid)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", user.Id);
            parameters.Add("roleid", roleid);

            return _database.Execute(commandText, parameters);
        }
    }
}
