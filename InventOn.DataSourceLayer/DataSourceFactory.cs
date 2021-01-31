namespace InventOn.DataSourceLayer
{
    public abstract class DataSourceFactory
    {
        public static IDataSourceConnection GetDatabaseConnection()
        {
            return new DatabaseSource();
        }
    }
}
