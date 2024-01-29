using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERNCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.DAL.Usuarios;
using ElimIzalco.SysRegistroGeneral.EN.Usuarios;


namespace ElimIzalco.SysRegistroGeneral.BL.Usuarios
{
    public class UsuarioBL
    {
        // Creamos una Instancia de la clase UsuarioDAL
        UsuarioDAL ObjUsuario = new UsuarioDAL();

        // Este método devuelve una lista de objetos y Llamamos al metodo correspondiente de la DAL para obtener todos los Registros de la Base de Datos
        public List<UsuarioEN> ObtenerUsuarios()
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros
            return ObjUsuario.ObtenerUsuarios();
        }

        // Este método obtiene un registro específico según el ID proporcionado y Llamamos al metodo correspondiente de la DAL para obtener un solo registro de la Base de Datos
        // Identificado por el Id pasado como parametro
        public UsuarioEN ObtenerUsuarioPorId(int? pId)
        {
            // Llama al método correspondiente en la capa DAL para obtener un registro por su ID.
            return ObjUsuario.ObtenerUsuarioPorId(pId);
        }

        // Este método devuelve una lista de objetos que utiliza la DAL para obtener una lista cuyos nombres coincidan parcialmente con el nombre proporcionado.
        public List<UsuarioEN> ObtenerUsuarioLike(string Nombre)
        {
            // Llama al método correspondiente en la capa DAL para obtener los registros con nombres similares.
            return ObjUsuario.ObtenerUsuarioLike(Nombre);
        }

        // Metodo para Validar la Existencia del Usuario en la Base de Datos
        public (int Resultado, UsuarioEN Usuario) ValidarExistenciaUsuario(UsuarioEN pUsuario)
        {
            // Accedemos al método ObtenerUsuario y pedimos que nos muestre el primer resultado que encuentre
            var usuarios = ObtenerUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.Correo == pUsuario.Correo && u.Password == pUsuario.Password);

            // Validamos si el usuario es diferente de null y devuelve -1, si no, devuelve 0
            if (usuario != null)
            {
                // Significa que sí existe
                return (-1, usuario);
            }
            else
            {
                // Significa que no existe
                return (0, null);
            }
        }
    }
}
