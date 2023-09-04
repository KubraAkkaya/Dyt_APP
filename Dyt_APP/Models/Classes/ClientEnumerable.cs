using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dyt_APP.Models.Classes
{
    public class ClientEnumerable
    {
        public IEnumerable<Client> client { get; set; }
        public IEnumerable<BMI> bmi{ get; set; }
        public IEnumerable<Admin> admin{ get; set; }

    }
}