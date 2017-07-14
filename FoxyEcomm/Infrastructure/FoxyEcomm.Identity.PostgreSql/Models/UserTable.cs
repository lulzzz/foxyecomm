using System;
using System.Collections.Generic;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class UserTable<TUser>
        where TUser : IdentityUser
    {
        private PostgreSqlDatabase _database;

        public UserTable(PostgreSqlDatabase database)
        {
            _database = database;
        }

        public string Getusername(string subscriberid)
        {
            string commandText = "SELECT \"username\" FROM \"subscribers\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", subscriberid } };

            return _database.GetStrValue(commandText, parameters);
        }

        public string GetUserid(string username)
        {
            if (username != null)
                username = username.ToLower();

            string commandText = "SELECT \"id\" FROM \"subscribers\" WHERE LOWER(\"username\") = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@name", username } };

            return _database.GetStrValue(commandText, parameters);
        }

        public List<TUser> GetAllUsers()
        {
            List<TUser> users = new List<TUser>();

            string commandText = "SELECT * FROM \"subscribers\"";
            var rows = _database.Query(commandText, new Dictionary<string, object>());

            foreach (var row in rows)
            {
                TUser user = (TUser)Activator.CreateInstance(typeof(TUser));
                user.Id = row["id"];
                user.UserName = row["username"];
                user.PasswordHash = string.IsNullOrEmpty(row["passwordhash"]) ? null : row["passwordhash"];
                user.SecurityStamp = string.IsNullOrEmpty(row["securitystamp"]) ? null : row["securitystamp"];
                user.Email = string.IsNullOrEmpty(row["email"]) ? null : row["email"];
                user.EmailConfirmed = row["emailconfirmed"] == "True";
                users.Add(user);
            }

            return users;
        }

        public TUser GetUserByid(string subscriberid)
        {
            TUser user = null;
            string commandText = "SELECT * FROM \"subscribers\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", subscriberid } };

            var rows = _database.Query(commandText, parameters);
            if (rows != null && rows.Count == 1)
            {
                var row = rows[0];
                user = (TUser)Activator.CreateInstance(typeof(TUser));
                user.Id = row["id"];
                user.UserName = row["username"];
                user.PasswordHash = string.IsNullOrEmpty(row["passwordhash"]) ? null : row["passwordhash"];
                user.SecurityStamp = string.IsNullOrEmpty(row["securitystamp"]) ? null : row["securitystamp"];
                user.Email = string.IsNullOrEmpty(row["email"]) ? null : row["email"];
                user.EmailConfirmed = row["emailconfirmed"] == "True";
            }

            return user;
        }

        public List<TUser> GetUserByname(string username)
        {
            if (username != null)
                username = username.ToLower();

            List<TUser> users = new List<TUser>();
            string commandText = "SELECT * FROM \"subscribers\" WHERE LOWER(\"username\") = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@name", username } };

            var rows = _database.Query(commandText, parameters);
            foreach(var row in rows)
            {
                TUser user = (TUser)Activator.CreateInstance(typeof(TUser));
                user.Id = row["id"];
                user.UserName = row["username"];
                user.PasswordHash = string.IsNullOrEmpty(row["passwordhash"]) ? null : row["passwordhash"];
                user.SecurityStamp = string.IsNullOrEmpty(row["securitystamp"]) ? null : row["securitystamp"];
                user.Email = string.IsNullOrEmpty(row["email"]) ? null : row["email"];
                user.EmailConfirmed = row["emailconfirmed"] == "True";
                users.Add(user);
            }

            return users;
        }

        public List<TUser> GetUserByemail(string email)
        {
            if (email != null)
                email = email.ToLower();

            List<TUser> users = new List<TUser>();
            string commandText = "SELECT * FROM \"subscribers\" WHERE LOWER(\"email\") = @email";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@email", email } };

            var rows = _database.Query(commandText, parameters);
            foreach (var row in rows)
            {
                TUser user = (TUser)Activator.CreateInstance(typeof(TUser));
                user.Id = row["id"];
                user.UserName = row["username"];
                user.PasswordHash = string.IsNullOrEmpty(row["passwordhash"]) ? null : row["passwordhash"];
                user.SecurityStamp = string.IsNullOrEmpty(row["securitystamp"]) ? null : row["securitystamp"];
                user.Email = string.IsNullOrEmpty(row["email"]) ? null : row["email"];
                user.EmailConfirmed = row["emailconfirmed"] == "True";
                users.Add(user);
            }

            return users;
        }

        public string Getpasswordhash(string subscriberid)
        {
            string commandText = "SELECT \"passwordhash\" FROM \"subscribers\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", subscriberid);

            var passHash = _database.GetStrValue(commandText, parameters);
            if(string.IsNullOrEmpty(passHash))
            {
                return null;
            }

            return passHash;
        }
        public string GetClientId(string subscriberid)
        {
            string commandText = "SELECT \"client_id\" FROM \"subscribers\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", subscriberid);

            var clientId = _database.GetStrValue(commandText, parameters);
            if (string.IsNullOrEmpty(clientId))
            {
                return null;
            }

            return clientId;
        }
        public string GetClientSecret(string subscriberid)
        {
            string commandText = "SELECT \"client_secret\" FROM \"subscribers\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", subscriberid);

            var clientSecret = _database.GetStrValue(commandText, parameters);
            if (string.IsNullOrEmpty(clientSecret))
            {
                return null;
            }

            return clientSecret;
        }

        public int Setpasswordhash(string subscriberid, string passwordhash)
        {
            string commandText = "UPDATE \"subscribers\" SET \"passwordhash\" = @pwdHash WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@pwdHash", passwordhash);
            parameters.Add("@id", subscriberid);

            return _database.Execute(commandText, parameters);
        }

        public string Getsecuritystamp(string subscriberid)
        {
            string commandText = "SELECT \"securitystamp\" FROM \"subscribers\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", subscriberid } };
            var result = _database.GetStrValue(commandText, parameters);

            return result;
        }

        public int Insert(TUser user)
        {
            var lowerCaseemail = user.Email == null ? null : user.Email.ToLower();

            string commandText = @"
            INSERT INTO ""subscribers""(""id"", 
""username"", 
""passwordhash"", 
""securitystamp"", 
""email"", 
""emailconfirmed"")
            VALUES (@id, @name, @pwdHash, @SecStamp, @email, @emailconfirmed);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", user.UserName);
            parameters.Add("@id", user.Id);
            parameters.Add("@pwdHash", user.PasswordHash);
            parameters.Add("@SecStamp", user.SecurityStamp);
            parameters.Add("@email", user.Email);
            parameters.Add("@emailconfirmed", user.EmailConfirmed);
            return _database.Execute(commandText, parameters);
        }

        private int Delete(string subscriberid)
        {
            string commandText = "DELETE FROM \"subscribers\" WHERE \"id\" = @subscriberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@subscriberid", subscriberid);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(TUser user)
        {
            return Delete(user.Id);
        }

        public int Update(TUser user)
        {
            var lowerCaseemail = user.Email == null ? null : user.Email.ToLower();

            string commandText = "UPDATE \"subscribers\" SET \"username\" = @username, \"passwordhash\" = @pswHash, \"securitystamp\" = @secStamp, \"email\"= @email, \"emailconfirmed\" = @emailconfirmed WHERE \"id\" = @subscriberid;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@username", user.UserName);
            parameters.Add("@pswHash", user.PasswordHash);
            parameters.Add("@secStamp", user.SecurityStamp);
            parameters.Add("@subscriberid", user.Id);
            parameters.Add("@email", user.Email);
            parameters.Add("@emailconfirmed", user.EmailConfirmed);

            return _database.Execute(commandText, parameters);
        }
    }
}
