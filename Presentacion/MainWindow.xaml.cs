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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        /////// Empleador //////
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wpfLoginEmpleado loginEmpleado = new wpfLoginEmpleado();
            loginEmpleado.ShowDialog();
        }

        /////// Cliente ///////
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            wpfLoginCliente logincliente = new wpfLoginCliente();
            logincliente.ShowDialog();
        }

        private void btnCliente(object sender, RoutedEventArgs e)
        {
            wpfLoginCliente logincliente = new wpfLoginCliente();
            logincliente.ShowDialog();
        }
    }
}
