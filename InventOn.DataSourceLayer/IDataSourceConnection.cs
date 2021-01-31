using InventOn.DataSourceLayer.Models;
using System.Collections.Generic;

namespace InventOn.DataSourceLayer
{
    public interface IDataSourceConnection
    {
        List<ModelBase> GetAllItems();
        ModelBase GetItemById(int id);
        void InsertItem(ModelBase item);
        bool DeleteItem(ModelBase item);
        void DeleteItemById(int id);
        void UpdateItem(int id, ModelBase item);
    }
}
