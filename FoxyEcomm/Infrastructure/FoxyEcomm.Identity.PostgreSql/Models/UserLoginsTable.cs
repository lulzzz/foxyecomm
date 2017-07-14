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
            string commandText = "DELETE FROM \"subscriberlogins\" WHERE \"subscriberid\" = @subscriberid AND \"loginprovider\" = @loginprovider AND \"poviderkey\" = @poviderkey";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", user.Id);
            parameters.Add("loginprovider", login.LoginProvider);
            parameters.Add("poviderkey", login.ProviderKey);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(string subscriberid)
        {
            string commandText = "DELETE FROM \"subscriberlogins\" WHERE \"subscriberid\" = @subscriberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", subscriberid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(IdentityUser user, UserLoginInfo login)
        {
            string commandText = "INSERT INTO \"subscriberlogins\" (\"loginprovider\", \"poviderkey\", \"subscriberid\") VALUES (@loginprovider, @poviderkey, @subscriberid)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loginprovider", login.LoginProvider);
            parameters.Add("poviderkey", login.ProviderKey);
            parameters.Add("subscriberid", user.Id);

            return _database.Execute(commandText, parameters);
        }

        public string FindUseridByLogin(UserLoginInfo userLogin)
        {
            string commandText = "SELECT \"subscriberid\" FROM \"subscriberlogins\" WHERE \"loginprovider\" = @loginprovider AND \"poviderkey\" = @poviderkey";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loginprovider", userLogin.LoginProvider);
            parameters.Add("poviderkey", userLogin.ProviderKey);

            return _database.GetStrValue(commandText, parameters);
        }

        public List<UserLoginInfo> FindByUserid(string subscriberid)
        {
            List<UserLoginInfo> logins = new List<UserLoginInfo>();
            string commandText = "SELECT * FROM \"subscriberlogins\" WHERE \"subscriberid\" = @subscriberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@subscriberid", subscriberid } };

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
