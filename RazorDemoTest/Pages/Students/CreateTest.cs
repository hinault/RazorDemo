using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    public class CreateTest : BaseTest
    {

        [TestMethod]
        public void TestMethod3()
        {
            var createModel = new CreateModel(Context);

            var page = createModel.OnGet() as PageResult;

            //assert
            Assert.IsNotNull(page);

        }
    }
}
