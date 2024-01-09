using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nVendedor
    {
        dVendedor vendedorDato;
        public nVendedor()
        {
            vendedorDato = new dVendedor();
        }

        public int Login(string usuario, string Contrasenia)
        {
            SessionVendedor objVendedor = new SessionVendedor()
            {
                Usuario = usuario,
                Contrasena = Contrasenia
            };

            return vendedorDato.IniciarSesion(objVendedor);
        }

    }
}
