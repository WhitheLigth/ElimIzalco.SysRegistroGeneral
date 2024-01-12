using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_En_Agua;
using ElimIzalco.SysRegistroGeneral.EN.Celula;
using ElimIzalco.SysRegistroGeneral.EN.Distrito;
using ElimIzalco.SysRegistroGeneral.EN.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using ElimIzalco.SysRegistroGeneral.EN.Lista_de_Calendario;
using ElimIzalco.SysRegistroGeneral.EN.Pastores;
using ElimIzalco.SysRegistroGeneral.EN.Sector;
using ElimIzalco.SysRegistroGeneral.EN.Sexo;
using ElimIzalco.SysRegistroGeneral.EN.Supervisores;
using ElimIzalco.SysRegistroGeneral.EN.Zona;
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo;
using ElimIzalco.SysRegistroGeneral.EN.Profesion_u_Oficio;

namespace ElimIzalco.SysRegistroGeneral.DAL.Membresia
{
    public class MembresiaDAL
    {
        #region Metodo para Validar la Existencia de Membresia
        // Metodo para Validar la Existencia de la Membresia
        public int ValidarExistenciaMembresia(MembresiaEN pMembresia)
        {
            // Accedemos al metodo ObtenerMembresia y pedimos que nos muestre el primer resultado que encuentre
            var membresias = ObtenerMembresia();
            var membresia = membresias.FirstOrDefault(c => c.Dui == pMembresia.Dui);
            
            // Validamos que si membresia es diferente que null devuelva un -1 si no un 0
            if (membresia != null)
            {
                // Significa que si Existe
                return -1;
            }
            else
            {
                // Significa que no Existe
                return 0;
            }
        }
        #endregion

