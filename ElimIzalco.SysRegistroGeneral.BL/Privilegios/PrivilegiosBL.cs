using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Privilegios;

namespace ElimIzalco.SysRegistroGeneral.BL.Privilegios
{
    public class PrivilegiosBL
    {
        // Creamos una Instancia de la clase PrivilegiosDAL
        PrivilegiosDAL ObjPrivilegioDAL = new PrivilegiosDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<PrivilegiosEN> ObtenerPrivilegio()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjPrivilegioDAL.ObtenerPrivilegio();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public PrivilegiosEN ObtenerPrivilegioPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjPrivilegioDAL.ObtenerPrivilegioPorId(pId);
        }

        // Este método devuelve una lista de objetos que utiliza la DAL para obtener una lista cuyos nombres coincidan parcialmente con el nombre proporcionado.
        public List<PrivilegiosEN> ObtenerPrivilegiosLike(string pNombre)
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros con nombres similares.
            return ObjPrivilegioDAL.ObtenerPrivilegioLike(pNombre);
        }
    }
}