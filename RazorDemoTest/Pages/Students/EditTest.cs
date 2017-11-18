using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    public class editTest :BaseTest
    {
        [TestMethod]
        public async Task OnGetAsync_ReturnPage()
        {
            //Arrange
            var editModel = new EditModel(Context);

            //Act
           var page = await editModel.OnGetAsync(3) as PageResult;

            //Assert
            Assert.IsNotNull(page);
            var student = editModel.Student;
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
            var editModel = new EditModel(Context);

            //Act
            IActionResult actionResult = await editModel.OnGetAsync(null);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(editModel.Student);
        }


        [TestMethod]
        public async Task OnGetAsync_ReturnNotFound_WithId()
        {
            //Arrange
            var editModel = new EditModel(Context);

            //Act
            IActionResult actionResult = await editModel.OnGetAsync(6);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(editModel.Student);
        }

        [TestMethod]
        public async Task OnPostAsync_ReturnPageResult()
        {
            //Arrange
            var editModel = new EditModel(Context);
            editModel.Student = new RazorDemo.Models.Student();
            editModel.PageContext = new PageContext();
            editModel.ModelState.AddModelError("FirstName", "Required");

            //Act
            var page = await editModel.OnPostAsync() as PageResult;

            //Assert
            Assert.IsNotNull(page);
        }


        [TestMethod]
        public async Task OnPostAsync_ReturnRedirectToPageResult()
        {
            //Arrange
            var editModel = new EditModel(Context);
            editModel.Student = await Context.Student.SingleOrDefaultAsync(m => m.Id == 3);
            editModel.Student.FirstName = "Jean";
            editModel.PageContext = new PageContext();

            //Act
            var redirect = await editModel.OnPostAsync() as RedirectToPageResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual(redirect.PageName, "./Index");
        }
    }
}
