using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Xml;
using System.IO;
using pms.domain;

namespace pms.repository
{
    public class UserRepository:BaseRepository
    {
        static string dataConnection = GetConnectionString("conString");
        public User ValidateLogin(string UserName, string EncryptedPassword)
        {
            using (IDbConnection connection = OpenConnection(dataConnection))
            {
                string query = String.Format(@"SELECT [usrId]
                                                  ,[usrUserName]
                                                  ,[usrPassword]
                                                  ,[usrEmployeeName]
                                                  ,[usrEmail]
                                                  ,[usrExpiry]
                                                  ,[usrGUID]
                                                  ,[usrLastUpdate]
                                              FROM [dbo].[User]
                                              WHERE [usrUserName]='{0}'
                                              AND [usrPassword]='{1}'", UserName, EncryptedPassword);

                return connection.Query<User>(query).FirstOrDefault();
            }
        }
        public List<User> GetuserList()
        {
            using (IDbConnection connection = OpenConnection(dataConnection))
            {
                string query = @"SELECT [usrId]
                                        ,[usrUserName]
                                        ,[usrPassword]
                                        ,[usrEmployeeName]
                                        ,[usrEmail]
                                        ,[usrExpiry]
                                        ,[usrGUID]
                                        ,[usrLastUpdate]
                                    FROM [dbo].[User]
                                    ORDER BY [usrUserName]";

                return connection.Query<User>(query).ToList();
            }
        }
        public int CreateUser(User model)
        {
            using (IDbConnection connection = OpenConnection(dataConnection))
            {
                model.usrGUID = Guid.NewGuid();
                model.usrLastUpdate = DateTime.Now;

                string query = @"INSERT INTO [dbo].[User]
                                   ([usrUserName]
                                   ,[usrPassword]
                                   ,[usrEmployeeName]
                                   ,[usrEmail]
                                   ,[usrExpiry]
                                   ,[usrGUID]
                                   ,[usrLastUpdate])
                             VALUES
                                   (@usrUserName
			                        ,@usrPassword
			                        ,@usrEmployeeName
			                        ,@usrEmail
			                        ,@usrExpiry
			                        ,@usrGUID
			                        ,@usrLastUpdate)";
                int affectedRows = connection.Execute(query, model);
                return affectedRows;
            }
        }
        public User GetUserById(string Id)
        {
            using (IDbConnection connection = OpenConnection(dataConnection))
            {
                string query = String.Format(@"SELECT [usrId]
                                                  ,[usrUserName]
                                                  ,[usrPassword]
                                                  ,[usrEmployeeName]
                                                  ,[usrEmail]
                                                  ,[usrExpiry]
                                                  ,[usrGUID]
                                                  ,[usrLastUpdate]
                                              FROM [dbo].[User]
                                              WHERE [usrGUID]='{0}'", Id);

                return connection.Query<User>(query).FirstOrDefault();
            }
        }
        public int EditUser(User model)
        {
            using (IDbConnection connection = OpenConnection(dataConnection))
            {
                model.usrLastUpdate = DateTime.Now;

                string query = @"UPDATE [dbo].[User] SET
                                   [usrUserName] = @usrUserName
                                   ,[usrEmployeeName] = @usrEmployeeName
                                   ,[usrEmail] = @usrEmail
                                   ,[usrExpiry] = @usrExpiry
                                   ,[usrLastUpdate] = @usrLastUpdate
                                WHERE
                                   [usrGUID] = @usrGUID
			                       AND [usrId] = @usrId";
                int affectedRows = connection.Execute(query, model);

                if(model.usrPassword != "")
                {
                    query = @"UPDATE [dbo].[User] SET
                                   [usrPassword] = @usrPassword
                                WHERE
                                   [usrGUID] = @usrGUID
			                       AND [usrId] = @usrId";
                    affectedRows = connection.Execute(query, model);
                }
                return affectedRows;
            }
        }
    }
}
