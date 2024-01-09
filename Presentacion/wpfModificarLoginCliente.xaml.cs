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
using Entidades;
namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para wpfModificarLoginCliente.xaml
    /// </summary>
    public partial class wpfModificarLoginCliente : Window
    {
        nCliente cliente = new nCliente();
        int ID_Cliente;
        public wpfModificarLoginCliente(string nombrecompleto, int idCliente)
        {
            InitializeComponent();
            lblNombreCliente.Content = nombrecompleto;
            ID_Cliente = idCliente;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNuevoDistrito.Text != "" && txtNuevoDireccion.Text != "" && txtNuevaContrasenia.Password != "" && txtNombre.Text != "")
                MessageBox.Show(cliente.ModificarCliente(txtNuevoDistrito.Text, txtNuevoDireccion.Text, ID_Cliente , txtNuevaContrasenia.Password.ToString(), txtNombre.Text));
            else
                MessageBox.Show("Rellene el campo de Nombre Completo");
        }
    }
}
