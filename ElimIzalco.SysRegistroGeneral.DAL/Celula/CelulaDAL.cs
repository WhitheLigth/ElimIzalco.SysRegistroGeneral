using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Celula
{
    public class CelulaDAL
    {
        // Metodo para Obtener una lista completa
        public List<CelulaEN> ObtenerCelula()
        {
            // Creamos una instancia de CelulaEN para acceder a los atributos
            List<CelulaEN> listaCelula = new List<CelulaEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Celula;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de CelulaEN para acceder a los atributos
                CelulaEN ObjCelula = new CelulaEN();

                // Asignacion de columnas
                ObjCelula.Id = reader.GetInt32(0);
                ObjCelula.Numero = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjCelula
                listaCelula.Add(ObjCelula);
            }
            // Retornamos el listado
            return listaCelula;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public CelulaEN ObtenerCelulaPorId(int? pId)
        {
            // Creamos una instancia de CelulaEN para acceder a los atributos
            CelulaEN celula = new CelulaEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Celula WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                celula.Id = reader.GetInt32(0);
                celula.Numero = reader.GetString(1);
            }
            // Retornamos el listado
            return celula;
        }
    }
}
