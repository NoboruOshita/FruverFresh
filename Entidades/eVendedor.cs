using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eVendedor
    {
        public int idvendedor { get; set; }
        public string nombrecompleto { get; set; }
        public int DNI { get; set; }
        public string genero { get; set; }
        public string direccion { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public override string ToString()
        {
            return nombrecompleto + " " + DNI + " " + genero + " " + direccion + " " + contrasenia;
        }
    }
    public class SessionVendedor
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
