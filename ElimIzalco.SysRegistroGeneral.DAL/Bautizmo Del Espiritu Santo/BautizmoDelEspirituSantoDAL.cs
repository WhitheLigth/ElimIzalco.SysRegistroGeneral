using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL BUEN FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;


namespace ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo
{
    public class BautizmoDelEspirituSantoDAL
    {
        #region ObtenerBautizmoEspirituSanto
        // Metodo para Obtener una lista completa
        public List<BautizmoDelEspirituSantoEN> ObtenerBautizmoEspirituSanto()
        {
            // Creamos una instancia de BautizmoDelEspirituSantoEN para acceder a los atributos
            List<BautizmoDelEspirituSantoEN> listaBautizmoEspirituSanto = new List<BautizmoDelEspirituSantoEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM BautizmoEspirituSanto;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de BautizmoDelEspirituSantoEN para acceder a los atributos
                BautizmoDelEspirituSantoEN ObjBautizmoEspirituSanto = new BautizmoDelEspirituSantoEN();

                // Asignacion de columnas
                ObjBautizmoEspirituSanto.Id = reader.GetInt32(0);
                ObjBautizmoEspirituSanto.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjBautizmoEspirituSanto
                listaBautizmoEspirituSanto.Add(ObjBautizmoEspirituSanto);
            }
            // Retornamos el listado 
            return listaBautizmoEspirituSanto;
        }
        #endregion

        #region ObtenerBautizoEspirituSantoPorId
        // Metodo para Obtener una lista segun el Id Proporcionado
        public BautizmoDelEspirituSantoEN ObtenerBautizoEspirituSantoPorId(int? pId)
        {
            // Creamos una instancia de BautizmoDelEspirituSantoEN para acceder a los atributos
            BautizmoDelEspirituSantoEN bautizoEspirituSanto = new BautizmoDelEspirituSantoEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM BautizmoEspirituSanto WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                bautizoEspirituSanto.Id = reader.GetInt32(0);
                bautizoEspirituSanto.Nombre = reader.GetString(1);
            }
            // Retornamos el listado 
            return bautizoEspirituSanto;
        }
        #endregion
    }
}
