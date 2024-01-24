using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.EN.Servidores;

namespace ElimIzalco.SysRegistroGeneral.DAL.Servidores
{
    public class ServidoresDAL
    {
        #region Metodo para Guardar un Servidor
        // Metodo para Guardar un Servidor a la Base de Datos
        public int GuardarServidor(ServidoresEN pServidorGuardar)
        {
            //// Accedemos al metodo ObtenerServidor y pedimos que nos muestre el primer resultado que encuentre
            //var servidores = ObtenerServidor();
            //var servidor = servidores.FirstOrDefault(c => c.Id == pServidorGuardar.Id);

            //// Validamos que si servidor es diferente que null devuelva un 0
            //if (servidor != null)
            //{
            //    // Significa que no Existe
            //    return 0;
            //}

            // Consulta hacia la Base de Datos
            string consulta = "INSERT INTO Servidores(IdMembresia, IdPrivilegio, IdEstatus) " +
                "VALUES (@IdMembresia, @IdPrivilegio, @IdEstatus)";
            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;

            command.Parameters.AddWithValue("@IdMembresia", pServidorGuardar.Membresia.Id);
            command.Parameters.AddWithValue("@IdPrivilegio", pServidorGuardar.Privilegio.Id);
            command.Parameters.AddWithValue("@IdEstatus", pServidorGuardar.Estatus.Id);

            return ComunDB.EjecutarComando(command);
        }
        #endregion

        #region Metodo para Modificar un Servidor
        // Metodo para poder Modificar un Servidor Existente
        public int ModificarServidor(ServidoresEN pServidorModificar)
        {
            // Consulta hacia la Base de Datos
            string consulta = "UPDATE Servidores SET IdMembresia=@IdMembresia," +
                " IdPrivilegio=@IdPrivilegio, IdEstatus=@IdEstatus, WHERE Id=@Id";

            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;

            command.Parameters.AddWithValue("@IdMembresia", pServidorModificar.Membresia.Id);
            command.Parameters.AddWithValue("@IdPrivilegio", pServidorModificar.Privilegio.Id);
            command.Parameters.AddWithValue("@IdEstatus", pServidorModificar.Estatus.Id);

            return ComunDB.EjecutarComando(command);
        }
        #endregion

        #region Metodo para Eliminar un Servidor
        // Metodo para poder Eliminar un Servidor Existente
        public int EliminarServidor(ServidoresEN pServidorEliminar)
        {
            // Consulta hacia la Base de Datos
            string consulta = "DELETE FROM Servidores WHERE Id=@Id";
            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;

            command.Parameters.AddWithValue("@Id", pServidorEliminar.Id);

            return ComunDB.EjecutarComando(command);
        }
        #endregion
    }
}
