using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Data;

namespace Datos
{
    public class dProducto
    {
        DataBase db = new DataBase();
        public string Insertar(eProductos obj)
        {
            try
            {
//                var idNuevo = 0;
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO Producto(ID_Categoria, Nombre, Descripcion, Precio, Cantidad)" +
                    "values('{0}','{1}','{2}','{3}','{4}');  SELECT @@Identity", 
                    obj.IdCategoria ,obj.nombre, obj.Descripcion, obj.precio, obj.cantidadAlmacenada);
                SqlCommand cmd = new SqlCommand(insert, con);
                //cmd.ExecuteNonQuery();

                var idNuevo = cmd.ExecuteScalar();
                    
                
                Console.WriteLine(idNuevo.ToString());
                
                return "Registro Exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaBd();
            }
        }
                
        public string Modificar(eProductos obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update Producto set Nombre = '{0}', Descripcion = '{1}', Precio = {2}, Cantidad={3} where ID_Producto = {5}", obj.nombre, obj.Descripcion, obj.precio, obj.cantidadAlmacenada, obj.idProducto);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        public string Eliminar(int idProduc)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from Producto where ID_Producto = {0}", idProduc);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Eliminado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaBd();
            }
        }
        public List<eProductos> ListarTodo()
        {
            try
            {
                List<eProductos> lsproducto = new List<eProductos>();
                eProductos productos = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select ID_Producto,ID_Categoria,Nombre,Descripcion,Precio,Cantidad from Producto", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productos = new eProductos();
                    productos.idProducto = (int)reader["ID_Producto"];
                    //productos.IdCategoria = (int)reader["ID_Categoria"];
                    productos.nombre = (string)reader["Nombre"];
                    productos.Descripcion = (string)reader["Descripcion"];
                    productos.precio = (double)reader["Precio"];
                    productos.cantidadAlmacenada = (int)reader["Cantidad"];
                    lsproducto.Add(productos);
                }
                reader.Close();
                return lsproducto;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db.DesconectaBd();
            }
        }
        public List<eProductos> ListarMasVendidos()
        {
            try
            {
                List<eProductos> lsproductos = new List<eProductos>();
                eProductos producto = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT TOP 5 * FROM (select p.ID_Producto, p.Nombre, SUM(i.Cantidad) AS cantidad  from ItemPedido i INNER JOIN Producto p on i.ID_Producto=p.ID_Producto) ORDER BY CANTIDAD DESC", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new eProductos();
                    producto.idProducto = (int)reader["ID_Producto"];
                    producto.nombre = (string)reader["Nombre"];
                    producto.TotalCantidadVendida = (int)reader["cantidad"];
                    lsproductos.Add(producto);
                }
                reader.Close();
                return lsproductos;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db.DesconectaBd();
            }
        }
        public List<eProductos> ListarDistritoMayorDemanda()
        {
            try
            {
                List<eProductos> lsproductos = new List<eProductos>();
                eProductos producto = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT TOP 5 * FROM (select p.ID_Producto, p.Nombre, SUM(i.Cantidad) AS cantidad  from ItemPedido i INNER JOIN Producto p on i.ID_Producto=p.ID_Producto) ORDER BY CANTIDAD DESC", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new eProductos();
                    producto.idProducto = (int)reader["ID_Producto"];
                    producto.nombre = (string)reader["Nombre"];
                    producto.TotalCantidadVendida = (int)reader["cantidad"];
                    lsproductos.Add(producto);
                }
                reader.Close();
                return lsproductos;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db.DesconectaBd();
            }
        }


        public List<EListaCategorias> ListarCategorias()
        {
            try
            {
                List<EListaCategorias> lstcategorias = new List<EListaCategorias>();
                EListaCategorias categoria = null;

                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT * from CategoriaProducto", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categoria = new EListaCategorias();
                    categoria.ID_Categoria = (int)reader["ID_Categoria"];
                    categoria.Nombre = (string)reader["Nombre"];
                    lstcategorias.Add(categoria);
                }
                reader.Close();
                return lstcategorias;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        public List<EListaProductos> ListarProductos(int idCategoria)
        {
            try
            {
                List<EListaProductos> lstProductos = new List<EListaProductos>();
                EListaProductos producto = null;

                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT * from Producto WHERE ID_Categoria = " + idCategoria, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new EListaProductos();
                    producto.ID_Producto = (int)reader["ID_Producto"];
                    producto.ID_Categoria = (int)reader["ID_Categoria"];
                    producto.Nombre = (string)reader["Nombre"];
                    producto.Descripcion = (string)reader["Descripcion"];
                    producto.Precio = Convert.ToDouble(reader["Precio"]);
                    producto.Cantidad = (int)reader["Cantidad"];
                    lstProductos.Add(producto);
                }
                reader.Close();
                return lstProductos;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        public List<EListaProductos> ListarDetalleProducto(int idProducto)
        {
            try
            {
                List<EListaProductos> lstProductos = new List<EListaProductos>();
                EListaProductos producto = null;

                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT * from Producto WHERE ID_Producto = " + idProducto, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new EListaProductos();
                    producto.ID_Producto = (int)reader["ID_Producto"];
                    producto.ID_Categoria = (int)reader["ID_Categoria"];
                    producto.Nombre = (string)reader["Nombre"];
                    producto.Descripcion = (string)reader["Descripcion"];
                    producto.Precio = Convert.ToDouble(reader["Precio"]);
                    producto.Cantidad = (int)reader["Cantidad"];
                    lstProductos.Add(producto);
                }
                reader.Close();
                return lstProductos;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        public string AgregarProducto(int idProducto, int cantidadAgregada)
        {
            try
            {                
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("UPDATE Producto SET Cantidad = Cantidad + {0} WHERE " +
                    "ID_Producto = {1}",
                    cantidadAgregada,idProducto);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                
                return "Registro Exitoso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        
        public DataTable ConsultaProductoMasDemandado()
        {
            SqlConnection con = db.ConectaDb();
            string query = "  SELECT TOP 5 pro.Nombre as Producto, SUM(det.CantidadPedida) as 'Cantidad Demandada' " +
                " FROM Pedido pe  INNER JOIN DetallePedido det ON pe.ID_Pedido = det.ID_Pedido " +
                " INNER JOIN Producto pro ON det.ID_Producto = pro.ID_Producto GROUP BY pro.Nombre ORDER BY 2 Desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        public DataTable ConsultaDistritoMasDemandado()
        {
            SqlConnection con = db.ConectaDb();
            string query = "  SELECT TOP 5 cli.Distrito,	 SUM(det.CantidadPedida) as 'Cantidad Demandada' " +
                "FROM Pedido pe INNER JOIN DetallePedido det ON pe.ID_Pedido = det.ID_Pedido " +
                " INNER JOIN Producto pro ON det.ID_Producto = pro.ID_Producto " +
                " INNER JOIN Cliente cli ON pe.ID_Cliente = cli.ID_Cliente GROUP BY cli.Distrito ORDER BY 2 Desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }
        
        public DataTable ConsultaFechaMasDemandada()
        {
            SqlConnection con = db.ConectaDb();
            string query = "  SELECT TOP 5 CONVERT(VARCHAR, pe.FechaPedido, 103) AS 'Fecha', SUM(MontoTotal) AS 'Monto Total' " +
                " FROM Pedido pe GROUP BY pe.FechaPedido ORDER BY 2 Desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }
    }
}
