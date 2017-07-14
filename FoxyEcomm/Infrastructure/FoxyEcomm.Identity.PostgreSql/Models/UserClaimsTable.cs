using System.Collections.Generic;
using System.Security.Claims;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class UserClaimsTable
    {
        private PostgreSqlDatabase _database;

        public UserClaimsTable(PostgreSqlDatabase database)
        {
            _database = database;
        }

        public ClaimsIdentity FindByUserid(string subscriberid)
        {
            ClaimsIdentity claims = new ClaimsIdentity();
            string commandText = "SELECT * FROM \"subscriberclaims\" WHERE \"subscriberid\" = @subscriberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@subscriberid", subscriberid } };

            var rows = _database.Query(commandText, parameters);
            foreach (var row in rows)
            {
                Claim claim = new Claim(row["claimtype"], row["claimvalue"]);
                claims.AddClaim(claim);
            }

            return claims;
        }

        public int Delete(string subscriberid)
        {
            string commandText = "DELETE FROM \"subscriberclaims\" WHERE \"subscriberid\" = @subscriberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", subscriberid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(Claim userClaim, string subscriberid)
        {
            string commandText = "INSERT INTO \"subscriberclaims\" (\"claimvalue\", \"claimtype\", \"subscriberid\") VALUES (@value, @type, @subscriberid)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("value", userClaim.Value);
            parameters.Add("type", userClaim.Type);
            parameters.Add("subscriberid", subscriberid);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(IdentityUser user, Claim claim)
        {
            string commandText = "DELETE FROM \"subscriberclaims\" WHERE \"subscriberid\" = @subscriberid AND @claimvalue = @value AND claimtype = @type";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subscriberid", user.Id);
            parameters.Add("value", claim.Value);
            parameters.Add("type", claim.Type);

            return _database.Execute(commandText, parameters);
        }
    }
}
