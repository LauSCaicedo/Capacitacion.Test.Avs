using Capacitacion.Test.Avs.Business.Entities;
using Capacitacion.Test.Avs.Business.Services;
using Capacitacion.Test.Avs.Infraesctuture.Data;
using Microsoft.AspNetCore.Mvc;

namespace Capacitacion.Test.Avs.Api.Controllers
{
    [ApiController]
    [Route("Api/user")]
    public class UserController : ControllerBase
    {
        private readonly IServicesUser _serviceUser;

        public UserController()
        {
            _serviceUser = new ServiceUser(new UserData());

        }

        [HttpPost]
        public User Create([FromBody] User user)
        {
            return _serviceUser.Create(user);
        }

        [HttpGet("All")]
        public IEnumerable<User> GetAll()
        {
            return _serviceUser.GetAll();
        }

        [HttpPut]
        public User Update([FromBody] User user)
        {
            return _serviceUser.Update(user);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _serviceUser.Delete(id);
        }

        [HttpGet("{id:int}")]
        public User GetUserById(int id)
        {
            return _serviceUser.GetUserById(id);
        }
    }
}
