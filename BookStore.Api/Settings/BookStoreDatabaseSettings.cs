namespace BookStore.Api.Settings
{
    public class BookStoreDatabaseSettings : IBookStoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; } = string.Empty;
        public string UsersCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }

    public interface IBookStoreDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}