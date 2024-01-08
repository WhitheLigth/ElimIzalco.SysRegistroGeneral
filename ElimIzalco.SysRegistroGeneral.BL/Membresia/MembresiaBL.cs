using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using ElimIzalco.SysRegistroGeneral.DAL.Membresia;

namespace ElimIzalco.SysRegistroGeneral.BL.Membresia
{
    public class MembresiaBL
    {
        // Creamos una Instancia de la Clase MembresiaDAL
        MembresiaDAL ObjMembresiaDAL = new MembresiaDAL();

        // Metodo Para validar la Existencia de la Membresia
        public int ValidarExistenciaMembresia(MembresiaEN pMembresiaGuardar)
        {
            return ObjMembresiaDAL.ValidarExistenciaMembresia(pMembresiaGuardar);
        }
        // Metodo para Guardar una Nueva Membresia
        public int GuardarMembresia(MembresiaEN pMembresiaGuardar)
        {
            return ObjMembresiaDAL.GuardarMembresia(pMembresiaGuardar);
        }
        // Metodo para Eliminar una Nueva Membresia
        public int EliminarMembresia(MembresiaEN pMembresiaELiminar)
        {
            return ObjMembresiaDAL.EliminarMembresia(pMembresiaELiminar);
        }
        // Metodo para Modificar una Nueva Membresia
        public int ModificarMembresia(MembresiaEN pMembresiaModificar)
        {
            return ObjMembresiaDAL.ModificarMembresia(pMembresiaModificar);
        }
        // Metodo para Obtener todas las Membresias de la Base de Datos
        public List<MembresiaEN> ObtenerMembresia()
        {
            return ObjMembresiaDAL.ObtenerMembresia();
        }
        // Metodo para Obtener un Registro en Base al Id
        public MembresiaEN ObtenerPorId(int? pId)
        {
            return ObjMembresiaDAL.ObtenerMembresiaPorId(pId);
        }
        // metodo para Obtener Registros por Similitud de Caracteres Proporcionados para la Busqueda
        public List<MembresiaEN> ObtenerMembresiaLike(string pNombre)
        {
            return ObjMembresiaDAL.ObtenerMembresiaLike(pNombre);
        }
    }
}
