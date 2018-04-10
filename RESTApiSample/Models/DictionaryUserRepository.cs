using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTApiSample.Models
{
    public class DictionaryUserRepository : IUserRepository
    {
        int nextID = 5;
        public static Dictionary<int, User> users = new Dictionary<int, User>()
        {
            { 1, new User(1, "test_first_1", "test_last_1", "test_email_1@email.com", "test_password_1") },
            { 2, new User(2, "test_first_2", "test_last_2", "test_email_2@email.com", "test_password_2") },
            { 3, new User(3, "test_first_3", "test_last_3", "test_email_3@email.com", "test_password_3") },
            { 4, new User(4, "test_first_4", "test_last_4", "test_email_4@email.com", "test_password_4") },
            { 5, new User(5, "test_first_5", "test_last_5", "test_email_5@email.com", "test_password_5") }
        };

        public IEnumerable<User> Get()
        {
            return users.Values.OrderBy(user => user.ID);
        }

        public bool TryGet(int id, out User user)
        {
            return users.TryGetValue(id, out user);
        }

        public User Add(User user)
        {
            user.ID = nextID++;
            users[user.ID] = user;
            return user;
        }

        public bool Delete(int id)
        {
            return users.Remove(id);
        }

        public User Update(User user, User updated)
        {
            user.FirstName = updated.FirstName;
            user.LastName = updated.LastName;
            user.Email = updated.Email;

            return user;
        }
    }
}