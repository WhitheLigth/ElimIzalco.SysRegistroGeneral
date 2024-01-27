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
// REFERENCIAS NECESARIAS PARA EL CORRRECTO FUNCIONAMIENTO
using System.Windows;
using ElimIzalco.SysRegistroGeneral.UI.Vistas_Membresia;
using ElimIzalco.SysRegistroGeneral.UI.Vistas_Servidores;

namespace ElimIzalco.SysRegistroGeneral.UI.Vista_General_Administrador
{
    /// <summary>
    /// Lógica de interacción para VistaGeneralAdmin.xaml
    /// </summary>
    public partial class VistaGeneralAdmin : Window
    {
        public VistaGeneralAdmin()
        {
            InitializeComponent();

            // Deshabilitamos el Boton de Maximizar
            this.ResizeMode = ResizeMode.CanMinimize;
        }
        // Metodo para Limpiar la Ventana Principal
        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            FrameContenido.Content = null;
        }
        // Metodo Para Navegar a la Pagina de Membresia
        private void btnMembresia_Click(object sender, RoutedEventArgs e)
        {
            FrameContenido.NavigationService.Navigate(new BuscarVerMembresia());
        }
        // Metodo Para Navegar a la Pagina de Servidores
        private void btnServidor_Click(object sender, RoutedEventArgs e)
        {
            FrameContenido.NavigationService.Navigate(new BuscarVerServidores());
        }
    }
}
