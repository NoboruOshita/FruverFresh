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
    /// Lógica de interacción para wpfOpcionesCliente.xaml
    /// </summary>
    public partial class wpfOpcionesCliente : Window
    {
        int ID_Cliente;
        public wpfOpcionesCliente(string nombrecompleto, int idCliente)
        {
            InitializeComponent();
            lblNombre.Content = nombrecompleto.ToUpper();
            ID_Cliente = idCliente;
        }

        private void btnCerrarSes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnProdDisponible_Click(object sender, RoutedEventArgs e)
        {
            wpfProductoDisponible disponible = new wpfProductoDisponible(ID_Cliente);
            disponible.ShowDialog();
        }

        private void btnHistorial_Click(object sender, RoutedEventArgs e)
        {
            wpfProductoElegido productoElegido = new wpfProductoElegido(ID_Cliente);
            productoElegido.ShowDialog();
        }

        private void btnmodificarC_Click(object sender, RoutedEventArgs e)
        {
            wpfModificarLoginCliente wpfModificar = new wpfModificarLoginCliente(lblNombre.Content.ToString(), ID_Cliente);
            wpfModificar.ShowDialog();
        }
    }
}
