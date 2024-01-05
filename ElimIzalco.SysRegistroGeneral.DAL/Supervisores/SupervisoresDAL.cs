using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Supervisores
{
    public class SupervisoresDAL
    {
        #region ObtenerSupervisor
        // Metodo para Obtener una lista completa
        public List<SupervisoresEN> ObtenerSupervisor()
        {
            // Creamos una instancia de SupervisoresEN para acceder a los atributos
            List<SupervisoresEN> listaSupervisor = new List<SupervisoresEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, Edad, DUI, FechaNacimiento, Telefono, FechaCreacion, FechaModificacion FROM Supervisores";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de SupervisoresEN para acceder a los atributos
                SupervisoresEN ObjSupervisor = new SupervisoresEN();

                // Asignacion de columnas
                ObjSupervisor.Id = reader.GetInt32(0);
                ObjSupervisor.Nombre = reader.GetString(1);
                ObjSupervisor.Edad = reader.GetString(2);
                ObjSupervisor.Dui = reader.GetString(3);
                ObjSupervisor.FechaDeNacimiento = reader.GetDateTime(4);
                ObjSupervisor.Telefono = reader.GetString(5);
                ObjSupervisor.FechaCreacion = reader.GetDateTime(6);
                ObjSupervisor.FechaModificacion = reader.GetDateTime(7);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjSupervisor
                listaSupervisor.Add(ObjSupervisor);
            }
            // Retornamos el listado
            return listaSupervisor;
        }
        #endregion

        #region ObtenerSupervisorPorId
        // Metodo para Obtener una lista segun el Id Proporcionado
        public SupervisoresEN ObtenerSupervisorPorId(int? pId)
        {
            // Creamos una instancia de SexoEN para acceder a los atributos
            SupervisoresEN supervisor = new SupervisoresEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, Edad, DUI, FechaNacimiento, Telefono, FechaCreacion, FechaModificacion FROM Supervisores WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                supervisor.Id = reader.GetInt32(0);
                supervisor.Nombre = reader.GetString(1);
                supervisor.Edad = reader.GetString(2);
                supervisor.Dui = reader.GetString(3);
                supervisor.FechaDeNacimiento = reader.GetDateTime(4);
                supervisor.Telefono = reader.GetString(5);
                supervisor.FechaCreacion = reader.GetDateTime(6);
                supervisor.FechaModificacion = reader.GetDateTime(7);
            }
            // Retornamos el listado
            return supervisor;
        }
        #endregion
    }
}
