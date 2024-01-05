using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo;

namespace ElimIzalco.SysRegistroGeneral.BL.Bautizmo_Del_Espiritu_Santo
{
    public class BautizmoDelEspirituSantoBL
    {
        // Creamos una Instancia de la clase BautizmoDelEspirituSantoDAL
        BautizmoDelEspirituSantoDAL ObjBautizmoEspirituSantoDAL = new BautizmoDelEspirituSantoDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<BautizmoDelEspirituSantoEN> ObtenerBautizmoDelEspirituSanto()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros.
            return ObjBautizmoEspirituSantoDAL.ObtenerBautizmoEspirituSanto();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public BautizmoDelEspirituSantoEN ObtenerBautizmoDelEspirituSantoPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjBautizmoEspirituSantoDAL.ObtenerBautizoEspirituSantoPorId(pId);
        }
    }
}
