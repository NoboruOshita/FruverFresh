using Negocio;
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
    /// Lógica de interacción para wpfLoginCliente.xaml
    /// </summary>
    public partial class wpfLoginCliente : Window
    {
        nCliente negocioCliente = new nCliente();
        public wpfLoginCliente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wpfLoginNuevoCliente cliente = new wpfLoginNuevoCliente();
            cliente.ShowDialog();
        }

        private void btnsesion_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtUsuario.Text;
            var idCliente = IniciarSesion();
            if (idCliente!=0)
            {
                wpfOpcionesCliente opcionesCliente = new wpfOpcionesCliente(nombre, idCliente);
                opcionesCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado");
            }

        }

        public int IniciarSesion()
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Password;
            var idCliente = negocioCliente.Login(usuario, contrasenia);

            return idCliente;
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
    }
}
