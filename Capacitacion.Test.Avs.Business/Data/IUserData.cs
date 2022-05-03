using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capacitacion.Test.Avs.Business.Entities;

namespace Capacitacion.Test.Avs.Business.Data
{
    public interface IUserData
    {
        User Create(User user);
        User Update(User user);
        void Delete(int id);
        User GetUserById(int id);
        IEnumerable<User> GetAll();
    }
}
