using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class wpfLoginNuevoCliente : Window
    {
        nCliente clienten = new nCliente();
        public wpfLoginNuevoCliente()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "" && txtDNI.Text != "" && (rbHombre.IsChecked==true || rbMujer.IsChecked==true) 
                && txtDistrito.Text != "" && txtDireccion.Text != "" && txtUsuario.Text != "" && txtContrasenia.Password != "")
            {
                if (Convert.ToInt32(txtDNI.Text) > 9999999 && Convert.ToInt32(txtDNI.Text) < 100000000)
                {
                    if (rbHombre.IsChecked == true)
                    {
                        MessageBox.Show(clienten.RegistrarCliente(txtNombre.Text, Convert.ToInt32(txtDNI.Text), rbHombre.Content.ToString(), txtDistrito.Text, txtDireccion.Text, txtUsuario.Text, txtContrasenia.Password));
                    }
                    else
                    {
                        MessageBox.Show(clienten.RegistrarCliente(txtNombre.Text, Convert.ToInt32(txtDNI.Text), rbMujer.Content.ToString(), txtDistrito.Text, txtDireccion.Text, txtUsuario.Text, txtContrasenia.Password));
                    }                        
                    Close();
                }
                else
                    MessageBox.Show("El DNI que ingreso no cuenta con 8 cifras");
            }
            else
                MessageBox.Show("El formulario esta incompleto");
        }
    }
}