        #region Metodo para Guardar una Membresia
        // Metodo para Guardar una Membresia a la Base de Datos
        public int GuardarMembresia(MembresiaEN pMembresiaGuardar)
        {
            // Accedemos al metodo ObtenerMembresia y pedimos que nos muestre el primer resultado que encuentre
            var membresias = ObtenerMembresia();
            var membresia = membresias.FirstOrDefault(c => c.Dui == pMembresiaGuardar.Dui);

            // Validamos que si membresia es diferente que null devuelva un 0
            if (membresia != null)
            {
                // Significa que no Existe
                return 0;
            }

            // Consulta hacia la Base de Datos
            string consultaSQL = "INSERT INTO Membresia (Nombre, Apellido, Dui, FechaNacimiento, Edad, Direccion, Telefono," +
                " LugarDeTrabajo, TelefonoDelTrabajo, FechaConversion, LugarDeConversion, Digito, NombreLider, Observaciones, " +
                "FechaCreacion, Fotografia, IdSexo, IdEstatus, IdEstadoCivil, IdBautizmoEnAgua, IdBautizmoEspirituSanto," +
                " IdListaCalendario, IdNombrePastor, IdNombreSupervisor, IdDistrito, IdZona, IdSector, IdCelula, ProfesionUOficio)" +
                " VALUES (@Nombre, @Apellido, @Dui, @FechaNacimiento, @Edad, @Direccion, @Telefono, @LugarDeTrabajo, @TelefonoDelTrabajo," +
                " @FechaConversion, @LugarDeConversion, @Digito, @NombreLider, @Observaciones, @FechaCreacion," +
                "@Fotografia, @IdSexo, @IdEstatus, @IdEstadoCivil, @IdBautizmoEnAgua, @IdBautizmoEspirituSanto, @IdListaCalendario," +
                " @IdNombrePastor, @IdNombreSupervisor, @IdDistrito, @IdZona, @IdSector, @IdCelula, @ProfesionUOficio)";

            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            // Asignacion de columnas
            command.Parameters.AddWithValue("@Nombre", pMembresiaGuardar.Nombre);
            command.Parameters.AddWithValue("@Apellido", pMembresiaGuardar.Apellido);
            command.Parameters.AddWithValue("@Dui", pMembresiaGuardar.Dui);
            command.Parameters.AddWithValue("@FechaNacimiento", pMembresiaGuardar.FechaNacimiento);
            command.Parameters.AddWithValue("@Edad", pMembresiaGuardar.Edad);
            command.Parameters.AddWithValue("@Direccion", pMembresiaGuardar.Direccion);
            command.Parameters.AddWithValue("@Telefono", pMembresiaGuardar.Telefono);
            command.Parameters.AddWithValue("@LugarDeTrabajo", pMembresiaGuardar.LugarDeTrabajo);
            command.Parameters.AddWithValue("@TelefonoDelTrabajo", pMembresiaGuardar.TelefonoDelTrabajo);
            command.Parameters.AddWithValue("@FechaConversion", pMembresiaGuardar.FechaConversion);
            command.Parameters.AddWithValue("@LugarDeConversion", pMembresiaGuardar.LugarDeConversion);
            command.Parameters.AddWithValue("@Digito", pMembresiaGuardar.Digito);
            command.Parameters.AddWithValue("@NombreLider", pMembresiaGuardar.NombreLider);
            command.Parameters.AddWithValue("@Observaciones", pMembresiaGuardar.Observaciones);
            command.Parameters.AddWithValue("@FechaCreacion", pMembresiaGuardar.FechaCreacion);
            command.Parameters.AddWithValue("@Fotografia", pMembresiaGuardar.Fotografia);
            command.Parameters.AddWithValue("@IdSexo", pMembresiaGuardar.Sexo.Id);
            command.Parameters.AddWithValue("@IdEstatus", pMembresiaGuardar.Estatus.Id);
            command.Parameters.AddWithValue("@IdEstadoCivil", pMembresiaGuardar.EstadoCivil.Id);
            command.Parameters.AddWithValue("@IdBautizmoEnAgua", pMembresiaGuardar.BautizmoEnAgua.Id);
            command.Parameters.AddWithValue("@IdBautizmoEspirituSanto", pMembresiaGuardar.BautizmoDelEspirituSanto.Id);
            command.Parameters.AddWithValue("@IdListaCalendario", pMembresiaGuardar.ListaCalendario.Id);
            command.Parameters.AddWithValue("@IdNombrePastor", pMembresiaGuardar.Pastores.Id);
            command.Parameters.AddWithValue("@IdNombreSupervisor", pMembresiaGuardar.Supervisor.Id);
            command.Parameters.AddWithValue("@IdDistrito", pMembresiaGuardar.Distrito.Id);
            command.Parameters.AddWithValue("@IdZona", pMembresiaGuardar.Zona.Id);
            command.Parameters.AddWithValue("@IdSector", pMembresiaGuardar.Sector.Id);
            command.Parameters.AddWithValue("@IdCelula", pMembresiaGuardar.Celula.Id);
            command.Parameters.AddWithValue("@ProfesionUOficio", pMembresiaGuardar.ProfesionUOficio);
            return ComunDB.EjecutarComando(command);
        }
        #endregion

