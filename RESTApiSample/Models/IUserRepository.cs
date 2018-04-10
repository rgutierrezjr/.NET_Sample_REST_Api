using System.Collections.Generic;

namespace RESTApiSample.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        bool TryGet(int id, out User user);
        User Add(User user);
        bool Delete(int id);
        User Update(User user, User updated);
    }
}
