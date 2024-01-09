using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// <summary>
    /// Lógica de interacción para wpfProductoDisponible.xaml
    /// </summary>
    public partial class wpfProductoDisponible : Window
    {
        nProducto nprodu = new nProducto();
        nPedido negocioPedido = new nPedido();
        nCategoria nCategoria = new nCategoria();
        CultureInfo culture;

        eProductos productosseleccionado = null;
        List<EListaCategorias> listaCategorias = new List<EListaCategorias>();
        List<EListaProductos> listaProductos = new List<EListaProductos>();
        List<EListaCarrito> listaCarrito = new List<EListaCarrito>();

        public int ID_Cliente;
        
        int idProduct;

        double precioCompraTotal = 0;

        #region Inicializar
        public wpfProductoDisponible(int IdCliente)
        {
            InitializeComponent();
            ListarCategoria();
            ID_Cliente = IdCliente;
        }
        #endregion


        #region Listar Categorias
        public void ListarCategoria()
        {

            listaCategorias = nprodu.ListarCategorias();

            List<EListaCategorias> lista = new List<EListaCategorias>();
            for (int i = 0; i < listaCategorias.Count; i++)
            {
                lista.Add(
                    new EListaCategorias { ID_Categoria = listaCategorias[i].ID_Categoria, Nombre = listaCategorias[i].Nombre });
            }

            cmb_producto.DisplayMemberPath = "Nombre";
            cmb_producto.SelectedValuePath = "ID_Categoria";

            cmb_producto.ItemsSource = lista;

        }
        #endregion


        #region Listar Productos
        public void ListarProducto(int idCategoria)
        {

            listaProductos = nprodu.ListarProductos(idCategoria);

            List<EListaProductos> listaProductosActuales = new List<EListaProductos>();
            for (int i = 0; i < listaProductos.Count; i++)
            {
                listaProductosActuales.Add(
                    new EListaProductos { 
                        ID_Producto = listaProductos[i].ID_Producto,                     
                        ID_Categoria = listaProductos[i].ID_Categoria,
                        Nombre = listaProductos[i].Nombre,
                        Descripcion = listaProductos[i].Descripcion,
                        Precio = listaProductos[i].Precio,
                        Cantidad = listaProductos[i].Cantidad,
                    });
            }

            cmb_nombre.DisplayMemberPath = "Nombre";
            cmb_nombre.SelectedValuePath = "ID_Producto";

            cmb_nombre.ItemsSource = listaProductosActuales;
                        
        }
        #endregion


        #region Listar Detalle de Producto Seleccionado
        public void DetallarProducto(int idProducto)
        {

            //listaProductos = nprodu.ListarProductos(idProduct);

            List<EListaProductos> lista = new List<EListaProductos>();
            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos[i].ID_Producto==idProducto)
                {
                    nCantidadDisponible.Text=Convert.ToString(listaProductos[i].Cantidad);
                    nPrecioUnitario.Text= Convert.ToString(listaProductos[i].Precio);
                    lbl_descripcion.Content = listaProductos[i].Descripcion;
                }
            }
            LimpiarCampos();
        }
        #endregion


        #region Limpiar Cantidad y Precio Total
        public void LimpiarCampos()
        {
            txt_cantidad.Text = "0";
            //nPrecioTotal.Text = "0";
            lblprecio.Content = "0";
        }
        #endregion


        #region Calcular Precio * Cantidad
        private void CalcularPrecio(object sender, TextChangedEventArgs e)
        {
            
            if (txt_cantidad.Text!=string.Empty && nPrecioUnitario.Text!=string.Empty)
            {
                var cantidadPedida = Convert.ToDouble(txt_cantidad.Text);
                var precioUnit = Convert.ToDouble(nPrecioUnitario.Text);
                lblprecio.Content = cantidadPedida * precioUnit;
            }            
        }
        #endregion


        #region Validacion Cantidades
        public bool ValidarCantidades()
        {
            var cantidadDisponible = Convert.ToDouble(nCantidadDisponible.Text);
            var cantidadPedida = Convert.ToDouble(txt_cantidad.Text);

            if (cantidadDisponible < cantidadPedida)
            {
                MessageBox.Show("La Cantidad Pedida no puede ser mayor a la Cantidad Disponible", "Advertencia",default,MessageBoxImage.Exclamation);
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion


        #region Suma Total
        public void sumaTotal()
        {
            if (listaCarrito.Count>0)
            {
                for (int i = 0; i < listaCarrito.Count; i++)
                {
                    precioCompraTotal = precioCompraTotal + listaCarrito[i].Precio;
                }

                nPrecioTotal.Text = Convert.ToString(precioCompraTotal);
            }            
        }
        #endregion


        #region Llenar Grilla
        public void mostrarproducto(int idProducto)
        {

            var cantidadPedida = Convert.ToInt32(txt_cantidad.Text);
            if (listaProductos.Count>0)
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    if (listaProductos[i].ID_Producto == idProducto)
                    {
                        listaCarrito.Add(new EListaCarrito
                        {
                            ID_Producto = listaProductos[i].ID_Producto,
                            Nombre = listaProductos[i].Nombre,
                            Descripcion = listaProductos[i].Descripcion,
                            Cantidad = cantidadPedida,
                            Precio = listaProductos[i].Precio * cantidadPedida
                        });
                    }
                }

                dgproductos.Items.Refresh();
                dgproductos.ItemsSource = listaCarrito;
                dgproductos.CanUserAddRows = false;
            }
           

        }
        #endregion


        #region Cerrar Ventana
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion


        #region Agregar al carrito
        private void btn_carrito_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCantidades() == true)
            {                
                var idProducto = Convert.ToInt32(cmb_nombre.SelectedValue.ToString());                
                mostrarproducto(idProducto);
                
                sumaTotal();
            }
            
        }
        #endregion


        #region Reservar productos
        private void btn_reserva_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCantidades() == true)
            {
                //Variables
                var IdCategoria = Convert.ToInt32(cmb_producto.SelectedValue.ToString());
                string nombreProducto = cmb_nombre.Text;
                string descripcion = lbl_descripcion.Content.ToString();
                var precio = Convert.ToDouble(lblprecio.Content);
                var cantidadPedido = Convert.ToInt32(txt_cantidad.Text);
                            
                var montoTotal = Convert.ToDouble(nPrecioTotal.Text);
                var fechaActual = DateTime.Now.ToString();

                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                string stringMonto = montoTotal.ToString(nfi);

                int nuevoPedido = negocioPedido.RegistrarPedido(ID_Cliente, stringMonto, fechaActual);
                if (listaCarrito.Count > 0)
                {
                    for (int i = 0; i < listaCarrito.Count; i++)
                    {
                        negocioPedido.RegistrarDetalle(nuevoPedido, listaCarrito[i].ID_Producto,listaCarrito[i].Cantidad);
                        System.Threading.Thread.Sleep(2000);
                    }

                }

                MessageBox.Show("Reserva Exitosa");

                Close();
            }

        }
        #endregion
              

        #region Eliminar Fila
        private void eliminarFila()
        {
            if (dgproductos.SelectedItems.Count > 0)
            {
                List<EListaCarrito> miLista = (List<EListaCarrito>)dgproductos.ItemsSource;

                if (miLista != null)
                {
                    for (int i = 0; i < dgproductos.SelectedItems.Count; i++)
                    {
                        int indice = dgproductos.Items.IndexOf(dgproductos.SelectedItems[i]);
                        miLista.RemoveAt(indice);
                    }

                    dgproductos.ItemsSource = null;
                    dgproductos.ItemsSource = miLista;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos una fila.");
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarFila();
        }
        #endregion


        #region Listar Productos Por Categoria
        private void cmb_producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idCategoria = Convert.ToInt32(cmb_producto.SelectedValue.ToString());
            ListarProducto(idCategoria);
        }      
        #endregion


        #region Listar Detalles de Productos
        private void cmb_nombre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(cmb_nombre.SelectedValue);
            Console.WriteLine(cmb_nombre);
            if (cmb_nombre.SelectedValue!=null)
            {
                var idProducto = Convert.ToInt32(cmb_nombre.SelectedValue.ToString());
                DetallarProducto(idProducto);
            }
            else
            {
                nCantidadDisponible.Text = "";
                nPrecioUnitario.Text = "";
                LimpiarCampos();
                Console.WriteLine(cmb_nombre);
            }
            
        }
        #endregion


        #region Validacion Solo Numeros

        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

       
    }
}
