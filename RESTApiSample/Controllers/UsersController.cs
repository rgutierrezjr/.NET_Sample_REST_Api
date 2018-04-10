using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using RESTApiSample.Models;
using System.Web.Http;

namespace RESTApiSample.Controllers
{
    //TOD: add validation 
    public class UsersController : ApiController
    {
        // in-memory Dictionary repository. (test only)
        IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/User 
        public IEnumerable<User> GetUsers()
        {
            return repository.Get();
        }

        // GET: api/User/5
        public User GetUser(int id)
        {
            if (!repository.TryGet(id, out User user))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return user;
        }

        // POST: api/User
        public HttpResponseMessage Post(User user)
        {
            user = repository.Add(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/users/" + user.ID.ToString());
            return response;
        }

        // PUT: api/User/5
        public User Put(int id, [FromBody]User updated)
        {
            if (!repository.TryGet(id, out User user))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            repository.Update(user, updated);
            return user;
        }

        // DELETE: api/User/5
        public User Delete(int id)
        {
            User user;
            if (!repository.TryGet(id, out user))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            repository.Delete(id);
            return user;
        }
    }
}
