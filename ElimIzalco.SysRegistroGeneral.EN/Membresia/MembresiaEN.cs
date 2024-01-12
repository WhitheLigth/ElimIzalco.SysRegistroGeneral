using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo;
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_En_Agua;
using ElimIzalco.SysRegistroGeneral.EN.Celula;
using ElimIzalco.SysRegistroGeneral.EN.Distrito;
using ElimIzalco.SysRegistroGeneral.EN.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using ElimIzalco.SysRegistroGeneral.EN.Lista_de_Calendario;
using ElimIzalco.SysRegistroGeneral.EN.Pastores;
using ElimIzalco.SysRegistroGeneral.EN.Profesion_u_Oficio;
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
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dui { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Edad {  get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? LugarDeTrabajo { get; set; }
        public string? TelefonoDelTrabajo { get; set; }
        public DateTime FechaConversion {  get; set; }
        public string? LugarDeConversion { get; set; }
        public string? Digito { get; set; }
        public string? NombreLider {  get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public byte[]? Fotografia { get; set; }
        public SexoEN? Sexo {  get; set; }
        public EstatusEN? Estatus {  get; set; }
        public EstadoCivilEN? EstadoCivil {  get; set; }
        public BautizmoEnAguaEN? BautizmoEnAgua {  get; set; }
        public BautizmoDelEspirituSantoEN? BautizmoDelEspirituSanto {  get; set; }
        public ListaDeCalendarioEN? ListaCalendario {  get; set; }
        public PastoresEN? Pastores {  get; set; }
        public SupervisoresEN? Supervisor {  get; set; }
        public DistritoEN? Distrito {  get; set; }
        public ZonaEN? Zona {  get; set; }
        public SectorEN? Sector {  get; set; }
        public CelulaEN? Celula {  get; set; }
        public string? ProfesionUOficio { get; set; }
    }
}
