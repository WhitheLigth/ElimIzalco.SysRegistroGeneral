using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.DAL.Rol;
using ElimIzalco.SysRegistroGeneral.EN.Rol;


namespace ElimIzalco.SysRegistroGeneral.BL.Rol
{
    public class RolBL
    {
        // Creamos la Instancia Para Acceder a los metodos
        RolDAL ObjRol = new RolDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<RolEN> ObtenerRol()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjRol.ObtenerRoles();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public RolEN ObtenerRolPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjRol.ObtenerRolesPorId(pId);
        }
    }
}
