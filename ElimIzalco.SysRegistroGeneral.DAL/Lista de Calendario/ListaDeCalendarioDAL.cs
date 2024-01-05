using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;

namespace ElimIzalco.SysRegistroGeneral.EN.Lista_de_Calendario
{
    public class ListaDeCalendarioDAL
    {
        // Metodo para Obtener una lista completa
        public List<ListaDeCalendarioEN> ObtenerListaCalendario()
        {
            // Creamos una instancia de ListaDeCalendarioEN para acceder a los atributos
            List<ListaDeCalendarioEN> listaCalendario = new List<ListaDeCalendarioEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM ListaCalendario;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de ListaDeCalendarioEN para acceder a los atributos
                ListaDeCalendarioEN ObjListaCalendario = new ListaDeCalendarioEN();

                // Asignacion de columnas
                ObjListaCalendario.Id = reader.GetInt32(0);
                ObjListaCalendario.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjListaCalendario
                listaCalendario.Add(ObjListaCalendario);
            }
            // Retornamos el listado
            return listaCalendario;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public ListaDeCalendarioEN ObtenerListaCalendarioPorId(int? pId)
        {
            // Creamos una instancia de ListaDeCalendarioEN para acceder a los atributos
            ListaDeCalendarioEN listaCalendario = new ListaDeCalendarioEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM ListaCalendario WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                listaCalendario.Id = reader.GetInt32(0);
                listaCalendario.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return listaCalendario;
        }
    }
}
