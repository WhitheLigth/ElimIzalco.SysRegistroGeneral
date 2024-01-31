using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Windows;
using ElimIzalco.SysRegistroGeneral.BL.Usuarios;
using ElimIzalco.SysRegistroGeneral.EN.Usuarios;
using ElimIzalco.SysRegistroGeneral.UI.Vista_General_Administrador;


namespace ElimIzalco.SysRegistroGeneral.UI.Login
{
    /// <summary>
    /// Lógica de interacción para InicioDeSesion.xaml
    /// </summary>
    public partial class InicioDeSesion : Window
    {
        public InicioDeSesion()
        {
            InitializeComponent();
            // Deshabilitamos el Boton de Maximizar
            this.ResizeMode = ResizeMode.CanMinimize;
        }

        // Evento Click para Iniciar Sesion
        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            var ObjUsuario = new UsuarioEN
            {
                Correo = txtCorreoElectronico.Text,
                Password = txtPassw.Password
            };

            // Validamos que ObjUsuario sea diferente de null
            if (ObjUsuario != null)
            {
                // Accedemos al método de Validación de Usuario de la Capa BL
                var ObjUsuarioBL = new UsuarioBL();
                var (result, usuario) = ObjUsuarioBL.ValidarExistenciaUsuario(ObjUsuario);

                // Validamos si es igua a Cero o igual a -1
                if (result == 0)
                {
                    // Usuario no encontrado
                    MessageBox.Show("Usuario no encontrado. Verifica tus credenciales.");

                    // Procedemos a Mostrar las Alertas
                    lblAlertaVuelveAIntentarloSuperior.Visibility = Visibility.Visible;
                    lblAlertaVuelveAIntentarloInferior.Visibility = Visibility.Visible;

                    // Limpiar el contenido de la contraseña
                    txtPassw.Password = string.Empty;
                    // Retornamos de Vuelta a la Vista
                    return;
                }
                else if (result == -1)
                {
                    // Usuario encontrado
                    MessageBox.Show($"Inicio de sesión exitoso.\nBienvenido: {usuario.Nombre} {usuario.Apellido}");

                    // Abrir nueva ventana
                    VistaGeneralAdmin vistaAdmin = new VistaGeneralAdmin();
                    vistaAdmin.Show();

                    // Cerrar el formulario actual
                    Close();
                }

            }
        }
    }
}
