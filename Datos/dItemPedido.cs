using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dItemPedido
    {
        DataBase db = new DataBase();
        public string Insertar(eItemPedido obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();           //ID_Producto, 
                string insert = string.Format("insert into ItemPedido(Cantidad, Costo, ID_ReservaFinal) values({1},{2},{3})", obj.Cantidad, obj.Costo, obj.ID_ReservaFinal);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Registrado";
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
        public string Eliminar(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from ItemPedido where ID_ItemPedido={0}", id);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
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

        public List<eItemPedido> ListarTodo()
        {
            try
            {
                List<eItemPedido> lsitempedido = new List<eItemPedido>();
                eItemPedido itempedido = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select ID_ItemPedido, Cantidad, Costo, ID_ReservaFinal from ItemPedido", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itempedido = new eItemPedido();
                    itempedido.ID_ItemPedido = (int)reader["ID_ItemPedido"];
                    itempedido.Cantidad = (int)reader["Cantidad"];
                    itempedido.Costo = (float)reader["Costo"];
                    itempedido.ID_ReservaFinal = (int)reader["ID_ReservaFinal"];
                    lsitempedido.Add(itempedido);
                }
                reader.Close();
                return lsitempedido;
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
