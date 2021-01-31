using InventOn.DataSourceLayer.Models;
using System.Collections.Generic;

namespace InventOn.DataSourceLayer
{
    public interface IDataSourceConnectionService
    {
        List<Book> GetAllItems();
        Book GetItemById(int id);
        void InsertItem(Book item);
        void DeleteItem(Book item);
        void DeleteItemById(int id);
        void UpdateItem(Book item);
    }
}
