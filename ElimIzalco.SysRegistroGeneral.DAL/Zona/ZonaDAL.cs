using ElimIzalco.SysRegistroGeneral.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElimIzalco.SysRegistroGeneral.EN.Zona
{
    public class ZonaDAL
    {
        // Metodo para Obtener una lista completa
        public List<ZonaEN> ObtenerZona()
        {
            // Creamos una instancia de ZonaEN para acceder a los atributos
            List<ZonaEN> listaZona = new List<ZonaEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Zona";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de ZonaEN para acceder a los atributos
                ZonaEN ObjZona = new ZonaEN();

                // Asignacion de columnas
                ObjZona.Id = reader.GetInt32(0);
                ObjZona.Numero = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjZona
                listaZona.Add(ObjZona);
            }
            // Retornamos el listado
            return listaZona;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public ZonaEN ObtenerZonaPorId(int? pId)
        {
            // Creamos una instancia de ZonaEN para acceder a los atributos
            ZonaEN listaZona = new ZonaEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Zona WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                listaZona.Id = reader.GetInt32(0);
                listaZona.Numero = reader.GetString(1);
            }
            // Retornamos el listado
            return listaZona;
        }
    }
}
