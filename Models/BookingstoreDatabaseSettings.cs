namespace Models
{
    public class BookingstoreDatabaseSettings : IBookingstoreDatabaseSettings
    {
        public string BookingsCollectionName {get; set;}
        public string ConnectionString {get; set;}
        public string DatabaseName {get; set;}
    }

    public interface IBookingstoreDatabaseSettings
    {
        string BookingsCollectionName {get; set;}
        string ConnectionString {get; set;}
        string DatabaseName {get; set;}
    }
}