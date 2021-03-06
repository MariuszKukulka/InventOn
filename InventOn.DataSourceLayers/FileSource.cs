﻿using InventOn.DataSourceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventOn.DataSourceLayer
{
    public class FileSource : IDataSourceConnectionService
    {
        private List<Book> _elements;

        public FileSource()
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

        public void InsertItems(List<Book> items)
        {
            var expectedCount = _elements.Count + items.Count;
            var books = new List<Book>(_elements);
            try
            {
                books.AddRange(items);
                if (expectedCount == books.Count)
                {
                    _elements = books;
                }
                else throw new Exception(String.Empty);
            }
            catch (Exception)
            {
                Console.WriteLine($"Couldn't add all books.");
            }
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
            var elementToUpdate = _elements.FirstOrDefault(x => x.Id == item.Id);
            elementToUpdate = item;
        }

        private List<Book> FillWithMockData()
        {
            return new List<Book>
            {
                new Book(1, "E-Book First", "A.A", 300, BookCategory.Criminal, new System.DateTime(2020, 10, 1)),
                new Book(2, "E-Book Second", "B.B", 400, BookCategory.Fantasy, new System.DateTime(2018, 10, 1)),
                new Book(3, "E-Book Third", "C.C", 500, BookCategory.Criminal, new System.DateTime(2012, 10, 1)),
                new Book(4, "E-Book Fourth", "D.D", 600, BookCategory.Romance, new System.DateTime(2003, 10, 1)),
                new Book(5, "E-Book Fifth", "E.E", 700, BookCategory.Romance, new System.DateTime(1956, 10, 1)),
            };
        }
    }
}