        #region Metodo para Modificar una Membresia
        // Metodo para Modificar una Membresia en base de datos conforme al Id Proporcionado
        public int ModificarMembresia(MembresiaEN pMembresiaModificar)
        {
            // Consulta hacia la Base de Datos
            string consultaSQL = "UPDATE Membresia SET Nombre = @Nombre, Apellido = @Apellido, Dui = @Dui, FechaNacimiento = @FechaNacimiento, Edad = @Edad, " +
                "Direccion = @Direccion, Telefono = @Telefono, LugarDeTrabajo = @LugarDeTrabajo, TelefonoDelTrabajo = @TelefonoDelTrabajo, " +
                "FechaConversion = @FechaConversion, LugarDeConversion = @LugarDeConversion, Digito = @Digito, NombreLider = @NombreLider, " +
                "Observaciones = @Observaciones, FechaCreacion = @FechaCreacion, FechaModificacion = @FechaModificacion, Fotografia = @Fotografia, " +
                "IdSexo = @IdSexo, IdEstatus = @IdEstatus, IdEstadoCivil = @IdEstadoCivil, IdBautizmoEnAgua = @IdBautizmoEnAgua, " +
                "IdBautizmoEspirituSanto = @IdBautizmoEspirituSanto, IdListaCalendario = @IdListaCalendario, IdNombrePastor = @IdNombrePastor, " +
                "IdNombreSupervisor = @IdNombreSupervisor, IdDistrito = @IdDistrito, IdZona = @IdZona, IdSector = @IdSector, IdCelula = @IdCelula, " +
                "IdProfesionUOficio = @IdProfesionUOficio WHERE Id = @Id";

            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            // Asignacion de columnas
            command.Parameters.AddWithValue("@Id", pMembresiaModificar.Id);
            command.Parameters.AddWithValue("@Nombre", pMembresiaModificar.Nombre);
            command.Parameters.AddWithValue("@Apellido", pMembresiaModificar.Apellido);
            command.Parameters.AddWithValue("@Dui", pMembresiaModificar.Dui);
            command.Parameters.AddWithValue("@FechaNacimiento", pMembresiaModificar.FechaNacimiento);
            command.Parameters.AddWithValue("@Edad", pMembresiaModificar.Edad);
            command.Parameters.AddWithValue("@Direccion", pMembresiaModificar.Direccion);
            command.Parameters.AddWithValue("@Telefono", pMembresiaModificar.Telefono);
            command.Parameters.AddWithValue("@LugarDeTrabajo", pMembresiaModificar.LugarDeTrabajo);
            command.Parameters.AddWithValue("@TelefonoDelTrabajo", pMembresiaModificar.TelefonoDelTrabajo);
            command.Parameters.AddWithValue("@FechaConversion", pMembresiaModificar.FechaConversion);
            command.Parameters.AddWithValue("@LugarDeConversion", pMembresiaModificar.LugarDeConversion);
            command.Parameters.AddWithValue("@Digito", pMembresiaModificar.Digito);
            command.Parameters.AddWithValue("@NombreLider", pMembresiaModificar.NombreLider);
            command.Parameters.AddWithValue("@Observaciones", pMembresiaModificar.Observaciones);
            command.Parameters.AddWithValue("@FechaCreacion", pMembresiaModificar.FechaCreacion);
            command.Parameters.AddWithValue("@Fotografia", pMembresiaModificar.Fotografia);
            command.Parameters.AddWithValue("@IdSexo", pMembresiaModificar.Sexo.Id);
            command.Parameters.AddWithValue("@IdEstatus", pMembresiaModificar.Estatus.Id);
            command.Parameters.AddWithValue("@IdEstadoCivil", pMembresiaModificar.EstadoCivil.Id);
            command.Parameters.AddWithValue("@IdBautizmoEnAgua", pMembresiaModificar.BautizmoEnAgua.Id);
            command.Parameters.AddWithValue("@IdBautizmoEspirituSanto", pMembresiaModificar.BautizmoDelEspirituSanto.Id);
            command.Parameters.AddWithValue("@IdListaCalendario", pMembresiaModificar.ListaCalendario.Id);
            command.Parameters.AddWithValue("@IdNombrePastor", pMembresiaModificar.Pastores.Id);
            command.Parameters.AddWithValue("@IdNombreSupervisor", pMembresiaModificar.Supervisor.Id);
            command.Parameters.AddWithValue("@IdDistrito", pMembresiaModificar.Distrito.Id);
            command.Parameters.AddWithValue("@IdZona", pMembresiaModificar.Zona.Id);
            command.Parameters.AddWithValue("@IdSector", pMembresiaModificar.Sector.Id);
            command.Parameters.AddWithValue("@IdCelula", pMembresiaModificar.Celula.Id);
            command.Parameters.AddWithValue("@ProfesionUOficio", pMembresiaModificar.ProfesionUOficio);
            return ComunDB.EjecutarComando(command);
        }
        #endregion

        #region Metodo para Eliminar una Membresia
        // Metodo para Eliminar una Membresia en base de datos conforme al Id Proporcionado
        public int EliminarMembresia(MembresiaEN pMembresiaEliminar)
        {
            // Consulta hacia la Base de Datos
            string consultaSQL = "DELETE FROM Membresia WHERE Id=@Id";

            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            // Asignacion de columnas
            command.Parameters.AddWithValue("@Id", pMembresiaEliminar.Id);
            return ComunDB.EjecutarComando(command);
        }
        #endregion

