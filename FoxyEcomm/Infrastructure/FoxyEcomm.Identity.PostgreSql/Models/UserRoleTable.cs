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

        public List<string> FindByUserid(string memberid)
        {
            List<string> roles = new List<string>();

            string commandText = "SELECT \"roles\".\"name\" FROM \"roles\" JOIN \"memberroles\" ON \"memberroles\".\"roleid\" = \"roles\".\"id\" WHERE \"memberroles\".\"memberid\" = @memberid;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@memberid", memberid);

            var rows = _database.Query(commandText, parameters);
            foreach(var row in rows)
            {
                roles.Add(row["name"]);
            }

            return roles;
        }

        public int Delete(string memberid, string role)
        {
            string commandText = "DELETE FROM \"memberroles\" WHERE \"memberid\" = @memberid AND \"roleid\" = @Role;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", memberid);
            parameters.Add("Role", role);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(string memberid)
        {
            string commandText = "DELETE FROM \"memberroles\" WHERE \"memberid\" = @memberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", memberid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(IdentityUser user, string roleid)
        {
            string commandText = "INSERT INTO \"memberroles\" (\"memberid\", \"roleid\") VALUES (@memberid, @roleid)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", user.Id);
            parameters.Add("roleid", roleid);

            return _database.Execute(commandText, parameters);
        }
    }
}
