using System;

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
    public class Book : ModelBase
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public BookCategory Category { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
