using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    public class EditTest :BaseTest
    {
        [TestMethod]
        public async Task OnGetAsync_ReturnStudent()
        {
            //Arrange
            var EditModel = new EditModel(Context);

            //Act
            await EditModel.OnGetAsync(3);

            //Assert
            var student = EditModel.Student;
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
            var EditModel = new EditModel(Context);

            //Act
            IActionResult actionResult = await EditModel.OnGetAsync(null);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(EditModel.Student);
        }


        [TestMethod]
        public async Task OnGetAsync_ReturnNotFound_WithId()
        {
            //Arrange
            var EditModel = new EditModel(Context);

            //Act
            IActionResult actionResult = await EditModel.OnGetAsync(6);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(EditModel.Student);
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
            createModel.Student = await Context.Student.SingleOrDefaultAsync(m => m.Id == 3);
            createModel.Student.FirstName = "Jean";
            createModel.PageContext = new PageContext();

            //Act
            var redirect = await createModel.OnPostAsync() as RedirectToPageResult;

            //Assert
            Assert.IsNotNull(redirect);
            Assert.AreEqual(redirect.PageName, "./Index");
        }
    }
}
