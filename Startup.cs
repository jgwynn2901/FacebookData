using FacebookData.GraphQL;
using FacebookData.Repository;
using GraphQL;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacebookData
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSingleton(Configuration);
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
      services.AddSingleton<IDocumentWriter, DocumentWriter>();
      services.AddSingleton<PostRepository>();
      services.AddSingleton<FacebookQuery>();
      services.AddSingleton<ISchema, FacebookSchema>();
      services.AddGraphQL()
        .AddGraphTypes(ServiceLifetime.Singleton)
        .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }); // For .NET Core 3+
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
      
      app.UseGraphQL<ISchema>();
      app.UseGraphiQLServer();

    }
  }
}
