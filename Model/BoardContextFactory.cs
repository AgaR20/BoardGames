using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Model
{
    public class BoardContextFactory: IDesignTimeDbContextFactory<BoardContext>
    {
        public BoardContext CreateDbContext(string[] args)
       {
           var connectionString = GetConnectionString();
           var builder = new DbContextOptionsBuilder<BoardContext>();
           builder.UseSqlServer(connectionString, x => x.MigrationsAssembly("WebApp"));

           return new BoardContext(builder.Options);
       }

       public static string GetConnectionString()
       {
           string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

           IConfigurationRoot configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{environmentName}.json", true)
               .AddEnvironmentVariables().Build();

           string connectionString = configuration.GetConnectionString("DefaultConnection");
           return connectionString;
       }
    }
}
