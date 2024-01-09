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
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para wpfLoginEmpleado.xaml
    /// </summary>
    public partial class wpfLoginEmpleado : Window
    {
        nVendedor negocioVendedor = new nVendedor();        
        public wpfLoginEmpleado()
        {
            InitializeComponent();
        }

        private void btnsesion_Click(object sender, RoutedEventArgs e)
        {

            string nombre = txtUsuario2.Text;
            var idVendedor = IniciarSesion();
            if (idVendedor != 0)
            {
                wpfOpcionesEmpleado opcionesEmpleado = new wpfOpcionesEmpleado(nombre, idVendedor);
                opcionesEmpleado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wpfLoginNuevoEmpleado empleado = new wpfLoginNuevoEmpleado();
            empleado.ShowDialog();
        }

        public int IniciarSesion()
        {
            string usuario = txtUsuario2.Text;
            string contrasenia = txtContrasenia2.Password;
            var idVendedor = negocioVendedor.Login(usuario, contrasenia);

            return idVendedor;
        }
    }
}
