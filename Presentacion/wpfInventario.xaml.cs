using Entidades;
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
    /// Lógica de interacción para wpfInventario.xaml
    /// </summary>
    public partial class wpfInventario : Window
    {
        int ID_Categoria;
        int ID_Producto;
        nProducto negocioProducto = new nProducto();
        List<EListaCategorias> listaCategorias = new List<EListaCategorias>();
        List<EListaProductos> listaProductos = new List<EListaProductos>();

        public wpfInventario()
        {
            InitializeComponent();
            ListarCategoria();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region Listar Categorias
        public void ListarCategoria()
        {

            listaCategorias = negocioProducto.ListarCategorias();

            List<EListaCategorias> lista = new List<EListaCategorias>();
            for (int i = 0; i < listaCategorias.Count; i++)
            {
                lista.Add(
                    new EListaCategorias { ID_Categoria = listaCategorias[i].ID_Categoria, Nombre = listaCategorias[i].Nombre });
            }

            comboCategoria.DisplayMemberPath = "Nombre";
            comboCategoria.SelectedValuePath = "ID_Categoria";

            comboCategoria.ItemsSource = lista;

        }
        #endregion


        #region Elegir Producto
        private void comboProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboProducto.SelectedValue != null)
            {
                
                ID_Producto = Convert.ToInt32(comboProducto.SelectedValue.ToString());                
            }
            else
            {
                txtCantidad.Text = "";
            }
        }


        #endregion

        #region Al seleccionar Categoria
        private void comboCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ID_Categoria = Convert.ToInt32(comboCategoria.SelectedValue.ToString());
            LlenarTabla(ID_Categoria);
            ListarProductos(ID_Categoria);
        }
        #endregion

        #region Llenar Tabla
        private void LlenarTabla(int idCategoria)
        {
            listaProductos = negocioProducto.ListarProductos(idCategoria);

            List<EListaProductos> listaTabla = new List<EListaProductos>();

            if (listaProductos.Count>0)
            {
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    if (listaProductos[i].ID_Categoria == idCategoria)
                    {
                        listaTabla.Add(new EListaProductos
                        {
                            ID_Producto = listaProductos[i].ID_Producto,
                            ID_Categoria = listaProductos[i].ID_Categoria,
                            Nombre = listaProductos[i].Nombre,
                            Descripcion = listaProductos[i].Descripcion,
                            Cantidad = listaProductos[i].Cantidad,
                            Precio = listaProductos[i].Precio
                        });
                    }
                }
            }

            gvProductos.Items.Refresh();
            gvProductos.ItemsSource = listaTabla;
            gvProductos.CanUserAddRows = false;
        }
        #endregion

        #region Listar Productos por Categoria
        private void ListarProductos(int idCategoria)
        {
            listaProductos = negocioProducto.ListarProductos(idCategoria);

            List<EListaProductos> listaProductosActuales = new List<EListaProductos>();
            for (int i = 0; i < listaProductos.Count; i++)
            {
                listaProductosActuales.Add(
                    new EListaProductos
                    {
                        ID_Producto = listaProductos[i].ID_Producto,
                        ID_Categoria = listaProductos[i].ID_Categoria,
                        Nombre = listaProductos[i].Nombre,
                        Descripcion = listaProductos[i].Descripcion,
                        Precio = listaProductos[i].Precio,
                        Cantidad = listaProductos[i].Cantidad,
                    });
            }

            comboProducto.DisplayMemberPath = "Nombre";
            comboProducto.SelectedValuePath = "ID_Producto";

            comboProducto.ItemsSource = listaProductosActuales;
        }
        #endregion

        #region Click Agregar Producto
        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            var cantidadAgregada = Convert.ToInt32(txtCantidad.Text);
            MessageBox.Show(negocioProducto.AgregarProducto(ID_Producto,cantidadAgregada));
            LlenarTabla(ID_Categoria);
            //Close();
        }
        #endregion
    }
}
