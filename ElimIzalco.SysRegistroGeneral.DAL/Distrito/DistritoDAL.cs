using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Distrito
{
    public class DistritoDAL
    {
        // Metodo para Obtener una lista completa
        public List<DistritoEN> ObtenerDistrito()
        {
            // Creamos una instancia de DistritoEN para acceder a los atributos
            List<DistritoEN> listaDistrito = new List<DistritoEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Distrito;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de DistritoEN para acceder a los atributos
                DistritoEN ObjDistrito = new DistritoEN();

                // Asignacion de columnas
                ObjDistrito.Id = reader.GetInt32(0);
                ObjDistrito.Numero = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjDistrito
                listaDistrito.Add(ObjDistrito);
            }
            // Retornamos el listado
            return listaDistrito;

        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public DistritoEN ObtenerDistritoPorId(int? pId)
        {
            // Creamos una instancia de DistritoEN para acceder a los atributos
            DistritoEN distrito = new DistritoEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Numero FROM Distrito WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                distrito.Id = reader.GetInt32(0);
                distrito.Numero = reader.GetString(1);
            }
            // Retornamos el listado
            return distrito;

        }
    }
}
