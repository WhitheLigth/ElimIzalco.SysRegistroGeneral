using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Estatus
{
    public class EstatusDAL
    {
        #region ObtenerEstatus
        // Metodo para Obtener una lista completa
        public List<EstatusEN> ObtenerEstatus()
        {
            // Creamos una instancia de EstatusEN para acceder a los atributos
            List<EstatusEN> listaEstatus = new List<EstatusEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Estatus;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de EstatusEN para acceder a los atributos
                EstatusEN ObjEstatus = new EstatusEN();

                // Asignacion de columnas
                ObjEstatus.Id = reader.GetInt32(0);
                ObjEstatus.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjEstatus
                listaEstatus.Add(ObjEstatus);
            }
            // Retornamos el listado
            return listaEstatus;
        }
        #endregion

        #region ObtenerEstatusPorId
        // Metodo para Obtener una lista segun el Id Proporcionado
        public EstatusEN ObtenerEstatusPorId(int? pId)
        {
            // Creamos una instancia de EstatusEN para acceder a los atributos
            EstatusEN estatus = new EstatusEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Estatus WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                estatus.Id = reader.GetInt32(0);
                estatus.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return estatus;
        }
        #endregion
    }
}
