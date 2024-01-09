using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eProductos
    {
        public int idProducto { get; set; }
        public int IdCategoria { get; set; }
        public string nombre { get; set; }
        public string Descripcion { get; set; }
        public double precio { get; set; }
        public long cantidadAlmacenada { get; set; }
        public int TotalCantidadVendida { get; set; }
        public string categoria { get; set; } 

        public int IdVendedor { get; set; }
        public eProductos()
        {
            eCategoria categoria = new eCategoria();
            IdCategoria = categoria.idCategoria;

            eVendedor vendedor = new eVendedor();
            IdVendedor = vendedor.idvendedor;
        }
        public override string ToString()
        {
            return nombre + " " + categoria + " " + precio + " " + cantidadAlmacenada;
        }
    }

    public class EListaCategorias
    {
        public int ID_Categoria { get; set; }
        public string Nombre { get; set; }
    }

    public class EListaProductos
    {
        public int ID_Producto { get; set; }
        public int ID_Categoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    public class EListaCarrito
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

    }
    
}
