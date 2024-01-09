using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dVendedor
    {
        DataBase db = new DataBase();
        public string Insertar(eVendedor obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format(
                    "insert into Vendedor(NombreCompleto, DNI, Genero, Direccion, Usuario, Contrasena)" +
                    " values('{0}',{1},'{2}','{3}','{4}','{5}')", 
                    obj.nombrecompleto, obj.DNI, obj.genero, obj.direccion, obj.usuario, obj.contrasenia);
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

        public string Modificar(eVendedor obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update Vendedor " +
                    "set Direccion = '{0}', Usuario = '{1}', Contrasena = '{2}', NombreCompleto='{3}' where ID_Vendedor ='{4}'", 
                    obj.direccion, obj.usuario, obj.contrasenia, obj.nombrecompleto, obj.idvendedor);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                
                return "Modificación Exitosa";
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

        public List<eVendedor> ListarTodo()
        {
            try
            {
                List<eVendedor> lsvendedor = new List<eVendedor>();
                eVendedor vendedor = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select ID_Empleado, NombreCompleto, DNI, Genero, Direccion, Usuario, Contrasenia from Empleado", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vendedor = new eVendedor();
                    vendedor.idvendedor = (int)reader["ID_Vendedor"];
                    vendedor.nombrecompleto = (string)reader["NombreCompleto"];
                    vendedor.DNI = (int)reader["DNI"];
                    vendedor.genero = (string)reader["Genero"];
                    vendedor.direccion = (string)reader["Direccion"];
                    vendedor.usuario = (string)reader["Usuario"];
                    vendedor.contrasenia = (string)reader["Contrasenia"];
                    lsvendedor.Add(vendedor);
                }
                reader.Close();
                return lsvendedor;
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

        public int IniciarSesion(SessionVendedor obj)
        {
            try
            {
                var idVendedor = 0;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID_Vendedor from Vendedor WHERE Usuario = TRIM('" + obj.Usuario + "') AND Contrasena = '" + obj.Contrasena + "'", con);

                var idEncontrado = cmd.ExecuteScalar();
                if (idEncontrado!=null)
                {
                    idVendedor = Convert.ToInt32(idEncontrado.ToString());
                }                

                return idVendedor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
            finally
            {
                db.DesconectaBd();
            }
        }


    }
}