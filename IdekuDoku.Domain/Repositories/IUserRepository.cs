using IdekuDoku.Domain.Entities;

namespace IdekuDoku.Domain.Repositories;

// Repositories
public interface IUserRepository
{
  User GetUserById(int userId);
  // Other user-related methods
}