        #region Metodo para Obtener Todas las Membresias Existentes
        // Metodo para Obtener el Listado Completo de la Membresias Existentes
        public List<MembresiaEN> ObtenerMembresia()
        {
            // Creamos una instancia de MembresiaEN para acceder a los atributos
            List<MembresiaEN> listaMembresia = new List<MembresiaEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Membresia.Id, Membresia.Nombre, Membresia.Apellido, Membresia.Dui, Membresia.FechaNacimiento, Membresia.Edad, Membresia.Direccion, " +
                "Membresia.Telefono, Membresia.LugarDeTrabajo, Membresia.TelefonoDelTrabajo, Membresia.FechaConversion, Membresia.LugarDeConversion, " +
                "Membresia.Digito, Membresia.NombreLider, Membresia.Observaciones, Membresia.FechaCreacion, Membresia.FechaModificacion, " +
                "Membresia.Fotografia, Membresia.ProfesionUOficio, " +
                "Sexo.Id, Sexo.Nombre, " +
                "Estatus.Id, Estatus.Nombre, " +
                "EstadoCivil.Id, EstadoCivil.Nombre," +
                "BautizmoEnAgua.Id, BautizmoEnAgua.Nombre," +
                "BautizmoEspirituSanto.Id, BautizmoEspirituSanto.Nombre," +
                "ListaCalendario.Id, ListaCalendario.Nombre," +
                "Pastores.Id, Pastores.Nombre," +
                "Supervisores.Id, Supervisores.Nombre," +
                "Distrito.Id, Distrito.Numero," +
                "Zona.Id, Zona.Numero," +
                "Sector.Id, Sector.Numero," +
                "Celula.Id, Celula.Numero " +

                "FROM Membresia join Sexo ON Membresia.IdSexo = Sexo.Id join Estatus ON Membresia.IdEstatus = Estatus.Id " +
                "join EstadoCivil ON Membresia.IdEstadoCivil = EstadoCivil.Id join BautizmoEnAgua ON Membresia.IdBautizmoEnAgua = BautizmoEnAgua.Id " +
                "join BautizmoEspirituSanto ON Membresia.IdBautizmoEspirituSanto = BautizmoEspirituSanto.Id " +
                "join ListaCalendario ON Membresia.IdListaCalendario = ListaCalendario.Id join Pastores ON Membresia.IdNombrePastor = Pastores.Id " +
                "join Supervisores ON Membresia.IdNombreSupervisor = Supervisores.Id join Distrito ON Membresia.IdDistrito = Distrito.Id " +
                "join Zona ON Membresia.IdZona = Zona.Id join Sector ON Membresia.IdSector = Sector.Id join Celula ON Membresia.IdCelula = Celula.Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de MembresiaEN para acceder a los atributos
                MembresiaEN ObjMembresia = new MembresiaEN();

                // Asignacion de columnas
                ObjMembresia.Id = reader.GetInt32(0);
                ObjMembresia.Nombre = reader.GetString(1);
                ObjMembresia.Apellido = reader.GetString(2);
                ObjMembresia.Dui = reader.GetString(3);
                ObjMembresia.FechaNacimiento = reader.GetDateTime(4);
                ObjMembresia.Edad = reader.GetString(5);
                ObjMembresia.Direccion = reader.GetString(6);
                ObjMembresia.Telefono = reader.GetString(7);
                ObjMembresia.LugarDeTrabajo = reader.GetString(8);
                ObjMembresia.TelefonoDelTrabajo = reader.GetString(9);
                ObjMembresia.FechaConversion = reader.GetDateTime(10);
                ObjMembresia.LugarDeConversion = reader.GetString(11);
                ObjMembresia.Digito = reader.GetString(12);
                ObjMembresia.NombreLider = reader.GetString(13);
                ObjMembresia.Observaciones = reader.GetString(14);
                ObjMembresia.FechaCreacion = reader.GetDateTime(15);
                ObjMembresia.FechaModificacion = reader.GetDateTime(16);
                ObjMembresia.Fotografia = reader.GetSqlBytes(17).Value;
                ObjMembresia.ProfesionUOficio = reader.GetString(18);
                ObjMembresia.Sexo = new SexoEN
                {
                    Id = reader.GetInt32(19),
                    Nombre = reader.GetString(20)
                };
                ObjMembresia.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(21),
                    Nombre = reader.GetString(22)
                };
                ObjMembresia.EstadoCivil = new EstadoCivilEN
                {
                    Id = reader.GetInt32(23),
                    Nombre = reader.GetString(24)
                };
                ObjMembresia.BautizmoEnAgua = new BautizmoEnAguaEN
                {
                    Id = reader.GetInt32(25),
                    Nombre = reader.GetString(26)
                };
                ObjMembresia.BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                {
                    Id = reader.GetInt32(27),
                    Nombre = reader.GetString(28)
                };
                ObjMembresia.ListaCalendario = new ListaDeCalendarioEN
                {
                    Id = reader.GetInt32(29),
                    Nombre = reader.GetString(30)
                };
                ObjMembresia.Pastores = new PastoresEN
                {
                    Id = reader.GetInt32(31),
                    Nombre = reader.GetString(32)
                };
                ObjMembresia.Supervisor = new SupervisoresEN
                {
                    Id = reader.GetInt32(33),
                    Nombre = reader.GetString(34)
                };
                ObjMembresia.Distrito = new DistritoEN
                {
                    Id = reader.GetInt32(35),
                    Numero = reader.GetString(36)
                };
                ObjMembresia.Zona = new ZonaEN
                {
                    Id = reader.GetInt32(37),
                    Numero = reader.GetString(38)
                };
                ObjMembresia.Sector = new SectorEN
                {
                    Id = reader.GetInt32(39),
                    Numero = reader.GetString(40)
                };
                ObjMembresia.Celula = new CelulaEN
                {
                    Id = reader.GetInt32(41),
                    Numero = reader.GetString(42)
                };
                listaMembresia.Add(ObjMembresia);
            }
            return listaMembresia;
        }
        #endregion

        #region Metodo para Obtener Una Membresia en Base al Id Proporcionado
        // Metodo para Obtener una lista segun el Id Proporcionado
        public MembresiaEN ObtenerMembresiaPorId(int? pId)
        {
            // Creamos una instancia de MembresiaEN para acceder a los atributos
            MembresiaEN ObjMembresia = new MembresiaEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Membresia.Id, Membresia.Nombre, Membresia.Apellido, Membresia.Dui, Membresia.FechaNacimiento, Membresia.Edad, Membresia.Direccion, " +
                "Membresia.Telefono, Membresia.LugarDeTrabajo, Membresia.TelefonoDelTrabajo, Membresia.FechaConversion, Membresia.LugarDeConversion, " +
                "Membresia.Digito, Membresia.NombreLider, Membresia.Observaciones, Membresia.FechaCreacion, Membresia.FechaModificacion, " +
                "Membresia.Fotografia, Membresia.ProfesionUOficio, " +
                "Sexo.Id, Sexo.Nombre, " +
                "Estatus.Id, Estatus.Nombre, " +
                "EstadoCivil.Id, EstadoCivil.Nombre," +
                "BautizmoEnAgua.Id, BautizmoEnAgua.Nombre," +
                "BautizmoEspirituSanto.Id, BautizmoEspirituSanto.Nombre," +
                "ListaCalendario.Id, ListaCalendario.Nombre," +
                "Pastores.Id, Pastores.Nombre," +
                "Supervisores.Id, Supervisores.Nombre," +
                "Distrito.Id, Distrito.Numero," +
                "Zona.Id, Zona.Numero," +
                "Sector.Id, Sector.Numero," +
                "Celula.Id, Celula.Numero " +

                "FROM Membresia join Sexo ON Membresia.IdSexo = Sexo.Id join Estatus ON Membresia.IdEstatus = Estatus.Id " +
                "join EstadoCivil ON Membresia.IdEstadoCivil = EstadoCivil.Id join BautizmoEnAgua ON Membresia.IdBautizmoEnAgua = BautizmoEnAgua.Id " +
                "join BautizmoEspirituSanto ON Membresia.IdBautizmoEspirituSanto = BautizmoEspirituSanto.Id " +
                "join ListaCalendario ON Membresia.IdListaCalendario = ListaCalendario.Id join Pastores ON Membresia.IdNombrePastor = Pastores.Id " +
                "join Supervisores ON Membresia.IdNombreSupervisor = Supervisores.Id join Distrito ON Membresia.IdDistrito = Distrito.Id " +
                "join Zona ON Membresia.IdZona = Zona.Id join Sector ON Membresia.IdSector = Sector.Id join Celula ON Membresia.IdCelula = Celula.Id WHERE Membresia.Id = @Id";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                ObjMembresia.Id = reader.GetInt32(0);
                ObjMembresia.Nombre = reader.GetString(1);
                ObjMembresia.Apellido = reader.GetString(2);
                ObjMembresia.Dui = reader.GetString(3);
                ObjMembresia.FechaNacimiento = reader.GetDateTime(4);
                ObjMembresia.Edad = reader.GetString(5);
                ObjMembresia.Direccion = reader.GetString(6);
                ObjMembresia.Telefono = reader.GetString(7);
                ObjMembresia.LugarDeTrabajo = reader.GetString(8);
                ObjMembresia.TelefonoDelTrabajo = reader.GetString(9);
                ObjMembresia.FechaConversion = reader.GetDateTime(10);
                ObjMembresia.LugarDeConversion = reader.GetString(11);
                ObjMembresia.Digito = reader.GetString(12);
                ObjMembresia.NombreLider = reader.GetString(13);
                ObjMembresia.Observaciones = reader.GetString(14);
                ObjMembresia.FechaCreacion = reader.GetDateTime(15);
                ObjMembresia.FechaModificacion = reader.GetDateTime(16);
                ObjMembresia.Fotografia = reader.GetSqlBytes(17).Value;
                ObjMembresia.ProfesionUOficio = reader.GetString(18);
                ObjMembresia.Sexo = new SexoEN
                {
                    Id = reader.GetInt32(19),
                    Nombre = reader.GetString(20)
                };
                ObjMembresia.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(21),
                    Nombre = reader.GetString(22)
                };
                ObjMembresia.EstadoCivil = new EstadoCivilEN
                {
                    Id = reader.GetInt32(23),
                    Nombre = reader.GetString(24)
                };
                ObjMembresia.BautizmoEnAgua = new BautizmoEnAguaEN
                {
                    Id = reader.GetInt32(25),
                    Nombre = reader.GetString(26)
                };
                ObjMembresia.BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                {
                    Id = reader.GetInt32(27),
                    Nombre = reader.GetString(28)
                };
                ObjMembresia.ListaCalendario = new ListaDeCalendarioEN
                {
                    Id = reader.GetInt32(29),
                    Nombre = reader.GetString(30)
                };
                ObjMembresia.Pastores = new PastoresEN
                {
                    Id = reader.GetInt32(31),
                    Nombre = reader.GetString(32)
                };
                ObjMembresia.Supervisor = new SupervisoresEN
                {
                    Id = reader.GetInt32(33),
                    Nombre = reader.GetString(34)
                };
                ObjMembresia.Distrito = new DistritoEN
                {
                    Id = reader.GetInt32(35),
                    Numero = reader.GetString(36)
                };
                ObjMembresia.Zona = new ZonaEN
                {
                    Id = reader.GetInt32(37),
                    Numero = reader.GetString(38)
                };
                ObjMembresia.Sector = new SectorEN
                {
                    Id = reader.GetInt32(39),
                    Numero = reader.GetString(40)
                };
                ObjMembresia.Celula = new CelulaEN
                {
                    Id = reader.GetInt32(41),
                    Numero = reader.GetString(42)
                };
            }
            return ObjMembresia;
        }
        #endregion

        #region Metodo Obtener una Membresia que Coincida o se Parezca al parametro Nombre
        // Metodo para Obtener una lista en base al parametro Nombre
        public List<MembresiaEN> ObtenerMembresiaLike(string pNombre)
        {
            // Creamos una instancia de MembresiaEN para acceder a los atributos
            List<MembresiaEN> listaMembresia = new List<MembresiaEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Id, Nombre, Apellido, Dui, FechaNacimiento, Edad, Direccion, Telefono, LugarDeTrabajo, " +
                "TelefonoDelTrabajo, FechaConversion, LugarDeConversion, Digito, NombreLider, Observaciones, FechaCreacion, FechaModificacion, " +
                "Fotografia, IdSexo, IdEstatus, IdEstadoCivil, IdBautizmoEnAgua, IdBautizmoEspirituSanto, IdListaCalendario, IdNombrePastor, " +
                "IdNombreSupervisor, IdDistrito, IdZona, IdSector, IdCelula, IdProfesionUOficio FROM Membresia WHERE Nombre = @Nombre";

            SqlCommand command = ComunDB.ObtenerComando();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Nombre", "%" + pNombre + "%"); // Se Agregan caracteres comodín para buscar coincidencias parciales

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);


            while (reader.Read())
            {
                // Creamos una instancia de MembresiaEN para acceder a los atributos
                MembresiaEN membresia = new MembresiaEN();

                // Asignacion de columnas
                membresia.Id = reader.GetInt32(0);
                membresia.Nombre = reader.GetString(1);
                membresia.Apellido = reader.GetString(2);
                membresia.Dui = reader.GetString(3);
                membresia.FechaNacimiento = reader.GetDateTime(4);
                membresia.Edad = reader.GetString(5);
                membresia.Direccion = reader.GetString(6);
                membresia.Telefono = reader.GetString(7);
                membresia.LugarDeTrabajo = reader.GetString(8);
                membresia.TelefonoDelTrabajo = reader.GetString(9);
                membresia.FechaConversion = reader.GetDateTime(10);
                membresia.LugarDeConversion = reader.GetString(11);
                membresia.Digito = reader.GetString(12);
                membresia.NombreLider = reader.GetString(13);
                membresia.Observaciones = reader.GetString(14);
                membresia.FechaCreacion = reader.GetDateTime(15);
                membresia.FechaModificacion = reader.GetDateTime(16);
                membresia.Fotografia = reader.GetSqlBytes(17).Value;
                membresia.Sexo = new SexoEN
                {
                    Id = reader.GetInt32(19),
                    Nombre = reader.GetString(20)
                };
                membresia.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(22),
                    Nombre = reader.GetString(23)
                };
                membresia.EstadoCivil = new EstadoCivilEN
                {
                    Id = reader.GetInt32(25),
                    Nombre = reader.GetString(26)
                };
                membresia.BautizmoEnAgua = new BautizmoEnAguaEN
                {
                    Id = reader.GetInt32(28),
                    Nombre = reader.GetString(29)
                };
                membresia.BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                {
                    Id = reader.GetInt32(31),
                    Nombre = reader.GetString(32)
                };
                membresia.ListaCalendario = new ListaDeCalendarioEN
                {
                    Id = reader.GetInt32(34),
                    Nombre = reader.GetString(35)
                };
                membresia.Pastores = new PastoresEN
                {
                    Id = reader.GetInt32(37),
                    Nombre = reader.GetString(38)
                };
                membresia.Supervisor = new SupervisoresEN
                {
                    Id = reader.GetInt32(40),
                    Nombre = reader.GetString(41)
                };
                membresia.Distrito = new DistritoEN
                {
                    Id = reader.GetInt32(43),
                    Numero = reader.GetString(44)
                };
                membresia.Zona = new ZonaEN
                {
                    Id = reader.GetInt32(46),
                    Numero = reader.GetString(47)
                };
                membresia.Sector = new SectorEN
                {
                    Id = reader.GetInt32(49),
                    Numero = reader.GetString(50)
                };
                membresia.Celula = new CelulaEN
                {
                    Id = reader.GetInt32(52),
                    Numero = reader.GetString(53)
                };
                membresia.ProfesionUOficio = reader.GetString(54);
                // A los atributos de la primera instancia se le asignan los datos encontrados del membresia
                listaMembresia.Add(membresia);
            }
            // Retornamos el listado
            return listaMembresia;
        }
        #endregion
    }
}
