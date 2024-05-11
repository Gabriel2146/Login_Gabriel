using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Gabriel.Shared
{
    public class SesionDTO
    {
        //aqui devolvemos la info del usuario por las credenciales 1 y 2 añadiendo el rol 
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Role {  get; set; }


    }
}
