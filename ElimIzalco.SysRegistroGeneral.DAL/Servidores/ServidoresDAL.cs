using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region REFERENCIAS
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Data.SqlClient;
using ElimIzalco.SysRegistroGeneral.EN.Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Sexo;
using ElimIzalco.SysRegistroGeneral.EN.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo;
using ElimIzalco.SysRegistroGeneral.EN.Pastores;
using ElimIzalco.SysRegistroGeneral.EN.Supervisores;
using ElimIzalco.SysRegistroGeneral.EN.Distrito;
using ElimIzalco.SysRegistroGeneral.EN.Zona;
using ElimIzalco.SysRegistroGeneral.EN.Sector;
using ElimIzalco.SysRegistroGeneral.EN.Celula;
using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using ElimIzalco.SysRegistroGeneral.EN.Privilegios;

#endregion

namespace ElimIzalco.SysRegistroGeneral.DAL.Servidores
{
    public class ServidoresDAL
    {
        #region Metodo para Validar Existencia del Servidor
        // Metodo para Validar si el Servidor ya esta existente
        public int ValidarExistenciaServidor(ServidoresEN pServidorValidar)
        {
            var servidores = ObtenerServidores();
            var servidor = servidores.FirstOrDefault(c => c.Membresia.Id == pServidorValidar.Membresia.Id);

            if (servidor != null)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Metodo para Guardar un Servidor
        // Metodo para Guardar un Servidor a la Base de Datos
        public int GuardarServidor(ServidoresEN pServidorGuardar)
        {
            //// Accedemos al metodo ObtenerServidor y pedimos que nos muestre el primer resultado que encuentre
            var servidores = ObtenerServidores();
            var servidor = servidores.FirstOrDefault(c => c.Id == pServidorGuardar.Id);

            // Validamos que si servidor es diferente que null devuelva un 0
            if (servidor != null)
            {
                // Significa que no Existe
                return 0;
            }

            // Consulta hacia la Base de Datos
            string consulta = "INSERT INTO Servidores(IdMembresia, IdPrivilegios, IdEstatus) " +
                "VALUES (@IdMembresia, @IdPrivilegios, @IdEstatus)";
            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;

            command.Parameters.AddWithValue("@IdMembresia", pServidorGuardar.Membresia.Id);
            command.Parameters.AddWithValue("@IdPrivilegios", pServidorGuardar.Privilegio.Id);
            command.Parameters.AddWithValue("@IdEstatus", pServidorGuardar.Estatus.Id);

            return ComunDB.EjecutarComando(command);
        }
        #endregion

        #region Metodo para Modificar un Servidor
        // Metodo para poder Modificar un Servidor Existente
        public int ModificarServidor(ServidoresEN pServidorModificar)
        {
            // Consulta hacia la Base de Datos
            string consulta = "UPDATE Servidores SET IdMembresia = @IdMembresia, IdEstatus = @IdEstatus, IdPrivilegios = @IdPrivilegios WHERE Id = @Id";

            SqlCommand command = ComunDB.ObtenerComando();
            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;

            command.Parameters.AddWithValue("@Id", pServidorModificar.Id);
            command.Parameters.AddWithValue("@IdMembresia", pServidorModificar.Membresia.Id);
            command.Parameters.AddWithValue("@IdEstatus", pServidorModificar.Estatus.Id);
            command.Parameters.AddWithValue("@IdPrivilegios", pServidorModificar.Privilegio.Id);

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

        #region Metodo para Obtener Todos los Servidores
        // Metodo para Obtener toda la lista de servidores Existentes en la Base de Datos
        public List<ServidoresEN> ObtenerServidores()
        {
            // Creamos una instancia de MembresiaEN para acceder a los atributos
            List<ServidoresEN> listaServidores = new List<ServidoresEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Servidores.Id, " +
                "Membresia.Id, Membresia.Nombre, Membresia.Apellido, Membresia.Dui, Membresia.Edad, Membresia.Fotografia, " +
                "Sexo.Id, Sexo.Nombre, " +
                "EstadoCivil.Id, EstadoCivil.Nombre, " +
                "BautizmoEspirituSanto.Id, BautizmoEspirituSanto.Nombre, " +
                "Pastores.Id, Pastores.Nombre, " +
                "Supervisores.Id, Supervisores.Nombre, " +
                "Distrito.Id, Distrito.Numero, " +
                "Zona.Id, Zona.Numero, " +
                "Sector.Id, Sector.Numero, " +
                "Celula.Id, Celula.Numero, " +
                "Estatus.Id, Estatus.Nombre, " +
                "Privilegios.Id, Privilegios.Nombre " +

                "FROM Servidores JOIN Membresia ON Servidores.IdMembresia = Membresia.Id " +
                "JOIN Sexo ON Membresia.IdSexo = Sexo.Id " +
                "JOIN EstadoCivil ON Membresia.IdEstadoCivil = EstadoCivil.Id " +
                "JOIN BautizmoEspirituSanto ON Membresia.IdBautizmoEspirituSanto = BautizmoEspirituSanto.Id " +
                "JOIN Pastores ON Membresia.IdNombrePastor = Pastores.Id " +
                "JOIN Supervisores ON Membresia.IdNombreSupervisor = Supervisores.Id " +
                "JOIN Distrito ON Membresia.IdDistrito = Distrito.Id " +
                "JOIN Zona ON Membresia.IdZona = Zona.Id " +
                "JOIN Sector ON Membresia.IdSector = Sector.Id " +
                "JOIN Celula ON Membresia.IdCelula = Celula.Id " +
                "JOIN Estatus ON Servidores.IdEstatus = Estatus.Id " +
                "JOIN Privilegios ON Servidores.IdPrivilegios = Privilegios.Id;";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            while (reader.Read())
            {
                // Creamos una nueva instancia de ServidoresEN para acceder a los atributos
                ServidoresEN ObjServidores = new ServidoresEN();

                // Asignacion de Columnas
                ObjServidores.Id = reader.GetInt32(0);
                ObjServidores.Membresia = new MembresiaEN
                {
                    Id = reader.GetInt32(1),
                    Nombre = reader.GetString(2),
                    Apellido = reader.GetString(3),
                    Dui = reader.GetString(4),
                    Edad = reader.GetString(5),
                    Fotografia = reader.GetSqlBytes(6).Value,
                    Sexo = new SexoEN
                    {
                        Id = reader.GetInt32(7),
                        Nombre = reader.GetString(8)
                    },
                    EstadoCivil = new EstadoCivilEN
                    {
                        Id = reader.GetInt32(9),
                        Nombre = reader.GetString(10)
                    },
                    BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                    {
                        Id = reader.GetInt32(11),
                        Nombre = reader.GetString(12)
                    },
                    Pastores = new PastoresEN
                    {
                        Id = reader.GetInt32(13),
                        Nombre = reader.GetString(14)
                    },
                    Supervisor = new SupervisoresEN
                    {
                        Id = reader.GetInt32(15),
                        Nombre = reader.GetString(16)
                    },
                    Distrito = new DistritoEN
                    {
                        Id = reader.GetInt32(17),
                        Numero = reader.GetString(18)
                    },
                    Zona = new ZonaEN
                    {
                        Id = reader.GetInt32(19),
                        Numero = reader.GetString(20)
                    },
                    Sector = new SectorEN
                    {
                        Id = reader.GetInt32(21),
                        Numero = reader.GetString(22)
                    },
                    Celula = new CelulaEN
                    {
                        Id = reader.GetInt32(23),
                        Numero = reader.GetString(24)
                    }
                };
                ObjServidores.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(25),
                    Nombre = reader.GetString(26)
                };
                ObjServidores.Privilegio = new PrivilegiosEN
                {
                    Id = reader.GetInt32(27),
                    Nombre = reader.GetString(28)
                };
                listaServidores.Add(ObjServidores);
            }
            // Retornamos la Lista de Servidores
            return listaServidores;
        }
        #endregion

        #region Metodo para Obtener Un Servidor en Base al Id Proporcionado
        // Metodo para Obtener una lista segun el Id Proporcionado
        public ServidoresEN ObtenerServidoresPorId(int? pId)
        {
            // Creamos una instancia de ServidoresEN para acceder a los atributos
            ServidoresEN ObjServidores = new ServidoresEN();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Servidores.Id, " +
                "Membresia.Id, Membresia.Nombre, Membresia.Apellido, Membresia.Dui, Membresia.Edad, Membresia.Fotografia, " +
                "Sexo.Id, Sexo.Nombre, " +
                "EstadoCivil.Id, EstadoCivil.Nombre, " +
                "BautizmoEspirituSanto.Id, BautizmoEspirituSanto.Nombre, " +
                "Pastores.Id, Pastores.Nombre, " +
                "Supervisores.Id, Supervisores.Nombre, " +
                "Distrito.Id, Distrito.Numero, " +
                "Zona.Id, Zona.Numero, " +
                "Sector.Id, Sector.Numero, " +
                "Celula.Id, Celula.Numero, " +
                "Estatus.Id, Estatus.Nombre, " +
                "Privilegios.Id, Privilegios.Nombre " +

                "FROM Servidores JOIN Membresia ON Servidores.IdMembresia = Membresia.Id " +
                "JOIN Sexo ON Membresia.IdSexo = Sexo.Id " +
                "JOIN EstadoCivil ON Membresia.IdEstadoCivil = EstadoCivil.Id " +
                "JOIN BautizmoEspirituSanto ON Membresia.IdBautizmoEspirituSanto = BautizmoEspirituSanto.Id " +
                "JOIN Pastores ON Membresia.IdNombrePastor = Pastores.Id " +
                "JOIN Supervisores ON Membresia.IdNombreSupervisor = Supervisores.Id " +
                "JOIN Distrito ON Membresia.IdDistrito = Distrito.Id " +
                "JOIN Zona ON Membresia.IdZona = Zona.Id " +
                "JOIN Sector ON Membresia.IdSector = Sector.Id " +
                "JOIN Celula ON Membresia.IdCelula = Celula.Id " +
                "JOIN Estatus ON Servidores.IdEstatus = Estatus.Id " +
                "JOIN Privilegios ON Servidores.IdPrivilegios = Privilegios.Id WHERE Servidores.Id = @Id";

            SqlCommand command = ComunDB.ObtenerComando();

            // Usar CommandType.Text para indicar que es una consulta directa en lugar de un procedimiento almacenado
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);

            if (reader.Read())
            {
                // Asignacion de columnas
                ObjServidores.Id = reader.GetInt32(0);
                ObjServidores.Membresia = new MembresiaEN
                {
                    Id = reader.GetInt32(1),
                    Nombre = reader.GetString(2),
                    Apellido = reader.GetString(3),
                    Dui = reader.GetString(4),
                    Edad = reader.GetString(5),
                    Fotografia = reader.GetSqlBytes(6).Value,
                    Sexo = new SexoEN
                    {
                        Id = reader.GetInt32(7),
                        Nombre = reader.GetString(8)
                    },
                    EstadoCivil = new EstadoCivilEN
                    {
                        Id = reader.GetInt32(9),
                        Nombre = reader.GetString(10)
                    },
                    BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                    {
                        Id = reader.GetInt32(11),
                        Nombre = reader.GetString(12)
                    },
                    Pastores = new PastoresEN
                    {
                        Id = reader.GetInt32(13),
                        Nombre = reader.GetString(14)
                    },
                    Supervisor = new SupervisoresEN
                    {
                        Id = reader.GetInt32(15),
                        Nombre = reader.GetString(16)
                    },
                    Distrito = new DistritoEN
                    {
                        Id = reader.GetInt32(17),
                        Numero = reader.GetString(18)
                    },
                    Zona = new ZonaEN
                    {
                        Id = reader.GetInt32(19),
                        Numero = reader.GetString(20)
                    },
                    Sector = new SectorEN
                    {
                        Id = reader.GetInt32(21),
                        Numero = reader.GetString(22)
                    },
                    Celula = new CelulaEN
                    {
                        Id = reader.GetInt32(23),
                        Numero = reader.GetString(24)
                    }
                };
                ObjServidores.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(25),
                    Nombre = reader.GetString(26)
                };
                ObjServidores.Privilegio = new PrivilegiosEN
                {
                    Id = reader.GetInt32(27),
                    Nombre = reader.GetString(28)
                };
            }
            return ObjServidores;
        }
        #endregion

