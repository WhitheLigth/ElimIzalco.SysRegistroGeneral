using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Categoria_Para_Profesion_u_Oficio;

namespace ElimIzalco.SysRegistroGeneral.BL.Categoria_Para_Profesion_u_Oficio
{
    public class CategoriaParaProfesionUOficioBL
    {
        // Creamos una Instancia de la clase CategoriaParaProfesionUOficioDAL
        CategoriaParaProfesionUOficioDAL ObjProfesionUOficioDAL = new CategoriaParaProfesionUOficioDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<CategoriaParaProfesionUOficioEN> ObtenerCategoriaProfesionUOficio()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros.
            return ObjProfesionUOficioDAL.ObtenerCategoriaProfesionUOficio();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public CategoriaParaProfesionUOficioEN ObtenerCategoriaProfesionUOficioPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjProfesionUOficioDAL.ObtenerCategoriaProfesionUOficioPorId(pId);
        }
    }
}
