using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{
    public class dCategoria
    {
        DataBase db = new DataBase();
        public string InsertarCategoria(eCategoria obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert into CategoriaProducto(Nombre) values('{0}')", obj.nombreCategoria);
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
        public string ModificarCategoria(eCategoria obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update CategoriaProducto set Nombre = '{0}' where ID_Categoria={0}", obj.nombreCategoria,obj.idCategoria);
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
                string delete = string.Format("delete from CategoriaProducto where ID_Categoria = {0}", idProduc);
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


        public List<eCategoria> ListarTodoCategoria()
        {
            try
            {
                List<eCategoria> lscategoria = new List<eCategoria>();
                eCategoria categoria = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select Nombre from CategoriaProducto", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categoria = new eCategoria();
                    categoria.nombreCategoria = (string)reader["Nombre"];
                    lscategoria.Add(categoria);
                }
                reader.Close();
                return lscategoria;
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
