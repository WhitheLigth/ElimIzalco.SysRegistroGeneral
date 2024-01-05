using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.DAL.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.EN.Estado_Civil;

namespace ElimIzalco.SysRegistroGeneral.BL.Estado_Civil
{
    public class EstadoCivilBL
    {
        // Creamos una Instancia de la clase EstadoCivilDAL
        EstadoCivilDAL ObjEstadoCivilDAL = new EstadoCivilDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<EstadoCivilEN> ObtenerEstadoCivil()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjEstadoCivilDAL.ObtenerEstadoCivil();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public EstadoCivilEN ObtenerEstadoCivilPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjEstadoCivilDAL.ObtenerEstadoCivilPorId(pId);
        }
    }
}
