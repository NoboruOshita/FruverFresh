using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class dPedido
    {
        DataBase db = new DataBase();
        
        public int InsertarPedido(ePedido obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO Pedido(ID_Cliente, MontoTotal, FechaPedido) " +
                    "values('{0}','{1}','{2}');  SELECT @@Identity",
                    obj.ID_Cliente, obj.stringMonto, obj.FechaPedido);
                SqlCommand cmd = new SqlCommand(insert, con);
                
                var idNuevo = cmd.ExecuteScalar();
                var idPedido = Convert.ToInt32(idNuevo.ToString());

                return idPedido;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        public int InsertarDetalle(DetallePedido obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO DetallePedido(ID_Pedido, ID_Producto, CantidadPedida)" +
                    "values('{0}','{1}','{2}'); UPDATE Producto SET Cantidad = Cantidad - {2} WHERE ID_Producto = {1}",
                    obj.ID_Pedido, obj.ID_Producto, obj.CantidadPedida);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
            finally
            {
                db.DesconectaBd();
            }
        }

        public List<HistorialPedido> ListarHistorial(int idCliente)
        {
            try
            {
                List<HistorialPedido> lstPedidos = new List<HistorialPedido>();
                HistorialPedido pedido = null;

                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand(
                    "SELECT pro.Nombre, CONVERT(varchar, FechaPedido, 103) AS FechaPedido,    CantidadPedida,   CantidadPedida * Precio as TotalPrecio " +
                    "FROM Pedido pe INNER JOIN DetallePedido det ON pe.ID_Pedido = det.ID_Pedido INNER JOIN Producto pro ON det.ID_Producto = pro.ID_Producto " +
                    "WHERE  pe.ID_Cliente = " + idCliente, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new HistorialPedido();

                    pedido.Nombre = (string)reader["Nombre"];
                    pedido.FechaPedido = (string)reader["FechaPedido"];
                    pedido.CantidadPedida = (int)reader["CantidadPedida"];                    
                    pedido.TotalPrecio = Convert.ToDouble(reader["TotalPrecio"]);
                    
                    lstPedidos.Add(pedido);
                }
                reader.Close();
                return lstPedidos;
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
    
    }
}
