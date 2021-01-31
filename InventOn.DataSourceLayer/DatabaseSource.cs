using InventOn.DataSourceLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventOn.DataSourceLayer
{
    public class DatabaseSource : IDataSourceConnection
    {
        private List<ModelBase> _elements;

        public DatabaseSource()
        {
            _elements = new List<ModelBase>();
        }

        public List<ModelBase> GetAllItems()
        {
            return _elements;
        }

        public ModelBase GetItemById(int id)
        {
            return _elements.FirstOrDefault(x => x.Id == id);
        }

        public void InsertItem(ModelBase item)
        {
            _elements.Add(item);
        }

        public bool DeleteItem(ModelBase item)
        {
            return _elements.Remove(item);
        }

        public void DeleteItemById(int id)
        {
            _elements.RemoveAt(id);
        }

        public void UpdateItem(int id, ModelBase item)
        {
            var elementToUpdate = _elements.FirstOrDefault(x => x.Id == id);
            elementToUpdate = item;
        }
    }
}
