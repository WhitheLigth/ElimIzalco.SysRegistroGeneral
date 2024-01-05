using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Lista_de_Calendario;

namespace ElimIzalco.SysRegistroGeneral.BL.Lista_de_Calendario
{
    public class ListaDeCalendarioBL
    {
        // Creamos una Instancia de la clase ListaDeCalendarioDAL
        ListaDeCalendarioDAL ObjListaCalendarioDAL = new ListaDeCalendarioDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<ListaDeCalendarioEN> ObtenerListaCalendario()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjListaCalendarioDAL.ObtenerListaCalendario();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public ListaDeCalendarioEN ObtenerListaCalendarioPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjListaCalendarioDAL.ObtenerListaCalendarioPorId(pId);
        }
    }
}
