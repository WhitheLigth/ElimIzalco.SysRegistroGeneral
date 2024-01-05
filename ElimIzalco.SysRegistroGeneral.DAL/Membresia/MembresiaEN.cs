using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElimIzalco.SysRegistroGeneral.EN.Membresia
{
    public class MembresiaEN
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dui { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Edad {  get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string LugarDeTrabajo { get; set; }
        public string TelefonoDelTrabajo { get; set; }
        public DateTime FechaConversion {  get; set; }
        public string LugarDeConversion { get; set; }
        public string Digito { get; set; }
        public string NombreLider {  get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public byte[]? Fotografia { get; set; }
        public SexoEN IdSexo {  get; set; }
        public EstatusEN IdEstatus {  get; set; }
        public EstadoCivilEN IdEstadoCivil {  get; set; }
        public BautizmoEnAguaEN IdBautizmoEnAgua {  get; set; }
        public BautizmoDelEspirituSantoEN IdBautizmoDelEspirituSanto {  get; set; }
        public ListaDeCalendarioEN IdListaCalendario {  get; set; }
        public PastoresEN  IdPastores {  get; set; }
        public SupervisoresEN IdSupervisor {  get; set; }
        public DistritoEN IdDistrito {  get; set; }
        public ZonaEN IdZona {  get; set; }
        public SectorEN IdSector {  get; set; }
        public CelulaEN IdCelula {  get; set; }
    }
}
