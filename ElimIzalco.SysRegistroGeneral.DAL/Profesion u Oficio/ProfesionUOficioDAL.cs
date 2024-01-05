using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.DAL;
using ElimIzalco.SysRegistroGeneral.EN.Categoria_Para_Profesion_u_Oficio;

namespace ElimIzalco.SysRegistroGeneral.EN.Profesion_u_Oficio
{
    public class ProfesionUOficioDAL
    {
        #region ObtenerProfesionUOficio
        // Metodo para Obtener una lista completa
        public List<ProfesionUOficioEN> ObtenerProfesionUOficio()
        {
            // Creamos una instancia de PrivilegiosEN para acceder a los atributos
            List<ProfesionUOficioEN> listaProfesionUOficio = new List<ProfesionUOficioEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, IdCategoria FROM ProfesionUOficio";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de ProfesionUOficioEN para acceder a los atributos
                ProfesionUOficioEN ObjProfesionUOficio = new ProfesionUOficioEN();

                // Asignacion de columnas
                ObjProfesionUOficio.Id = reader.GetInt32(0);
                ObjProfesionUOficio.Nombre = reader.GetString(1);
                ObjProfesionUOficio.IdCategoria = new CategoriaParaProfesionUOficioEN
                {
                    Id = reader.GetInt32(3),
                    Nombre = reader.GetString(4),
                };

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjProfesionUOficio
                listaProfesionUOficio.Add(ObjProfesionUOficio);
            }
            // Retornamos el listado
            return listaProfesionUOficio;
        }
        #endregion

        #region ObtenerProfesionUOficioPorId
        // Metodo para Obtener una lista segun el Id Proporcionado
        public ProfesionUOficioEN ObtenerProfesionUOficioPorId(int? pId)
        {
            // Creamos una instancia de PastoresEN para acceder a los atributos
            ProfesionUOficioEN ObjProfesionUOficio = new ProfesionUOficioEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, IdCategoria FROM ProfesionUOficio WHERE Id = @Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                ObjProfesionUOficio.Id = reader.GetInt32(0);
                ObjProfesionUOficio.Nombre = reader.GetString(1);
                ObjProfesionUOficio.IdCategoria = new CategoriaParaProfesionUOficioEN
                {
                    Id = reader.GetInt32(3),
                    Nombre = reader.GetString(4),
                };
            }
            // Retornamos el listado
            return ObjProfesionUOficio;
        }
        #endregion

        #region ObtenerProfesionUOficioLikes
        // Metodo para Obtener una lista en base al parametro Nombre
        public List<ProfesionUOficioEN> ObtenerProfesionUOficioLike(string pNombre)
        {
            // Creamos una instancia de ProfesionUOficioEN para acceder a los atributos
            List<ProfesionUOficioEN> listaProfesionUOficio = new List<ProfesionUOficioEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, IdCategoria FROM ProfesionUOficio WHERE Nombre LIKE @Nombre";

            SqlCommand command = ComunDB.ObtenerComando();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Nombre", "%" + pNombre + "%"); // Se Agregan caracteres comodín para buscar coincidencias parciales

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una instancia de ProfesionUOficioEN para acceder a los atributos
                ProfesionUOficioEN ObjProfesionUOficio = new ProfesionUOficioEN();

                // Asignacion de columnas
                ObjProfesionUOficio.Id = reader.GetInt32(0);
                ObjProfesionUOficio.Nombre = reader.GetString(1);
                ObjProfesionUOficio.IdCategoria = new CategoriaParaProfesionUOficioEN
                {
                    Id = reader.GetInt32(2),
                    Nombre = reader.GetString(3),
                };

                // A los atributos de la primera instancia se le asignan los datos encontrados del ObjProfesionUOficio
                listaProfesionUOficio.Add(ObjProfesionUOficio);
            }
            // Retornamos el listado
            return listaProfesionUOficio;
        }
        #endregion
    }
}
