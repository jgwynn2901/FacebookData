using System.Collections.Generic;
using System.Linq;
using Dapper;
using FacebookData.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace FacebookData.Repository
{
  public class UserRepository :BaseRepository , IRepository<User>
  {
    private const string Query =
      "select id, name as Name, email as Email, password as Password from \"Facebook\".users";
    public UserRepository(IConfiguration configuration) : base(configuration)
    { }

    public int Add(User item)
    {
      const string sql = "insert into \"Facebook\".users (name,email,password) values(:name, :email, :pass) RETURNING id";
      using var dbConnection = Connection;
      dbConnection.Open();

      using var insertCmd =
        new NpgsqlCommand(sql, dbConnection);
        
      var nameParam = new NpgsqlParameter("name", NpgsqlDbType.Integer);
      var emailParam = new NpgsqlParameter("email", NpgsqlDbType.Varchar);
      var passParam = new NpgsqlParameter("pass", NpgsqlDbType.Varchar);

      nameParam.Value = item.Name;
      emailParam.Value = item.Email;
      passParam.Value = item.Password;
      
      insertCmd.Parameters.Add(nameParam);
      insertCmd.Parameters.Add(emailParam);
      insertCmd.Parameters.Add(passParam);

      return (int)insertCmd.ExecuteScalar();
    }

    public bool Remove(int id)
    {
      return false;
    }

    public bool Update(User item)
    {
      return false;
    }

    public User FindById(int id)
    {
      var sql = $"{Query} where id= {id}";
      using var dbConnection = Connection;
      dbConnection.Open();
      var result = dbConnection.Query<User>(sql).FirstOrDefault();
      return result;
    }

    public IEnumerable<User> FindAll()
    {
      const string sql = Query + " order by 1";
      using var dbConnection = Connection;
      dbConnection.Open();
      return dbConnection.Query<User>(sql);
    }
  }
}
