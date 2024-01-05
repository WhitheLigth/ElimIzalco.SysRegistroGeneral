using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Sexo
{
    public class SexoDAL
    {
        // Metodo para Obtener una lista completa
        public List<SexoEN> ObtenerSexo()
        {
            // Creamos una instancia de SexoEN para acceder a los atributos
            List<SexoEN> listaSexo = new List<SexoEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Sexo";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de SexoEN para acceder a los atributos
                SexoEN ObjSexo = new SexoEN();

                // Asignacion de columnas
                ObjSexo.Id = reader.GetInt32(0);
                ObjSexo.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjSexo
                listaSexo.Add(ObjSexo);
            }
            // Retornamos el listado
            return listaSexo;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public SexoEN ObtenerSexoPorId(int? pId)
        {
            // Creamos una instancia de SexoEN para acceder a los atributos
            SexoEN listaSexo = new SexoEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM Sexo WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnass
                listaSexo.Id = reader.GetInt32(0);
                listaSexo.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return listaSexo;
        }
    }
}