        #region Metodo Obtener un Servidor que Coincida o se Parezca al parametro Nombre
        // Metodo para Obtener una lista en base al parametro Nombre
        public List<ServidoresEN> ObtenerServidoresLike(string pNombre)
        {
            // Creamos una instancia de ServidoresEN para acceder a los atributos
            List<ServidoresEN> listaServidor = new List<ServidoresEN>();

            // Consulta hacia la Base de Datos
            string consultaSQL = "SELECT Servidores.Id, " +
                "Membresia.Id, Membresia.Nombre, Membresia.Apellido, Membresia.Dui, Membresia.Edad, Membresia.Fotografia, " +
                "Sexo.Id, Sexo.Nombre, " +
                "EstadoCivil.Id, EstadoCivil.Nombre, " +
                "BautizmoEspirituSanto.Id, BautizmoEspirituSanto.Nombre, " +
                "Pastores.Id, Pastores.Nombre, " +
                "Supervisores.Id, Supervisores.Nombre, " +
                "Distrito.Id, Distrito.Numero, " +
                "Zona.Id, Zona.Numero, " +
                "Sector.Id, Sector.Numero, " +
                "Celula.Id, Celula.Numero, " +
                "Estatus.Id, Estatus.Nombre, " +
                "Privilegios.Id, Privilegios.Nombre " +

                "FROM Servidores JOIN Membresia ON Servidores.IdMembresia = Membresia.Id " +
                "JOIN Sexo ON Membresia.IdSexo = Sexo.Id " +
                "JOIN EstadoCivil ON Membresia.IdEstadoCivil = EstadoCivil.Id " +
                "JOIN BautizmoEspirituSanto ON Membresia.IdBautizmoEspirituSanto = BautizmoEspirituSanto.Id " +
                "JOIN Pastores ON Membresia.IdNombrePastor = Pastores.Id " +
                "JOIN Supervisores ON Membresia.IdNombreSupervisor = Supervisores.Id " +
                "JOIN Distrito ON Membresia.IdDistrito = Distrito.Id " +
                "JOIN Zona ON Membresia.IdZona = Zona.Id " +
                "JOIN Sector ON Membresia.IdSector = Sector.Id " +
                "JOIN Celula ON Membresia.IdCelula = Celula.Id " +
                "JOIN Estatus ON Servidores.IdEstatus = Estatus.Id " +
                "JOIN Privilegios ON Servidores.IdPrivilegios = Privilegios.Id WHERE Membresia.Nombre = @Nombre";

            SqlCommand command = ComunDB.ObtenerComando();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consultaSQL;
            command.Parameters.AddWithValue("@Nombre", "%" + pNombre + "%"); // Se Agregan caracteres comodín para buscar coincidencias parciales

            SqlDataReader reader = ComunDB.EjecutarComandoReader(command);


            while (reader.Read())
            {
                // Creamos una instancia de ServidoresEN para acceder a los atributos
                ServidoresEN ObjServidores = new ServidoresEN();

                // Asignacion de Columnas
                ObjServidores.Id = reader.GetInt32(0);
                ObjServidores.Membresia = new MembresiaEN
                {
                    Id = reader.GetInt32(1),
                    Nombre = reader.GetString(2),
                    Apellido = reader.GetString(3),
                    Dui = reader.GetString(4),
                    Edad = reader.GetString(5),
                    Fotografia = reader.GetSqlBytes(6).Value,
                    Sexo = new SexoEN
                    {
                        Id = reader.GetInt32(7),
                        Nombre = reader.GetString(8)
                    },
                    EstadoCivil = new EstadoCivilEN
                    {
                        Id = reader.GetInt32(9),
                        Nombre = reader.GetString(10)
                    },
                    BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                    {
                        Id = reader.GetInt32(11),
                        Nombre = reader.GetString(12)
                    },
                    Pastores = new PastoresEN
                    {
                        Id = reader.GetInt32(13),
                        Nombre = reader.GetString(14)
                    },
                    Supervisor = new SupervisoresEN
                    {
                        Id = reader.GetInt32(15),
                        Nombre = reader.GetString(16)
                    },
                    Distrito = new DistritoEN
                    {
                        Id = reader.GetInt32(17),
                        Numero = reader.GetString(18)
                    },
                    Zona = new ZonaEN
                    {
                        Id = reader.GetInt32(19),
                        Numero = reader.GetString(20)
                    },
                    Sector = new SectorEN
                    {
                        Id = reader.GetInt32(21),
                        Numero = reader.GetString(22)
                    },
                    Celula = new CelulaEN
                    {
                        Id = reader.GetInt32(23),
                        Numero = reader.GetString(24)
                    }
                };
                ObjServidores.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(25),
                    Nombre = reader.GetString(26)
                };
                ObjServidores.Privilegio = new PrivilegiosEN
                {
                    Id = reader.GetInt32(27),
                    Nombre = reader.GetString(28)
                };
                listaServidor.Add(ObjServidores);
            }
            // Retornamos la Lista de Servidores
            return listaServidor;
        }
        #endregion
    }
}