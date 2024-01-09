using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ePedido
    {
        public int ID_Pedido { get; set; }
        public int ID_Cliente { get; set; }
        public double MontoTotal { get; set; }
        public string FechaPedido { get; set; }
        public string stringMonto { get; set; }
    }
    public class DetallePedido
    {
        public int ID_DetallePedido { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
        public int CantidadPedida { get; set; }
    }
    public class HistorialPedido
    {
        public string Nombre { get; set; }
        public string FechaPedido { get; set; }
        public int CantidadPedida { get; set; }
        public double TotalPrecio { get; set; }
    }
}
