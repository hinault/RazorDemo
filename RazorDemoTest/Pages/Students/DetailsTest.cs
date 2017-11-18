using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    public class DetailsTest : BaseTest
    {

        [TestMethod]
        public async Task OnGetAsync_ReturnStudent()
        {
            //Arrange
            var detailsModel = new DetailsModel(Context);

            //Act
            var page = await detailsModel.OnGetAsync(3) as PageResult;

            //Assert
            Assert.IsNotNull(page);
            var student = detailsModel.Student;
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
            var detailsModel = new DetailsModel(Context);

            //Act
            IActionResult actionResult =  await detailsModel.OnGetAsync(null);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(detailsModel.Student);
        }


        [TestMethod]
        public async Task OnGetAsync_ReturnNotFound_WithId()
        {
            //Arrange
            var detailsModel = new DetailsModel(Context);

            //Act
            IActionResult actionResult = await detailsModel.OnGetAsync(6);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            Assert.IsNull(detailsModel.Student);
        }
    }
}
