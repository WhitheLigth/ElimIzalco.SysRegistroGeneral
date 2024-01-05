using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Privilegios
{
    public class PrivilegiosDAL
    {
        #region ObtenerPrivilegio
        // Metodo para Obtener una lista completa
        public List<PrivilegiosEN> ObtenerPrivilegio()
        {
            // Creamos una instancia de PrivilegiosEN para acceder a los atributos
            List<PrivilegiosEN> listaPrivilegio = new List<PrivilegiosEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Privilegios";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de PrivilegiosEN para acceder a los atributos
                PrivilegiosEN ObjPrivilegio = new PrivilegiosEN();

                // Asignacion de columnas
                ObjPrivilegio.Id = reader.GetInt32(0);
                ObjPrivilegio.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjPrivilegio
                listaPrivilegio.Add(ObjPrivilegio);
            }
            // Retornamos el listado
            return listaPrivilegio;
        }
        #endregion

        #region ObtenerPrivilegioPorId
        // Metodo para Obtener una lista segun el Id Proporcionado
        public PrivilegiosEN ObtenerPrivilegioPorId(int? pId)
        {
            // Creamos una instancia de PastoresEN para acceder a los atributos
            PrivilegiosEN listaPrivilegio = new PrivilegiosEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Privilegios WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                listaPrivilegio.Id = reader.GetInt32(0);
                listaPrivilegio.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return listaPrivilegio;
        }
        #endregion

        #region ObtenerPrivilegioLike
        // Metodo para Obtener una lista en base al parametro Nombre
        public List<PrivilegiosEN> ObtenerPrivilegioLike(string pNombre)
        {
            // Creamos una instancia de PastoresEN para acceder a los atributos
            List<PrivilegiosEN> listaPrivilegio = new List<PrivilegiosEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Privilegios WHERE Nombre LIKE @Nombre";

            SqlCommand command = ComunDB.ObtenerComando();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Nombre", "%" + pNombre + "%"); // Se Agregan caracteres comodín para buscar coincidencias parciales

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una instancia de PastoresEN para acceder a los atributos
                PrivilegiosEN ObjPrivilegio = new PrivilegiosEN();

                // Asignacion de columnas
                ObjPrivilegio.Id = reader.GetInt32(0);
                ObjPrivilegio.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjPrivilegio
                listaPrivilegio.Add(ObjPrivilegio);
            }
            // Retornamos el listado
            return listaPrivilegio;
        }
        #endregion
    }
}
