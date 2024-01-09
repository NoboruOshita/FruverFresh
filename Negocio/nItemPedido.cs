using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class nItemPedido
    {
        dItemPedido itempedidodatos;
        public nItemPedido()
        {
            itempedidodatos = new dItemPedido();
        }
        public string RegistrarItemPedido(int cantidad, float costo, int idreservafinal)
        {
            eItemPedido itempedido = new eItemPedido()
            {
                Cantidad = cantidad,
                Costo = costo,
                ID_ReservaFinal = idreservafinal
            };
            return itempedidodatos.Insertar(itempedido);
        }
    
        public string Eliminaritempedido(int id)
        {
            return itempedidodatos.Eliminar(id);
        }

        public List<eItemPedido> ListarItemPedido()
        {
            return itempedidodatos.ListarTodo();
        }


    }
}
