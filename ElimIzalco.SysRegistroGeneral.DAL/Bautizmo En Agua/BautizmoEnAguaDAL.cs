using ElimIzalco.SysRegistroGeneral.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO

namespace ElimIzalco.SysRegistroGeneral.EN.Bautizmo_En_Agua
{
    public class BautizmoEnAguaDAL
    {
        // Metodo para Obtener una lista completa
        public List<BautizmoEnAguaEN> ObtenerBautizmoEnAgua()
        {
            // Creamos una instancia de BautizmoEnAguaEN para acceder a los atributos
            List<BautizmoEnAguaEN> listaBautizmoEnAgua = new List<BautizmoEnAguaEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM BautizmoEnAgua;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de BautizmoEnAguaEN para acceder a los atributos
                BautizmoEnAguaEN ObjBautizmoEnAgua = new BautizmoEnAguaEN();

                // Asignacion de columnas
                ObjBautizmoEnAgua.Id = reader.GetInt32(0);
                ObjBautizmoEnAgua.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjBautizmoEnAgua
                listaBautizmoEnAgua.Add(ObjBautizmoEnAgua);
            }
            // Retornamos el listado 
            return listaBautizmoEnAgua;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public BautizmoEnAguaEN ObtenerBautizoEnAguaPorId(int? pId)
        {
            // Creamos una instancia de BautizmoDelEspirituSantoEN para acceder a los atributos
            BautizmoEnAguaEN bautizmoEnAgua = new BautizmoEnAguaEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM BautizmoEnAgua WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                bautizmoEnAgua.Id = reader.GetInt32(0);
                bautizmoEnAgua.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return bautizmoEnAgua;

        }
    }
}
