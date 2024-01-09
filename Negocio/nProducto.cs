using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class nProducto
    {
        dProducto productosdatos;
        public nProducto()
        {
            productosdatos = new dProducto ();           
        }
                
        public string RegistrarProducto(int IdCategoria,string name, string description, double price, int cantidad)
        {
            eProductos productos = new eProductos()
            {
                IdCategoria = IdCategoria,
                nombre = name,
                Descripcion = description,
                precio = price,
                cantidadAlmacenada = cantidad
            };
            return productosdatos.Insertar(productos);
        }

        public string ModificarProducto(string name, string description, float price, int quantity, int idproduct)
        {
            eProductos productos = new eProductos()
            {
                nombre = name,
                Descripcion = description,
                precio = price,
                cantidadAlmacenada = quantity,
                idProducto = idproduct
            };
            return productosdatos.Modificar(productos);
        }

        public string EliminarProducto(int idproduc)
        {
            return productosdatos.Eliminar(idproduc);
        }

        public List<eProductos> ListarProducto()
        {
            return productosdatos.ListarTodo();
        }
        public List<eProductos> ListarMasVendidos()
        {
            return productosdatos.ListarMasVendidos();
        }

        public List<EListaCategorias> ListarCategorias()
        {
            return productosdatos.ListarCategorias();            
        }

        public List<EListaProductos> ListarProductos(int idCategoria)
        {
            return productosdatos.ListarProductos(idCategoria);
        }

        public List<EListaProductos> ListarDetalleProducto(int idProducto)
        {
            return productosdatos.ListarDetalleProducto(idProducto);
        }

        public string AgregarProducto( int idProducto, int cantidadAgregada)
        {
           
            return productosdatos.AgregarProducto(idProducto, cantidadAgregada);
        }

        public DataTable ConsultarProductosDemandados()
        {
            return productosdatos.ConsultaProductoMasDemandado();
        }

        public DataTable ConsultarDistritosDemandados()
        {
            return productosdatos.ConsultaDistritoMasDemandado();
        }

        public DataTable ConsultarFechaDemandada()
        {
            return productosdatos.ConsultaFechaMasDemandada();
        }
    }
}
