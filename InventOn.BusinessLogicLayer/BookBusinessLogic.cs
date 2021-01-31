using AutoMapper;
using InventOn.BusinessLogicLayer.BusinessModels;
using InventOn.DataSourceLayer;
using InventOn.DataSourceLayer.Models;
using System.Collections.Generic;

namespace InventOn.BusinessLogicLayer
{
    public class BookBusinessLogic : IBusinessLogicService
    {
        private IDataSourceConnectionService _dataSourceConnection;
        private IMapper bookRetriever;
        private IMapper bookSender;

        public BookBusinessLogic(IDataSourceConnectionService dataSourceConnection)
        {
            _dataSourceConnection = dataSourceConnection;

            var bookRetrieverConfig = new MapperConfiguration(m =>
            {
                m.CreateMap<Book, BusinessBook>()
                .ForMember(dest => dest.Price, map => map.MapFrom(x => x.Pages * 0.10))
                .ForMember(dest => dest.BookAdvertisement, map => map.MapFrom(x => $"'{x.Name}' written by {x.Author} on {x.ReleaseDate} [{x.Category}]"));
            });
            bookRetriever = bookRetrieverConfig.CreateMapper();

            var bookSenderConfig = new MapperConfiguration(m =>
            {
                m.CreateMap<BusinessBook, Book>();
            });
            bookSender = bookSenderConfig.CreateMapper();
        }

        public List<BusinessBook> GetAllBooks()
        {
            return bookRetriever.Map(_dataSourceConnection.GetAllItems(), new List<BusinessBook>());
        }

        public BusinessBook GetBookById(int id)
        {
            return bookRetriever.Map(_dataSourceConnection.GetItemById(id), new BusinessBook());
        }

        public void AddBook(BusinessBook book)
        {
            _dataSourceConnection.InsertItem(bookSender.Map(book, new Book()));
        }

        public void RemoveBook(BusinessBook book)
        {
            _dataSourceConnection.DeleteItem(bookSender.Map(book, new Book()));
        }

        public void UpdateBook(BusinessBook book)
        {
            _dataSourceConnection.UpdateItem(bookSender.Map(book, new Book()));
        }
    }
}
