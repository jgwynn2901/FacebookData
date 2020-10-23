using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using FacebookData.Models;
using Microsoft.Extensions.Configuration;

namespace FacebookData.Repository
{
  public class PostRepository :BaseRepository , IRepository<Post>
  {
    private const string Query =
      "select id, user_id as UserId, title, timestamp, post as Text, uri from \"Facebook\".posts";
    public PostRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public int Add(Post item)
    {
      throw new NotImplementedException();
    }

    public bool Remove(int id)
    {
      throw new NotImplementedException();
    }

    public bool Update(Post item)
    {
      throw new NotImplementedException();
    }

    public Post FindById(int id)
    {
      var sql = $"{Query} where id= {id}";
      using var dbConnection = Connection;
      dbConnection.Open();
      var result = dbConnection.Query<Post>(sql).FirstOrDefault();
      return result;
    }

    public IEnumerable<Post> FindAll()
    {
      const string sql = Query + " order by timestamp desc LIMIT 100";
      using var dbConnection = Connection;
      dbConnection.Open();
      return dbConnection.Query<Post>(sql);
    }
  }
}
