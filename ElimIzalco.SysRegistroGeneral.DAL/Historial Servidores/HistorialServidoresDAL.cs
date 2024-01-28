using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFRENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.EN.Historial_Servidores;

namespace ElimIzalco.SysRegistroGeneral.DAL.Historial_Servidores
{
    public class HistorialServidoresDAL
    {
        #region Metodo para Guardar un Nuevo Registro al Historial
        // Metodo para Guardar un Servidor a la Base de Datos
        public int GuardarHistorialServidor(HistorialServidoresEN pServidorGuardarHistorial)
        {
            // Consulta hacia la Base de Datos
            string consulta = "INSERT INTO Historial_Servidores(IdMembresia, IdPrivilegios, IdEstatus) " +
                "VALUES (@IdMembresia, @IdPrivilegios, @IdEstatus)";
            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;

            command.Parameters.AddWithValue("@IdMembresia", pServidorGuardarHistorial.Membresia.Id);
            command.Parameters.AddWithValue("@IdPrivilegios", pServidorGuardarHistorial.Privilegio.Id);
            command.Parameters.AddWithValue("@IdEstatus", pServidorGuardarHistorial.Estatus.Id);

            return ComunDB.EjecutarComando(command);
        }
        #endregion
    }
}
