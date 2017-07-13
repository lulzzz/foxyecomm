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

        public ClaimsIdentity FindByUserid(string memberid)
        {
            ClaimsIdentity claims = new ClaimsIdentity();
            string commandText = "SELECT * FROM \"memberclaims\" WHERE \"memberid\" = @memberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@memberid", memberid } };

            var rows = _database.Query(commandText, parameters);
            foreach (var row in rows)
            {
                Claim claim = new Claim(row["claimtype"], row["claimvalue"]);
                claims.AddClaim(claim);
            }

            return claims;
        }

        public int Delete(string memberid)
        {
            string commandText = "DELETE FROM \"memberclaims\" WHERE \"memberid\" = @memberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", memberid);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(Claim userClaim, string memberid)
        {
            string commandText = "INSERT INTO \"memberclaims\" (\"claimvalue\", \"claimtype\", \"memberid\") VALUES (@value, @type, @memberid)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("value", userClaim.Value);
            parameters.Add("type", userClaim.Type);
            parameters.Add("memberid", memberid);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(IdentityUser user, Claim claim)
        {
            string commandText = "DELETE FROM \"memberclaims\" WHERE \"memberid\" = @memberid AND @claimvalue = @value AND claimtype = @type";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("memberid", user.Id);
            parameters.Add("value", claim.Value);
            parameters.Add("type", claim.Type);

            return _database.Execute(commandText, parameters);
        }
    }
}
