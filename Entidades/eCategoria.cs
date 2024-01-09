using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCategoria
    {
        public int idCategoria { get; set; }
        public string nombreCategoria{ get; set; }

        public override string ToString()
        {
            return nombreCategoria;
        }
    }
}
