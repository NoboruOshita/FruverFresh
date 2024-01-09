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
    /// Lógica de interacción para wpfModificarLoginEmpleado.xaml
    /// </summary>
    public partial class wpfModificarLoginEmpleado : Window
    {
        nEmpleado empleado = new nEmpleado();
        int ID_Vendedor;
        public wpfModificarLoginEmpleado(string nombrecompleto, int idVendedor)
        {
            InitializeComponent();
            lblNombreCliente.Content = nombrecompleto;
            ID_Vendedor = idVendedor;
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNuevoDireccion.Text != "" && txtNuevoUsuario.Text != "" && txtNuevaContrasenia.Password != "" && txtNombre.Text != "")
                MessageBox.Show(empleado.ModificarEmpleado(ID_Vendedor, txtNuevoDireccion.Text, txtNuevoUsuario.Text, txtNuevaContrasenia.Password.ToString(), txtNombre.Text));
            else
                MessageBox.Show("Rellene el campo de Nombre Completo");
        }
    }
}
