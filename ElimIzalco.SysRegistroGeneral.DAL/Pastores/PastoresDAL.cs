using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Pastores
{
    public class PastoresDAL
    {
        #region ObtenerPastor
        // Metodo para Obtener una lista completa
        public List<PastoresEN> ObtenerPastor()
        {
            // Creamos una instancia de PastoresEN para acceder a los atributos
            List<PastoresEN> listaPastor = new List<PastoresEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, Edad, DUI, FechaNacimiento, Telefono, FechaCreacion, FechaModificacion FROM Pastores";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de PastoresEN para acceder a los atributos
                PastoresEN ObjPastor = new PastoresEN();

                // Asignacion de columnas
                ObjPastor.Id = reader.GetInt32(0);
                ObjPastor.Nombre = reader.GetString(1);
                ObjPastor.Edad = reader.GetString(2);
                ObjPastor.Dui = reader.GetString(3);
                ObjPastor.FechaDeNacimiento = reader.GetDateTime(4);
                ObjPastor.Telefono = reader.GetString(5);
                ObjPastor.FechaCreacion = reader.GetDateTime(6);
                ObjPastor.FechaModificacion = reader.GetDateTime(7);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjPastor
                listaPastor.Add(ObjPastor);
            }
            // Retornamos el listado
            return listaPastor;
        }
        #endregion

        #region ObtenerPastorPorId
        // Metodo para Obtener una lista segun el Id Proporcionado
        public PastoresEN ObtenerPastorPorId(int? pId)
        {
            // Creamos una instancia de PastoresEN para acceder a los atributos
            PastoresEN pastor = new PastoresEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, Edad, DUI, FechaNacimiento, Telefono, FechaCreacion, FechaModificacion FROM Pastores WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                pastor.Id = reader.GetInt32(0);
                pastor.Nombre = reader.GetString(1);
                pastor.Edad = reader.GetString(2);
                pastor.Dui = reader.GetString(3);
                pastor.FechaDeNacimiento = reader.GetDateTime(4);
                pastor.Telefono = reader.GetString(5);
                pastor.FechaCreacion = reader.GetDateTime(6);
                pastor.FechaModificacion = reader.GetDateTime(7);
            }
            // Retornamos el listado
            return pastor;
        }
        #endregion
    }
}
