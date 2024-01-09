using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
   public class nCategoria
    {
        dCategoria categotiaDato;
        public nCategoria()
        {
            categotiaDato = new dCategoria();
        }
        public string InsertarCategoria(string tipo)
        {
            eCategoria categoria = new eCategoria()
            {
                nombreCategoria = tipo
            };
            return categotiaDato.InsertarCategoria(categoria);
        }

        public string ModificarCategoria(string tipo, int idcate)
        {
            eCategoria categoria = new eCategoria()
            {
                nombreCategoria=tipo,
                idCategoria=idcate
            };
            return categotiaDato.ModificarCategoria(categoria);
        }
        public string EliminarCategoria(int idcategoria)
        {
            return categotiaDato.Eliminar(idcategoria);
        }
        public List<eCategoria> ListarCategoria()
        {
            return categotiaDato.ListarTodoCategoria();
        }
    }
}
