using InventOn.DataSourceLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace InventOn.BusinessLogicLayer.BusinessModels
{
    [Serializable]
    public class BusinessBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public BookCategory Category { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
        public string BookAdvertisement { get; set; }

        public override string ToString()
        {
            return BookAdvertisement;
        }
    }
}
