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
using Entidades;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para wpfProductoElegido.xaml
    /// </summary>
    public partial class wpfProductoElegido : Window
    {        
        nPedido negocioPedido = new nPedido();
                
        int ID_Cliente;
        public wpfProductoElegido(int IdCliente)
        {
            InitializeComponent();
            ID_Cliente = IdCliente;
            MostrarHistorial();
        }
        private void MostrarHistorial()
        {
            
            dgHistorial.ItemsSource = negocioPedido.ListarHistorial(ID_Cliente);
            dgHistorial.CanUserAddRows = false;
            dgHistorial.CanUserReorderColumns = false;
            dgHistorial.CanUserResizeColumns = false;
            //dgHistorial.Column
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
