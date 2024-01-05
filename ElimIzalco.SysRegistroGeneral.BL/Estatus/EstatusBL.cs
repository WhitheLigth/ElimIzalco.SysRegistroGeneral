using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Estatus;

namespace ElimIzalco.SysRegistroGeneral.BL.Estatus
{
    public class EstatusBL
    {
        // Creamos una Instancia de la clase EstatusDAL
        EstatusDAL ObjEstatusDAL = new EstatusDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<EstatusEN> ObtenerEstatus()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjEstatusDAL.ObtenerEstatus();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public EstatusEN ObtenerEstatusPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjEstatusDAL.ObtenerEstatusPorId(pId);
        }
    }
}
