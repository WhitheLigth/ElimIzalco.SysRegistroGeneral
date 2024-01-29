using ElimIzalco.SysRegistroGeneral.EN.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO


namespace ElimIzalco.SysRegistroGeneral.EN.Usuarios
{
    public class UsuarioEN
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dui {  get; set; }
        public  string? Correo { get; set; }
        public string? Password { get; set; }
        public RolEN Rol {  get; set; }
    }
}
