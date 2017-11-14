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


            builder.UseSqlServer("Server=tcp:razordemo.database.windows.net,1433;Initial Catalog=razordemo;Persist Security Info=False;User ID=razordemo;Password=Lilroma2000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        return new RazorDemoContext(builder.Options);
      }
}
}