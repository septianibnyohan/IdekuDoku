namespace IdekuDoku.Domain.Settings;

// IMongoDBSettings.cs
public interface IMongoDBSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}