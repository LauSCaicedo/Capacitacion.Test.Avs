using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capacitacion.Test.Avs.Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int TypeDocument { get; set; }
        public int DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
