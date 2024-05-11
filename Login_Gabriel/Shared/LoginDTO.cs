using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Gabriel.Shared
{
    public class LoginDTO
    {
        //debe tener 2 propiedades
        //1. Correo
        public string UserName { get; set; }
        //2. Clave
        public string Password { get; set; }
    }
}
