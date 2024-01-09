using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dCliente
    {
        DataBase db = new DataBase();
        public string Insertar(eCliente obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO Cliente" +
                    "(NombreCompleto, DNI, Genero, Distrito, Direccion, Usuario, Contrasena) " +
                    "values('{0}',{1},'{2}','{3}','{4}','{5}','{6}')", 
                    obj.nombrecompleto, obj.DNI, obj.genero, obj.distrito, obj.direccion, obj.Usuario, obj.contrasenia);
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

        public int IniciarSesion(SesionCliente obj)
        {
            try
            {
                var idCliente=0;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID_Cliente from Cliente WHERE Usuario = TRIM('" + obj.Usuario+"') AND Contrasena = '"+obj.Contrasena+ "'", con);

                var idEncontrado = cmd.ExecuteScalar();
                if (idEncontrado != null)
                {
                    idCliente = Convert.ToInt32(idEncontrado.ToString());
                }

                return idCliente;
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

        public string Modificar(eCliente obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update Cliente " +
                    "set Distrito = '{0}', Direccion = '{1}',  Contrasena='{2}', NombreCompleto ='{3}' where ID_Cliente ='{4}'", 
                    obj.distrito, obj.direccion, obj.contrasenia, obj.nombrecompleto, obj.idcliente);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "modifico";
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
        
        public List<eCliente> ListarTodo()
        {
            try
            {
                List<eCliente> lscliente = new List<eCliente>();
                eCliente cliente = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select ID_Cliente, NombreCompleto, DNI, Genero, Distrito, Direccion, Usuario, Contrasenia from Cliente", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new eCliente();
                    cliente.idcliente = (int)reader["ID_Cliente"];
                    cliente.nombrecompleto = (string)reader["NombreCompleto"];
                    cliente.DNI = (int)reader["DNI"];
                    cliente.genero = (string)reader["Genero"];
                    cliente.distrito = (string)reader["Distrito"];
                    cliente.direccion = (string)reader["Direccion"];
                    cliente.Usuario = (string)reader["Usuario"];
                    cliente.contrasenia = (string)reader["Contrasenia"];
                    lscliente.Add(cliente);
                }
                reader.Close();
                return lscliente;
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
