using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// REFEREMCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Usuarios;
using ElimIzalco.SysRegistroGeneral.EN.Rol;
using System.Data.SqlClient;


namespace ElimIzalco.SysRegistroGeneral.DAL.Usuarios
{
    public class UsuarioDAL
    {
        #region ObtenerUsuarios
        // Metodo para Obtener todos los Usuarios Existentes
        public List<UsuarioEN> ObtenerUsuarios()
        {
            // Creamos una instancia de UsuarioEn para acceder a los atributos
            List<UsuarioEN> listaUsuarios = new List<UsuarioEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Users.Id, Users.Nombre, Users.Apellido, Users.Dui, Users.Correo, Users.Passw, Rol.Id, Rol.Nombre " +
                "FROM Users JOIN Rol ON Users.IdRol = Rol.Id ;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de UsuarioEN para acceder a los atributos
                UsuarioEN ObjUsuarios = new UsuarioEN();

                // Asignacion de Columnas
                ObjUsuarios.Id = reader.GetInt32(0);
                ObjUsuarios.Nombre = reader.GetString(1);
                ObjUsuarios.Apellido = reader.GetString(2);
                ObjUsuarios.Dui = reader.GetString(3);
                ObjUsuarios.Correo = reader.GetString(4);
                ObjUsuarios.Password = reader.GetString(5);
                ObjUsuarios.Rol = new RolEN
                {
                    Id = reader.GetInt32(6),
                    Nombre = reader.GetString(7),
                };
                listaUsuarios.Add(ObjUsuarios);
            }
            // Retornamos la Lista de Usuarios
            return listaUsuarios;
        }
        #endregion

        #region ObtenerUsuariosPorId
        // Metodo para Obtener un Usuario En base a su Id
        public UsuarioEN ObtenerUsuarioPorId(int? pId)
        {
            // Creamos una instancia de UsuarioEN para acceder a los atributos
            UsuarioEN ObjUsuarios = new UsuarioEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Users.Id, Users.Nombre, Users.Apellido, Users.Dui, Users.Correo, Users.Passw, Rol.Id, Rol.Nombre  " +
                "FROM Users JOIN Rol ON Users.IdRol = Rol.Id WHERE Users.Id = @Id";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de Columnas
                ObjUsuarios.Id = reader.GetInt32(0);
                ObjUsuarios.Nombre = reader.GetString(1);
                ObjUsuarios.Apellido = reader.GetString(2);
                ObjUsuarios.Dui = reader.GetString(3);
                ObjUsuarios.Correo = reader.GetString(4);
                ObjUsuarios.Password = reader.GetString(5);
                ObjUsuarios.Rol = new RolEN
                {
                    Id = reader.GetInt32(6),
                    Nombre = reader.GetString(7),
                };
            }
            return ObjUsuarios;
        }
        #endregion

        #region ObtenerUsuarioLike
        // Metodo para Obtener Usuarios que Coincida o se Parezca al parametro Nombre
        public List<UsuarioEN> ObtenerUsuarioLike(string pNombre)
        {
            // Creamos una instancia de UsuarioEN para acceder a los atributos
            List<UsuarioEN> listaUsuario = new List<UsuarioEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Users.Id, Users.Nombre, Users.Apellido, Users.Dui, Users.Correo, Users.Passw, Rol.Id, Rol.Nombre " +
                "FROM Users JOIN Rol ON Users.IdRol = Rol.Id WHERE Users.Nombre = @Nombres";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Nombre", "%" + pNombre + "%"); // Se Agregan caracteres comodín para buscar coincidencias parciales

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una instancia de UsuarioEN para acceder a los atributos
                UsuarioEN ObjUsuarios = new UsuarioEN();

                // Asignacion de Columnas
                ObjUsuarios.Id = reader.GetInt32(0);
                ObjUsuarios.Nombre = reader.GetString(1);
                ObjUsuarios.Apellido = reader.GetString(2);
                ObjUsuarios.Dui = reader.GetString(3);
                ObjUsuarios.Correo = reader.GetString(4);
                ObjUsuarios.Password = reader.GetString(5);
                ObjUsuarios.Rol = new RolEN
                {
                    Id = reader.GetInt32(6),
                    Nombre = reader.GetString(7),
                };
                listaUsuario.Add(ObjUsuarios);
            }
            // Retornamos la Lista de Usuarios
            return listaUsuario;
        }
        #endregion
    }
}
