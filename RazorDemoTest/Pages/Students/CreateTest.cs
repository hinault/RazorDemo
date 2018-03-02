using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public void OnGet_ReturnPageResult()
        {  
            //Arrange
            var createModel = new CreateModel(Context);

            //Act
            var page = createModel.OnGet() as PageResult;

            //Assert
            Assert.IsNotNull(page);

        }

            [TestMethod]
            public async Task OnPostAsync_ReturnPageResult()
            {
                //Arrange
                var createModel = new CreateModel(Context);
                createModel.Student = new RazorDemo.Models.Student();
                createModel.PageContext = new PageContext();
                createModel.ModelState.AddModelError("FirstName", "Required");

                //Act
                var page = await createModel.OnPostAsync() as PageResult;

                //Assert
                Assert.IsNotNull(page);
            }


        [TestMethod]
        public async Task OnPostAsync_ReturnRedirectToPageResult()
        {
            //Arrange
            var createModel = new CreateModel(Context);
            createModel.Student = new RazorDemo.Models.Student() { Id = 4,
                                                                  FirstName ="Thomas",
                                                                  LastName="Larabi",
                                                                 Email = "Thomas.Larabi@gmail.com"};
            createModel.PageContext = new PageContext();
           
            //Act
            var redirect = await createModel.OnPostAsync() as RedirectToPageResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual(redirect.PageName, "./Index");
        }


    }
}
