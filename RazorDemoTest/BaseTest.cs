using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Models;
using System.Threading.Tasks;

namespace RazorDemoTest
{
    [TestClass]
    public class BaseTest
    {

        protected RazorDemoContext Context;


        private static DbContextOptions<RazorDemoContext> CreateNewContextOptions()
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();


            var builder = new DbContextOptionsBuilder<RazorDemoContext>();
            builder.UseInMemoryDatabase(databaseName: "InMemoryDb")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        [TestInitialize]
        public async Task Init()
        {


            var options = CreateNewContextOptions();
            Context = new RazorDemoContext(options);

           
            // var service = new StudentsRepository(context);
            Context.Add(new Student { Id = 1, Email = "j.papavoisi@gmail.com", FirstName = "Papavoisi", LastName = "Jean" });
            Context.Add(new Student { Id = 2, Email = "p.garden@gmail.com", FirstName = "Garden", LastName = "Pierre" });
            Context.Add(new Student { Id = 3, Email = "r.derosi@gmail.com", FirstName = "Derosi", LastName = "Ronald" });

            await Context.SaveChangesAsync();
        }

    }
}
