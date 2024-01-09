using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eReserva
    {
        public int idReserva { get; set; }
        public int IdCliente { get; set; }
        public double Monto { get; set; }
        public int Fecha { get; set; }
        public eReserva()
        {
            eCliente cliente = new eCliente();
            IdCliente=cliente.idcliente;
        }
        public override string ToString()
        {
            return Monto + " " + Fecha;
        }
    }
}
