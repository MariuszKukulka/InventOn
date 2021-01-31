using InventOn.DataSourceLayer.Models;
using System;
using System.Collections.Generic;

namespace InventOn.DataSourceLayer
{
    public class FileSource : IDataSourceConnection
    {
        public bool DeleteItem(ModelBase item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItemById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ModelBase> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public ModelBase GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertItem(ModelBase item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int id, ModelBase item)
        {
            throw new NotImplementedException();
        }
    }
}
