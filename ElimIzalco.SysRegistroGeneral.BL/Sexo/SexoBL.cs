using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Sexo;

namespace ElimIzalco.SysRegistroGeneral.BL.Sexo
{
    public class SexoBL
    {
        // Creamos una Instancia de la clase SexoDAL
        SexoDAL ObjSexoDAL = new SexoDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<SexoEN> ObtenerSexo()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjSexoDAL.ObtenerSexo();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public SexoEN ObtenerSexoPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjSexoDAL.ObtenerSexoPorId(pId);
        }
    }
}
