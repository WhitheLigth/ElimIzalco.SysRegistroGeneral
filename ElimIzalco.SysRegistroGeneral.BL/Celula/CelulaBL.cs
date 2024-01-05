using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Celula;

namespace ElimIzalco.SysRegistroGeneral.BL.Celula
{
    public class CelulaBL
    {
        // Creamos una Instancia de la clase CelulaDAL
        CelulaDAL ObjCelulaDAL = new CelulaDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<CelulaEN> ObtenerCelula()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjCelulaDAL.ObtenerCelula();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public CelulaEN ObtenerCelulaPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjCelulaDAL.ObtenerCelulaPorId(pId);
        }
    }
}
