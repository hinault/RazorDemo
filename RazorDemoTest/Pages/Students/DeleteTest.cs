using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    class DeleteTest : BaseTest
    {
        [TestMethod]
        public async Task OnGetAsync_ReturnStudent()
        {
            //Arrange
            var deleteModel = new DeleteModel(Context);

            //Act
            var page = await deleteModel.OnGetAsync(3) as PageResult;

            //Assert
            Assert.IsNotNull(page);
            var student = deleteModel.Student;
            Assert.IsNotNull(student);
            Assert.AreEqual(3, student.Id);
            Assert.AreEqual("Derosi", student.FirstName);
            Assert.AreEqual("Ronald", student.LastName);
            Assert.AreEqual("r.derosi@gmail.com", student.Email);

        }

        [TestMethod]
        public async Task OnGetAsync_ReturnNotFound_WithNullId()
        {
            //Arrange
            var deleteModel = new DeleteModel(Context);

            //Act
            IActionResult actionResult = await deleteModel.OnGetAsync(null);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(deleteModel.Student);
        }


        [TestMethod]
        public async Task OnGetAsync_ReturnNotFound_WithId()
        {
            //Arrange
            var deleteModel = new DeleteModel(Context);

            //Act
            IActionResult actionResult = await deleteModel.OnGetAsync(6);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(deleteModel.Student);
        }

        [TestMethod]
        public async Task OnPostAsync_ReturnPageResult()
        {
            //Arrange
            var deleteModel = new DeleteModel(Context);

            //Act
            IActionResult actionResult = await deleteModel.OnPostAsync(null) t;

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(deleteModel.Student);
        }


        [TestMethod]
        public async Task OnPostAsync_ReturnRedirectToPageResult()
        {
            //Arrange
            var deleteModel = new DeleteModel(Context);
            

            //Act
            var redirect = await deleteModel.OnPostAsync(1) as RedirectToPageResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual(redirect.PageName, "./Index");
            Assert.IsNotNull(deleteModel.Student);
        }
    }
}
