using InventOn.DataSourceLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventOn.DataSourceLayer
{
    public class DatabaseSource : IDataSourceConnectionService
    {
        private List<Book> _elements;

        public DatabaseSource()
        {
            _elements = FillWithMockData();
        }

        public List<Book> GetAllItems()
        {
            return _elements;
        }

        public Book GetItemById(int id)
        {
            return _elements.FirstOrDefault(x => x.Id == id);
        }

        public void InsertItem(Book item)
        {
            _elements.Add(item);
        }

        public void DeleteItem(Book item)
        {
            _elements.Remove(_elements.FirstOrDefault(x => x.Id == item.Id));
        }

        public void DeleteItemById(int id)
        {
            _elements.Remove(_elements.FirstOrDefault(x => x.Id == id));
        }

        public void UpdateItem(Book item)
        {
            DeleteItemById(item.Id);
            InsertItem(item);
        }

        private List<Book> FillWithMockData()
        {
            return new List<Book>
            {
                new Book(1, "The Book", "Martin M", 340, BookCategory.Criminal, new System.DateTime(2020, 10, 1)),
                new Book(2, "The Second Book", "Steven S", 520, BookCategory.Fantasy, new System.DateTime(2018, 10, 1)),
                new Book(3, "The Third Book", "Andrew A", 610, BookCategory.Criminal, new System.DateTime(2012, 10, 1)),
                new Book(4, "The Fourth Book", "Thomas T", 700, BookCategory.Romance, new System.DateTime(2003, 10, 1)),
                new Book(5, "The Fifth Book", "Robert R", 250, BookCategory.Romance, new System.DateTime(1956, 10, 1)),
            };
        }
    }
}
