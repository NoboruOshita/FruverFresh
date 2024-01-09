using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class nEmpleado
    {
        dVendedor empleadodato;
        public nEmpleado()
        {
            empleadodato = new dVendedor();
        }
        public string RegistrarEmpleado(string nombrecompleto, int dni, string Genero, string Direccion, string usuario, string Contrasenio)
        {
            eVendedor vendedor = new eVendedor()
            {
                nombrecompleto = nombrecompleto,
                DNI = dni,
                genero = Genero,
                direccion = Direccion,
                usuario = usuario,
                contrasenia = Contrasenio,
            };
            return empleadodato.Insertar(vendedor);
        }

        public string ModificarEmpleado(int idVendedor,string Direccion, string usuario, string Contrasenia, string nombreUsuario)
        {
            eVendedor vendedor = new eVendedor()
            {
                idvendedor = idVendedor,
                direccion = Direccion,
                usuario = usuario,
                contrasenia = Contrasenia,
                nombrecompleto = nombreUsuario
            };
            return empleadodato.Modificar(vendedor);
        }

        public List<eVendedor> ListarCliente()
        {
            return empleadodato.ListarTodo();
        }
    }
}
