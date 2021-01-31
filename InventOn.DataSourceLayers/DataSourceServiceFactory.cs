using InventOn.DataSourceLayer;

namespace InventOn.Test
{
    public static class DataSourceServiceFactory
    {
        public static IDataSourceConnectionService GetDatabaseConnection()
        {
            return new DatabaseSource();
        }

        public static IDataSourceConnectionService GetFileConnection()
        {
            return new FileSource();
        }
    }
}