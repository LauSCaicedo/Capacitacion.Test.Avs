using Capacitacion.Test.Avs.Business.Entities;
using Capacitacion.Test.Avs.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capacitacion.Test.Avs.Business.Services
{
    public class ServiceUser : IServicesUser
    {
        private IUserData _userData;

        public ServiceUser(IUserData userData)
        {
            _userData = userData;
        }
        public User Create(User user)
        {
            return _userData.Create(user);
        }

        public void Delete(int id)
        {
            _userData.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userData.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userData.GetUserById(id);
        }

        public User Update(User user)
        {
            return _userData.Update(user);
        }
    }
}
