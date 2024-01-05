using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;


namespace ElimIzalco.SysRegistroGeneral.EN.Categoria_Para_Profesion_u_Oficio
{
    public class CategoriaParaProfesionUOficioDAL
    {
        // Metodo para Obtener una lista completa
        public List<CategoriaParaProfesionUOficioEN> ObtenerCategoriaProfesionUOficio()
        {
            // Creamos una instancia de CategoriaParaProfesionUOficioEN para acceder a los atributos
            List<CategoriaParaProfesionUOficioEN> listaCategoria = new List<CategoriaParaProfesionUOficioEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre FROM CategoriaParaProfesionUOficio;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de BautizmoEnAguaEN para acceder a los atributos
                CategoriaParaProfesionUOficioEN ObjCategoria = new CategoriaParaProfesionUOficioEN();

                // Asignacion de columnas
                ObjCategoria.Id = reader.GetInt32(0);
                ObjCategoria.Nombre = reader.GetString(1);

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjCategoria
                listaCategoria.Add(ObjCategoria);
            }
            // Retornamos el listado
            return listaCategoria;
        }
        // Metodo para Obtener una lista segun el Id Proporcionado
        public CategoriaParaProfesionUOficioEN ObtenerCategoriaProfesionUOficioPorId(int? pId)
        {
            // Creamos una instancia de BautizmoDelEspirituSantoEN para acceder a los atributos
            CategoriaParaProfesionUOficioEN categoria = new CategoriaParaProfesionUOficioEN();

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
                categoria.Id = reader.GetInt32(0);
                categoria.Nombre = reader.GetString(1);
            }
            // Retornamos el listado
            return categoria;
        }
    }
}
