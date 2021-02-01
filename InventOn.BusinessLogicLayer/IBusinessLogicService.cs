using InventOn.BusinessLogicLayer.BusinessModels;
using System.Collections.Generic;

namespace InventOn.BusinessLogicLayer
{
    public interface IBusinessLogicService
    {
        List<BusinessBook> GetAllBooks();
        BusinessBook GetBookById(int id);
        void AddBook(BusinessBook book);
        void AddBooks(List<BusinessBook> books);
        void RemoveBook(BusinessBook book);
        void UpdateBook(BusinessBook book);
    }
}
