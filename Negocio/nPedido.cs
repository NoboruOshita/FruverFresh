using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class nPedido
    {
        dPedido datosPedido;
        
        public nPedido()
        {
            datosPedido = new dPedido();            
        }

        public int RegistrarPedido(int IdCliente, string stringMonto, string fechaPedido)
        {
            ePedido objPedido = new ePedido()
            {
                ID_Cliente = IdCliente,
                stringMonto = stringMonto,
                FechaPedido = fechaPedido,
               
            };
            return datosPedido.InsertarPedido(objPedido);
        }

        public int RegistrarDetalle(int IdPedido, int IdProducto, int Cantidad)
        {
            DetallePedido objDetalle = new DetallePedido()
            {
                ID_Pedido = IdPedido,
                ID_Producto = IdProducto,
                CantidadPedida = Cantidad,

            };
            return datosPedido.InsertarDetalle(objDetalle);
        }

        public List<HistorialPedido> ListarHistorial(int idCliente)
        {
            return datosPedido.ListarHistorial(idCliente);
        }

    }
}
