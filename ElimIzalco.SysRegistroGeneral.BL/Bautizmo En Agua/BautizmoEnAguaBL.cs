using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_En_Agua;

namespace ElimIzalco.SysRegistroGeneral.BL.Bautizmo_En_Agua
{
    public class BautizmoEnAguaBL
    {
        // Creamos una Instancia de la clase BautizmoEnAguaDAL
        BautizmoEnAguaDAL ObjBautizoEnAguaDAL = new BautizmoEnAguaDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<BautizmoEnAguaEN> ObtenerBautizmoEnAgua()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros.
            return ObjBautizoEnAguaDAL.ObtenerBautizmoEnAgua();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public BautizmoEnAguaEN ObtenerBautizmoEnAguaPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjBautizoEnAguaDAL.ObtenerBautizoEnAguaPorId(pId);
        }
    }
}
