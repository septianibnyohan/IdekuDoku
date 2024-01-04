using MongoDB.Driver;

namespace IdekuDoku.Domain.Entities;

public interface IMongoDBContext
{ 
    IMongoDatabase Database { get; }
}
