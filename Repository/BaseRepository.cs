using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FacebookData.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FacebookData.Repository
{
  public class BaseRepository
  {
    protected readonly string ConnectionString;

    public BaseRepository(IConfiguration configuration)
    {
      ConnectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
    }

    protected NpgsqlConnection Connection => new NpgsqlConnection(ConnectionString);
  }
}
