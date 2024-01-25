using ElimIzalco.SysRegistroGeneral.BL.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO


namespace ElimIzalco.SysRegistroGeneral.UI.Vistas_Servidores
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoServidor.xaml
    /// </summary>
    public partial class _MantenimientoServidor : Window
    {
        // Metodo de Inicializacion para el Formulario
        public _MantenimientoServidor()
        {
            InitializeComponent();
            ActualizarDataGridMembresia();
        }

        // Creacion de Instancias para Acceder a los metodos
        MembresiaBL ObjMembresia = new MembresiaBL();

        // Metodo para Cargar el DataGridView de Membresia
        public void ActualizarDataGridMembresia()
        {
            dgvListaMiembros.ItemsSource = null;
            dgvListaMiembros.ItemsSource = ObjMembresia.ObtenerMembresia();
        }
    }
}
