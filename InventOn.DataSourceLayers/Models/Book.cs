using System;
using System.ComponentModel.DataAnnotations;

namespace InventOn.DataSourceLayer.Models
{
    [Serializable]
    public enum BookCategory
    {
        Fantasy,
        Criminal,
        Romance
    }

    [Serializable]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public BookCategory Category { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
        public string BookAdvertisement { get; set; }

        public Book() { }

        public Book(int id, string name, string author, int pages, BookCategory category, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            Author = author;
            Pages = pages;
            Category = category;
            ReleaseDate = releaseDate;
        }
    }
}
