using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.EN.Estado_Civil;

namespace ElimIzalco.SysRegistroGeneral.DAL.Estado_Civil
{
    public class EstadoCivilDAL
    {
        // Metodo para Obtener una lista completa
        public List<EstadoCivilEN> ObtenerEstadoCivil()
        {
            // Creamos una instancia de EstadoCivilEN para acceder a los atributos
            List<EstadoCivilEN> listaEstadoCivil = new List<EstadoCivilEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM EstadoCivil;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de EstadoCivilEN para acceder a los atributos
                EstadoCivilEN ObjEstadoCivil = new EstadoCivilEN();

                // Asignacion de columnas
                ObjEstadoCivil.Id = reader.GetInt32(0);
                ObjEstadoCivil.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjEstadoCivil
                listaEstadoCivil.Add(ObjEstadoCivil);
            }
            // Retornamos el listado
            return listaEstadoCivil;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public EstadoCivilEN ObtenerEstadoCivilPorId(int? pId)
        {
            // Creamos una instancia de EstadoCivilEN para acceder a los atributos
            EstadoCivilEN estadoCivil = new EstadoCivilEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM EstadoCivil WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                estadoCivil.Id = reader.GetInt32(0);
                estadoCivil.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return estadoCivil;
        }
    }
}
