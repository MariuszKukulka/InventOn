using InventOn.BusinessLogicLayer;
using InventOn.BusinessLogicLayer.BusinessModels;
using InventOn.DataSourceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InventOn.Test
{
    [TestClass]
    public class BusinessLayerTest
    {
        [TestMethod]
        public void RemoveBookTest()
        {
            var databaseSource = DataSourceServiceFactory.GetDatabaseConnection();
            var businessLogic = new BookBusinessLogic(databaseSource);
            int expectedBooksAmount = 4;

            businessLogic.RemoveBook(businessLogic.GetBookById(5));
            var actualBooksAmount = businessLogic.GetAllBooks().Count;

            Assert.AreEqual(expectedBooksAmount, actualBooksAmount, 0, "Book was not removed!");
        }

        [TestMethod]
        public void AddBookTest()
        {
            var databaseSource = DataSourceServiceFactory.GetDatabaseConnection();
            var businessLogic = new BookBusinessLogic(databaseSource);
            int expectedBooksAmount = 6;

            businessLogic.AddBook(new BusinessBook() { Id = 6 });
            var actualBooksAmount = businessLogic.GetAllBooks().Count;

            Assert.AreEqual(expectedBooksAmount, actualBooksAmount, 0, "Book has not been added");
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            var databaseSource = DataSourceServiceFactory.GetDatabaseConnection();
            var businessLogic = new BookBusinessLogic(databaseSource);
            string expectedBookName = "UpdateTest";

            var book = businessLogic.GetAllBooks().LastOrDefault();
            book.Name = "UpdateTest";
            businessLogic.UpdateBook(book);
            var actualBookTitle = businessLogic.GetAllBooks().LastOrDefault().Name;

            Assert.AreSame(expectedBookName, actualBookTitle, "Books' title has not been changed");
        }
    }
}
