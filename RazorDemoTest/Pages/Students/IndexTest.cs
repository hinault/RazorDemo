using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorDemo.Pages.Students;
using System.Threading.Tasks;

namespace RazorDemoTest.Pages.Students
{
    [TestClass]
    public class IndexTest : BaseTest
    {
        [TestMethod]
        public async Task OnGetAsync_ReturnAllStudents()
        {
            //Arrange
            var indexModel = new IndexModel(Context);

            //Act
            await indexModel.OnGetAsync();

            //Assert
            var students = indexModel.Student;
            Assert.IsNotNull(students);
            Assert.AreEqual(3, students.Count);

        }

    }


   
}
