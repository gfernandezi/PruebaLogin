using PruebaLogin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PruebaLogin.DAO
{
    public class UsuarioDAO
    {
        string conectionString = ConfigurationManager.ConnectionStrings["DBCuenta"].ConnectionString;
        UsuarioDTO usuarioDTO;
        List<UsuarioDTO> usuariosDTO;
        public List<UsuarioDTO> GetAll()
        {
            usuariosDTO = new List<UsuarioDTO>();
            using (var connection = new SqlConnection(conectionString))
            {
                connection.Open();
                string sql = "Select ID, Usuario, Password, CONVERT(VARCHAR(100),DECRYPTBYPASSPHRASE('RS',PasswordHash)) as PasswordHash  from Usuario";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuarioDTO = new UsuarioDTO();
                            usuarioDTO.ID = Convert.ToInt32(reader["ID"]);
                            usuarioDTO.Usuario = reader["Usuario"].ToString();
                            usuarioDTO.Password = reader["Password"].ToString();
                            usuarioDTO.PasswordHash = reader["PasswordHash"].ToString();
                            usuariosDTO.Add(usuarioDTO);
                        }
                        reader.Close();
                    }
                }
                //NOTA: El USING se encarga se cerrar automaticamente la conexión.
            }
            return usuariosDTO;
        }

        public UsuarioDTO Get(int? ID)
        {
            usuarioDTO = new UsuarioDTO();
            using (var connection = new SqlConnection(conectionString))
            {
                connection.Open();
                string sql = "Select ID, Usuario, Password, CONVERT(VARCHAR(100),DECRYPTBYPASSPHRASE('RS',PasswordHash)) as PasswordHash  from Usuario WHERE ID=@ID";
                SqlCommand oCmd = new SqlCommand(sql, connection);
                oCmd.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = oCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarioDTO.ID = Convert.ToInt32(ID);
                        usuarioDTO.Usuario = reader["Usuario"].ToString();
                        usuarioDTO.Password = reader["Password"].ToString();
                        usuarioDTO.PasswordHash = reader["PasswordHash"].ToString();
                    }                   
                }
                return usuarioDTO;
            }
        }

        public void Create(UsuarioDTO usuarioDTO) {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                
                string sql = "Insert into Usuario(Usuario, Password, [PasswordHash]) values (@Usuario, @Password, EncryptByPassPhrase('RS', @PasswordHash))";
                SqlCommand oCmd = new SqlCommand(sql, connection);
                oCmd.Parameters.AddWithValue("@Usuario", usuarioDTO.Usuario);
                oCmd.Parameters.AddWithValue("@Password", usuarioDTO.Password);
                oCmd.Parameters.AddWithValue("@PasswordHash", usuarioDTO.PasswordHash);
                connection.Open();
                oCmd.ExecuteNonQuery();              
            }
        }

        public UsuarioDTO Edit(int ID)
        {

            UsuarioDTO usuarioDTO = new UsuarioDTO();
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                string sql = "Select ID, Usuario, Password, CONVERT(VARCHAR(100),DECRYPTBYPASSPHRASE('RS',PasswordHash)) as PasswordHash  from Usuario where ID = @ID";
                SqlCommand oCmd = new SqlCommand(sql, connection);
                oCmd.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = oCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarioDTO.ID = Convert.ToInt32(reader["ID"]);
                        usuarioDTO.Usuario = reader["Usuario"].ToString();
                        usuarioDTO.PasswordHash = reader["PasswordHash"].ToString();
                        usuarioDTO.Password = reader["Password"].ToString();
                    }
                    reader.Close();                 
                }
                return usuarioDTO;

            }
        }

        public void Edit(int? ID, UsuarioDTO usuarioDTO) {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                string sql = "Update Usuario set Usuario = @Usuario, Password = @Password, [PasswordHash] = EncryptByPassPhrase('RS', @PasswordHash) where ID = @ID ";
                SqlCommand oCmd = new SqlCommand(sql, connection);
                oCmd.Parameters.AddWithValue("@ID", ID);
                oCmd.Parameters.AddWithValue("@Usuario", usuarioDTO.Usuario);
                oCmd.Parameters.AddWithValue("@Password", usuarioDTO.Password);
                oCmd.Parameters.AddWithValue("@PasswordHash", usuarioDTO.PasswordHash);
                oCmd.ExecuteNonQuery();                
            }
        }

        public UsuarioDTO Delete(int ID)
        {
            usuarioDTO = new UsuarioDTO();
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                string sql = "Select ID, Usuario, Password, CONVERT(VARCHAR(100),DECRYPTBYPASSPHRASE('RS',PasswordHash)) as PasswordHash  from Usuario WHERE ID=@ID";
                SqlCommand oCmd = new SqlCommand(sql, connection);
                oCmd.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = oCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarioDTO.ID = Convert.ToInt32(reader["ID"]);
                        usuarioDTO.Usuario = reader["Usuario"].ToString();
                        usuarioDTO.Password = reader["Password"].ToString();
                        usuarioDTO.PasswordHash = reader["PasswordHash"].ToString();
                    }
                    reader.Close();                                
                }
            }
            return usuarioDTO;
        }

        public void Delete(int? ID) {
            usuarioDTO = new UsuarioDTO();
          
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                string sql = "Delete from Usuario where ID=@ID";
                SqlCommand oCmd = new SqlCommand(sql, connection);
                oCmd.Parameters.AddWithValue("@ID", ID);
                oCmd.ExecuteNonQuery();                
            }
        }
    }
}