using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using crud_ordinario.Models;

namespace crud_ordinario.Models
{
    public class usuariosDAL
    {
        string connectionString = @"Data Source=den1.mssql7.gear.host;Initial Catalog=crudordinario;User Id=crudordinario;
Password=Db8gM0t!~PdG;";

        public IEnumerable<usuarios> ListarUsuarios()
        {
            List<usuarios> ListaUsuarios = new List<usuarios>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    usuarios oUsuarios = new usuarios();
                    oUsuarios.id = Convert.ToInt32(rdr["id"]);
                    oUsuarios.nombre = rdr["nombre"].ToString();
                    oUsuarios.email = rdr["email"].ToString();
                    oUsuarios.telefono = rdr["telefono"].ToString();
                    oUsuarios.edociv = rdr["edociv"].ToString();
                    ListaUsuarios.Add(oUsuarios);
                }
                con.Close();
            }
            return ListaUsuarios;
        }

        public void Agregarusuario(usuarios oUsuarios)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[usuarios]([nombre], [email], [telefono], [edociv], [hijos], [libros], [musica], [deportes], [otros]) VALUES(@nombre, @email, @telefono, @edociv, @hijos, @libros, @musica, @deportes, @otros)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", oUsuarios.nombre);
                cmd.Parameters.AddWithValue("@email", oUsuarios.email);
                cmd.Parameters.AddWithValue("@telefono", oUsuarios.telefono);
                cmd.Parameters.AddWithValue("@edociv", oUsuarios.edociv);
                cmd.Parameters.AddWithValue("@hijos", oUsuarios.hijos);
                cmd.Parameters.AddWithValue("@libros", oUsuarios.libros);
                cmd.Parameters.AddWithValue("@musica", oUsuarios.musica);
                cmd.Parameters.AddWithValue("@deportes", oUsuarios.deportes);
                cmd.Parameters.AddWithValue("@otros", oUsuarios.otros);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void ModificarUsuario(usuarios oUsuarios)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[usuarios] SET [nombre] = @nombre, [email] = @email, [telefono] = @telefono, [edociv] = @edociv, [hijos] = @hjios, [libros] = @libros, [musica] = @musica, [deportes] = @deportes, [otros] = @otros WHERE ID = @id", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", oUsuarios.id);
                cmd.Parameters.AddWithValue("@nombre", oUsuarios.nombre);
                cmd.Parameters.AddWithValue("@email", oUsuarios.email);
                cmd.Parameters.AddWithValue("@telefono", oUsuarios.telefono);
                cmd.Parameters.AddWithValue("@edociv", oUsuarios.edociv);
                cmd.Parameters.AddWithValue("@hjios", oUsuarios.hijos);
                cmd.Parameters.AddWithValue("@libros", oUsuarios.libros);
                cmd.Parameters.AddWithValue("@musica", oUsuarios.musica);
                cmd.Parameters.AddWithValue("@deportes", oUsuarios.deportes);
                cmd.Parameters.AddWithValue("@otros", oUsuarios.otros);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public usuarios ObtenerDatosUsuario(int? id)
        {
            usuarios oUsuarios = new usuarios();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM usuarios WHERE id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    oUsuarios.id = Convert.ToInt32(rdr["id"]);
                    oUsuarios.nombre = rdr["nombre"].ToString();
                    oUsuarios.email = rdr["email"].ToString();
                    oUsuarios.telefono = rdr["telefono"].ToString();
                    oUsuarios.edociv = rdr["edociv"].ToString();
                    oUsuarios.hijos = rdr["hijos"].ToString();
                    oUsuarios.libros = rdr["libros"].ToString();
                    oUsuarios.musica = rdr["musica"].ToString();
                    oUsuarios.deportes = rdr["deportes"].ToString();
                    oUsuarios.otros = rdr["otros"].ToString();
                }
            }
            return oUsuarios;
        }

        public void BorrarUsuario(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM usuarios WHERE id = @id", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
