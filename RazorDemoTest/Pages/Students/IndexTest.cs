using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    public class IndexTest : BaseTest
    {
        [TestMethod]
        public async Task TestMethod3()
        {
            var indexModel = new IndexModel(Context);

           await indexModel.OnGetAsync();

            var students = indexModel.Student;


            Assert.AreEqual(3, students.Count);

        }

    }


   
}
