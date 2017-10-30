using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RazorDemo.Models
{
public class RazorDemoDbContextFactory : IDesignTimeDbContextFactory<RazorDemoContext>
{


        public RazorDemoContext CreateDbContext(string[] args)
        {
                  var builder = new DbContextOptionsBuilder<RazorDemoContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
     .AddJsonFile("appsettings.json")
     .Build();


            builder.UseSqlite(configuration.GetConnectionString("SqliteConnectionString"));
        return new RazorDemoContext(builder.Options);
      }
}
}