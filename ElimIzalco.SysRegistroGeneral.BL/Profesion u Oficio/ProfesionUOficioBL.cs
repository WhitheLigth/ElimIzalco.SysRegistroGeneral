using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Profesion_u_Oficio;

namespace ElimIzalco.SysRegistroGeneral.BL.Profesion_u_Oficio
{
    public class ProfesionUOficioBL
    {
        // Creamos una Instancia de la clase ProfesionUOficioDAL
        ProfesionUOficioDAL ObjProfesionUOficioDAL = new ProfesionUOficioDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<ProfesionUOficioEN> ObtenerProfesionUOficio()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjProfesionUOficioDAL.ObtenerProfesionUOficio();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public ProfesionUOficioEN ObtenerProfesionUOficioPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjProfesionUOficioDAL.ObtenerProfesionUOficioPorId(pId);
        }

        // Este método devuelve una lista de objetos que utiliza la DAL para obtener una lista cuyos nombres coincidan parcialmente con el nombre proporcionado.
        public List<ProfesionUOficioEN> ObtenerProfesionUOficioLike(string pNombre)
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros con nombres similares.
            return ObjProfesionUOficioDAL.ObtenerProfesionUOficioLike(pNombre);
        }
    }
}
