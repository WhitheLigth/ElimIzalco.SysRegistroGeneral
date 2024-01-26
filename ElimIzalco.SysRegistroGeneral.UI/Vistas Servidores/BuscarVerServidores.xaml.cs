using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#region REFERENCIAS
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using static ElimIzalco.SysRegistroGeneral.EN.Acciones;
using System.Windows;
using System.Windows.Controls;
using ElimIzalco.SysRegistroGeneral.BL.Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Servidores;

#endregion

namespace ElimIzalco.SysRegistroGeneral.UI.Vistas_Servidores
{
    /// <summary>
    /// Lógica de interacción para BuscarVerServidores.xaml
    /// </summary>
    public partial class BuscarVerServidores : Page
    {
        public BuscarVerServidores()
        {
            InitializeComponent();
            ActualizarDataGrid();
        }

        // Creamos un Booleano Interno para Verificar Formulario Abierto
        private bool ServidorFormAbierto = false;

        // Creamos las Instancias para poder acceder a los metodos
        ServidoresBL ObjServidor = new ServidoresBL();

        // Metodo para Actualizar el DataGridView
        public void ActualizarDataGrid()
        {
            dgvMostrar_Servidores.ItemsSource = null;
            dgvMostrar_Servidores.ItemsSource = ObjServidor.ObtenerServidores();
        }

        // Evento Click para Recargar la Vista (DataGridView)
        private void btnRecargar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
        }

        #region Metodo y Eventos Click para Buscar un Servidor (Like)
        // Metodo para buscar un Servidores bajo el metodo ObtenerServidoresLike
        public void BuscarServidoresLike()
        {
            ActualizarDataGrid();

            string nombre = txtBuscarServidor.Text;

            if (!string.IsNullOrEmpty(nombre))
            {
                var servidorBl = new ServidoresBL();
                var Servidor = servidorBl.ObtenerServidorLike(nombre);

                dgvMostrar_Servidores.ItemsSource = Servidor;
            }
        }

        // Evento click para Buscar Servidores
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarServidoresLike();
        }

        // Evento TextChanged para que al ingresar un dato en el TextBox Busque Automaticamente
        private void txtBuscarServidor_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarServidoresLike();
        }

        #endregion

        #region Evento Click para Agregar
        // Evento Click para Abrir _MantenimientoServidor bajo la Accion de Crear
        private void btnAgregarServidor_Click(object sender, RoutedEventArgs e)
        {
            if (!ServidorFormAbierto)
            {
                ServidorFormAbierto = true;

                btnModificarServidor.IsEnabled = false;
                btnEliminarServidor.IsEnabled = false;
                btnVerServidor.IsEnabled = false;

                var accion = (byte)AccionEnum.Crear;
                _MantenimientoServidor AgregFormulario = new _MantenimientoServidor(null, accion);

                AgregFormulario.Closed += (s, args) =>
                {
                    ServidorFormAbierto = false;
                    btnModificarServidor.IsEnabled = true;
                    btnEliminarServidor.IsEnabled = true;
                    btnVerServidor.IsEnabled = true;
                };
                AgregFormulario.Show();
            }
            else
            {
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Abiertas", "Alerta una Ventana en Ejecucion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region Evento Click para Modificar
        // Evento Click para Abrir _MantenimientoServidor bajo la Accion de Modificar

        #endregion

        private void btnModificarServidor_Click(object sender, RoutedEventArgs e)
        {
            if (!ServidorFormAbierto)
            {
                if (dgvMostrar_Servidores.SelectedItem != null)
                {
                    ServidorFormAbierto = true;

                    btnAgregarServidor.IsEnabled = false;
                    btnEliminarServidor.IsEnabled = false;
                    btnVerServidor.IsEnabled = false;

                    ServidoresEN ServidorSeleccionado = (ServidoresEN)dgvMostrar_Servidores.SelectedItem;
                    int idServidor = ServidorSeleccionado.Id;

                    _MantenimientoServidor ModiFormulario = new _MantenimientoServidor(idServidor);

                    ModiFormulario.Closed += (s, args) =>
                    {
                        ServidorFormAbierto = false;
                        btnAgregarServidor.IsEnabled = true;
                        btnEliminarServidor.IsEnabled = true;
                        btnVerServidor.IsEnabled = true;
                    };
                    ModiFormulario.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas Abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
