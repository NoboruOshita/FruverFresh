using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCliente
    {
        public int idcliente { get; set; }
        public string nombrecompleto { get; set; }
        public int DNI { get; set; }
        public string genero { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string Usuario { get; set; }
        public string contrasenia { get; set; }
        public override string ToString()
        {
            return nombrecompleto + " " + DNI + " " + genero + " " + distrito + " " + direccion + " " + Usuario + " " + contrasenia;
        }
    }
    public class RegistroCliente
    {

    }
    public class SesionCliente
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
