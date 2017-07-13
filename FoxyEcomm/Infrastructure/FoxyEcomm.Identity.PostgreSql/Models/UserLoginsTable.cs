using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class UserLoginsTable
    {
        private PostgreSqlDatabase _database;

        public UserLoginsTable(PostgreSqlDatabase database)
        {
            _database = database;
        }

        public int Delete(IdentityUser user, UserLoginInfo login)
        {
            string commandText = "DELETE FROM \"memberlogins\" WHERE \"memberid\" = @memberid AND \"loginprovider\" = @loginprovider AND \"poviderkey\" = @poviderkey";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", user.Id);
            parameters.Add("loginprovider", login.LoginProvider);
            parameters.Add("poviderkey", login.ProviderKey);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(string memberid)
        {
            string commandText = "DELETE FROM \"memberlogins\" WHERE \"memberid\" = @memberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", memberid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(IdentityUser user, UserLoginInfo login)
        {
            string commandText = "INSERT INTO \"memberlogins\" (\"loginprovider\", \"poviderkey\", \"memberid\") VALUES (@loginprovider, @poviderkey, @memberid)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loginprovider", login.LoginProvider);
            parameters.Add("poviderkey", login.ProviderKey);
            parameters.Add("memberid", user.Id);

            return _database.Execute(commandText, parameters);
        }

        public string FindUseridByLogin(UserLoginInfo userLogin)
        {
            string commandText = "SELECT \"memberid\" FROM \"memberlogins\" WHERE \"loginprovider\" = @loginprovider AND \"poviderkey\" = @poviderkey";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loginprovider", userLogin.LoginProvider);
            parameters.Add("poviderkey", userLogin.ProviderKey);

            return _database.GetStrValue(commandText, parameters);
        }

        public List<UserLoginInfo> FindByUserid(string memberid)
        {
            List<UserLoginInfo> logins = new List<UserLoginInfo>();
            string commandText = "SELECT * FROM \"memberlogins\" WHERE \"memberid\" = @memberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@memberid", memberid } };

            var rows = _database.Query(commandText, parameters);
            foreach (var row in rows)
            {
                var login = new UserLoginInfo(row["loginprovider"], row["poviderkey"]);
                logins.Add(login);
            }

            return logins;
        }
    }
}
