using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Rol;


namespace ElimIzalco.SysRegistroGeneral.DAL.Rol
{
    public class RolDAL
    {
        #region Obtener Todos Los Roles
        // Metodo para Obtener Todos los Roles Existentes
        public List<RolEN> ObtenerRoles()
        {
            // Creamos una instancia de RolEN para acceder a los atributos
            List<RolEN> listaRol = new List<RolEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Rol;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de RolEN para acceder a los atributos
                RolEN Objrol = new RolEN();

                // Asignacion de Columnas
                Objrol.Id = reader.GetInt32(0);
                Objrol.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjRol
                listaRol.Add(Objrol);
            }
            // Retornamos el listado
            return listaRol;
        }
        #endregion

        #region Obtener Roles Por Id
        // Metodo para Obtener Roles en Base al Id Proporcionado
        public RolEN ObtenerRolesPorId(int? pId)
        {
            // Creamos una instancia de RolesEN para acceder a los atributos
            RolEN Rol = new RolEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Rol WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                Rol.Id = reader.GetInt32(0);
                Rol.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return Rol;
        }
        #endregion

    }
}
