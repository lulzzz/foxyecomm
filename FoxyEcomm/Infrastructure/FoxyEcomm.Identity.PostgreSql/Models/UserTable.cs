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

        public string Getusername(string memberid)
        {
            string commandText = "SELECT \"username\" FROM \"members\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", memberid } };

            return _database.GetStrValue(commandText, parameters);
        }

        public string GetUserid(string username)
        {
            if (username != null)
                username = username.ToLower();

            string commandText = "SELECT \"id\" FROM \"members\" WHERE LOWER(\"username\") = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@name", username } };

            return _database.GetStrValue(commandText, parameters);
        }

        public List<TUser> GetAllUsers()
        {
            List<TUser> users = new List<TUser>();

            string commandText = "SELECT * FROM \"members\"";
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

        public TUser GetUserByid(string memberid)
        {
            TUser user = null;
            string commandText = "SELECT * FROM \"members\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", memberid } };

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
            string commandText = "SELECT * FROM \"members\" WHERE LOWER(\"username\") = @name";
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
            string commandText = "SELECT * FROM \"members\" WHERE LOWER(\"email\") = @email";
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

        public string Getpasswordhash(string memberid)
        {
            string commandText = "SELECT \"passwordhash\" FROM \"members\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", memberid);

            var passHash = _database.GetStrValue(commandText, parameters);
            if(string.IsNullOrEmpty(passHash))
            {
                return null;
            }

            return passHash;
        }
        public string GetClientId(string memberid)
        {
            string commandText = "SELECT \"client_id\" FROM \"members\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", memberid);

            var clientId = _database.GetStrValue(commandText, parameters);
            if (string.IsNullOrEmpty(clientId))
            {
                return null;
            }

            return clientId;
        }
        public string GetClientSecret(string memberid)
        {
            string commandText = "SELECT \"client_secret\" FROM \"members\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", memberid);

            var clientSecret = _database.GetStrValue(commandText, parameters);
            if (string.IsNullOrEmpty(clientSecret))
            {
                return null;
            }

            return clientSecret;
        }

        public int Setpasswordhash(string memberid, string passwordhash)
        {
            string commandText = "UPDATE \"members\" SET \"passwordhash\" = @pwdHash WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@pwdHash", passwordhash);
            parameters.Add("@id", memberid);

            return _database.Execute(commandText, parameters);
        }

        public string Getsecuritystamp(string memberid)
        {
            string commandText = "SELECT \"securitystamp\" FROM \"members\" WHERE \"id\" = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", memberid } };
            var result = _database.GetStrValue(commandText, parameters);

            return result;
        }

        public int Insert(TUser user)
        {
            var lowerCaseemail = user.Email == null ? null : user.Email.ToLower();

            string commandText = @"
            INSERT INTO ""members""(""id"", 
""username"", 
""passwordhash"", 
""securitystamp"", 
""email"", 
""emailconfirmed"",""firstname"",""lastname"",""created"",""update_time"",""status"",""type"")
            VALUES (@id, @name, @pwdHash, @SecStamp, @email, @emailconfirmed,@firstname,@lastname,@created,@update_time,@status,@type);";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", user.UserName);
            parameters.Add("@id", user.Id);
            parameters.Add("@pwdHash", user.PasswordHash);
            parameters.Add("@SecStamp", user.SecurityStamp);
            parameters.Add("@email", user.Email);
            parameters.Add("@emailconfirmed", user.EmailConfirmed);
            parameters.Add("@firstname", user.FirstName);
            parameters.Add("@lastname", user.LastName);
            parameters.Add("@created", user.Created);
            parameters.Add("@update_time", user.UpdateTime);
            parameters.Add("@status", user.Status);
            return _database.Execute(commandText, parameters);
        }

        private int Delete(string memberid)
        {
            string commandText = "DELETE FROM \"members\" WHERE \"id\" = @memberid";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@memberid", memberid);

            return _database.Execute(commandText, parameters);
        }

        public int Delete(TUser user)
        {
            return Delete(user.Id);
        }

        public int Update(TUser user)
        {
            var lowerCaseemail = user.Email == null ? null : user.Email.ToLower();

            string commandText = "UPDATE \"members\" SET \"username\" = @username, \"passwordhash\" = @pswHash, \"securitystamp\" = @secStamp, \"email\"= @email, \"emailconfirmed\" = @emailconfirmed WHERE \"id\" = @memberid;";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@username", user.UserName);
            parameters.Add("@pswHash", user.PasswordHash);
            parameters.Add("@secStamp", user.SecurityStamp);
            parameters.Add("@memberid", user.Id);
            parameters.Add("@email", user.Email);
            parameters.Add("@emailconfirmed", user.EmailConfirmed);

            return _database.Execute(commandText, parameters);
        }
    }
}
