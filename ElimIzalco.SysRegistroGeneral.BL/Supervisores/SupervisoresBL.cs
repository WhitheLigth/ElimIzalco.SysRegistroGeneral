using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Supervisores;

namespace ElimIzalco.SysRegistroGeneral.BL.Supervisores
{
    public class SupervisoresBL
    {
        // Creamos una Instancia de la clase SupervisoresDAL
        SupervisoresDAL ObjSupervisorDAL = new SupervisoresDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datoss
        public List<SupervisoresEN> ObtenerSupervisor()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjSupervisorDAL.ObtenerSupervisor();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public SupervisoresEN ObtenerPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjSupervisorDAL.ObtenerSupervisorPorId(pId);
        }
    }
}
