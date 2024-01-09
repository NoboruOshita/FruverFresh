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
    public partial class wpfLoginNuevoEmpleado : Window
    {
        nEmpleado clienten = new nEmpleado();
        public wpfLoginNuevoEmpleado()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "" && txtDNI.Text != "" && (rbHombre.Content.ToString() != "" || rbMujer.Content.ToString() != "") && txtDireccion.Text != "" && txtUsuario1.Text != "" && txtContrasenia.Password != "")
            {
                if (Convert.ToInt32(txtDNI.Text) > 9999999 && Convert.ToInt32(txtDNI.Text) < 100000000)
                {
                    if (rbHombre.IsChecked == true)
                        MessageBox.Show(clienten.RegistrarEmpleado(txtNombre.Text, Convert.ToInt32(txtDNI.Text), rbHombre.Content.ToString(), txtDireccion.Text, txtUsuario1.Text, txtContrasenia.Password));
                    else
                        MessageBox.Show(clienten.RegistrarEmpleado(txtNombre.Text, Convert.ToInt32(txtDNI.Text), rbMujer.Content.ToString(), txtDireccion.Text, txtUsuario1.Text, txtContrasenia.Password));
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

