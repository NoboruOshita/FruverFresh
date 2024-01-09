using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nCliente
    {
        dCliente clientedato;
        public nCliente()
        {
            clientedato = new dCliente();
        }
        
        public string RegistrarCliente(string nombrecompleto, int dni, string Genero, string Distrito, string Direccion, string usuario, string Contrasenio)
        {
            eCliente cliente = new eCliente()
            {
                nombrecompleto = nombrecompleto,
                DNI = dni,
                genero = Genero,
                distrito = Distrito,
                direccion = Direccion,
                Usuario = usuario,
                contrasenia = Contrasenio,
            };
            return clientedato.Insertar(cliente);
        }

        public string ModificarCliente(string Distrito, string Direccion, int idCliente, string Contrasenia, string nombreUsuario)
        {
            eCliente cliente = new eCliente()
            {
                distrito = Distrito,
                direccion = Direccion,
                idcliente = idCliente,
                contrasenia = Contrasenia,
                nombrecompleto = nombreUsuario
            };
            return clientedato.Modificar(cliente);
        }
        
        public List<eCliente> ListarCliente()
        {
            return clientedato.ListarTodo();
        }

        public int Login(string usuario, string Contrasenia)
        {
            SesionCliente objCliente = new SesionCliente()
            {                
                Usuario = usuario,
                Contrasena = Contrasenia
            };

            return clientedato.IniciarSesion(objCliente);
        }
    
    }
}
