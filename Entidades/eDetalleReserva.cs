using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eDetalleReserva
    {
        public int IDReserva { get; set; }
        public int IDProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public int subtotal { get; set; }
        public eDetalleReserva()
        {
            eProductos productos = new eProductos();
            eReserva reserva = new eReserva();
            IDReserva = reserva.idReserva;
            IDProducto = productos.idProducto;
        }
        public override string ToString()
        {
            return cantidad + " " + precio + " " + subtotal;
        }
    }


}
