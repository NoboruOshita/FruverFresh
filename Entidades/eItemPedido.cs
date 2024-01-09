using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eItemPedido
    {
        public int ID_ItemPedido { get; set; }

        //public eProducto ID_Producto { get; set; }
        public int Cantidad { get; set; }
        public float Costo { get; set; }
        public int ID_ReservaFinal { get; set; }
        public override string ToString()
        {
            return Cantidad + " " + Costo;
        }
    }
}
