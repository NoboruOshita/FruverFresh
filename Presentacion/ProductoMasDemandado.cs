using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Negocio;
using Entidades;
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentacion
{
    public partial class ProductoMasDemandado : Form
    {
        nProducto negocioProductos = new nProducto();
        public ProductoMasDemandado()
        {
            InitializeComponent();
            chartProductos.Series.Clear();
            //chartProductos.Series["Series1"].LegendText = "Productos Mas Vendidos";
            //List<eProductos> productos = negocioProductos.ListarMasVendidos();
            //foreach (eProductos p in productos)
            //{
            //    chartProductos.Series["Series1"].Points.AddXY(p.nombre, p.TotalCantidadVendida);
            //}
        }  
        
        private void ProductoMasDemandado_Load(object sender, EventArgs e)
        {
            DataTable DT = negocioProductos.ConsultarProductosDemandados();

            chartProductos.Titles.Add("Productos mas Demandados");
            foreach (DataRow row in DT.Rows)
            {
                Series series = chartProductos.Series.Add(row["Producto"].ToString());
                series.Points.Add(Convert.ToInt32(row["Cantidad Demandada"]));

            }

        }


    }
}
