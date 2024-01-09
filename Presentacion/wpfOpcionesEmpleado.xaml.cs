using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para wpfOpcionesEmpleado.xaml
    /// </summary>
    public partial class wpfOpcionesEmpleado : Window
    {
        int ID_Cliente;
        public wpfOpcionesEmpleado(string nombrecompleto, int idCliente)
        {
            InitializeComponent();
            lblNombre.Content = nombrecompleto.ToUpper();
            ID_Cliente = idCliente;
        }

        private void btnCerrarSes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnDistritomayordem_Click(object sender, RoutedEventArgs e)
        {
            DistritoMayorDemanda distritoMayorDemanda = new DistritoMayorDemanda();
            distritoMayorDemanda.ShowDialog();
        }
        private void btnClienteMasCompra_Click(object sender, RoutedEventArgs e)
        {
            FechaMasDemandada fechaMasDemandada = new FechaMasDemandada();
            fechaMasDemandada.ShowDialog();

        }

        private void btnInventario_Click(object sender, RoutedEventArgs e)
        {
            wpfInventario inventario = new wpfInventario();
            inventario.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductoMasDemandado productoMasDemanda = new ProductoMasDemandado();
            productoMasDemanda.ShowDialog();
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {


            wpfModificarLoginEmpleado wpfModificar = new wpfModificarLoginEmpleado(lblNombre.Content.ToString(), ID_Cliente);
            wpfModificar.ShowDialog();
        }
    }
}
