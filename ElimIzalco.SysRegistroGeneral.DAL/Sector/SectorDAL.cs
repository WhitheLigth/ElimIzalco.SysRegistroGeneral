using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFEREMCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Sector
{
    public class SectorDAL
    {
        // Metodo para Obtener una lista completa
        public List<SectorEN> ObtenerSector()
        {
            // Creamos una instancia de SectorEN para acceder a los atributos
            List<SectorEN> listaSector = new List<SectorEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Sector";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);
            
            while (reader.Read())
            {
                // Creamos una nueva instancia de SectorEN para acceder a los atributos
                SectorEN ObjSector = new SectorEN();

                // Asignacion de columnas
                ObjSector.Id = reader.GetInt32(0);
                ObjSector.Numero = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjSector
                listaSector.Add(ObjSector);
            }
            // Retornamos el listado
            return listaSector;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public SectorEN ObtenerSectorPorId(int? pId)
        {
            // Creamos una instancia de SectorEN para acceder a los atributos
            SectorEN listaSector = new SectorEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Sector WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnass
                listaSector.Id = reader.GetInt32(0);
                listaSector.Numero = reader.GetString(1);
            }
            // Retornamos el listado
            return listaSector;
        }
    }
}
