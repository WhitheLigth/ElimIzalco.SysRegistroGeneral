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
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Windows;
using System.Windows.Controls;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using ElimIzalco.SysRegistroGeneral.UI.Vista_General_Administrador;
using static ElimIzalco.SysRegistroGeneral.EN.Acciones;
using ElimIzalco.SysRegistroGeneral.BL.Membresia;

namespace ElimIzalco.SysRegistroGeneral.UI.Vistas_Membresia
{
    /// <summary>
    /// Lógica de interacción para BuscarVerMembresia.xaml
    /// </summary>
    public partial class BuscarVerMembresia : Page
    {
        public BuscarVerMembresia()
        {
            InitializeComponent();
            ActualizarDataGrid();
        }
        // Declaramos un Booliano para la Accion de Desahabilitar Botones Bajo Cualqueir Acccion Declara en Cada Metodo
        private bool MembresiaFormAbierto = false;

        //Creamos una Instancia de la Ventana Principal para acceder a sus Componentes
        VistaGeneralAdmin VentanaPrincipal = new VistaGeneralAdmin();

        // Creamos una Instancia de la Clase MembresiaBL
        MembresiaBL ObjMembresiaBL = new MembresiaBL();
        
        // Metodo Para Actualizar el DataGrid
        public void ActualizarDataGrid()
        {
            dgvMostrar_Membresias.ItemsSource = null;
            dgvMostrar_Membresias.ItemsSource = ObjMembresiaBL.ObtenerMembresia();
        }

        #region Evento Click para Mostrar el Formulario para Agregar
        // Metodo para Navegar a la Vista de _MantenimientoMembresia Bajo la Accion de Agregar
        private void btnAgregarMembresia_Click(object sender, RoutedEventArgs e)
        {
            // Validamos si el Formulario esta abierto
            if (!MembresiaFormAbierto)
            {
                // Actualizos el estado del Booliano a true refiriendo que la ventana esta Abierta y Deshabilitamos los siguientes botones
                MembresiaFormAbierto = true;
                btnModificarMembresia.IsEnabled = false;
                btnEliminarMembresia.IsEnabled = false;
                btnVerMembresia.IsEnabled = false;
                // Ademas de Deshabilitar los siguientes Botontes de la Ventana Principal
                VentanaPrincipal.btnInicio.IsEnabled = false;
                VentanaPrincipal.btnMembresia.IsEnabled = false;
                VentanaPrincipal.btnLagout.IsEnabled = false;

                // Incrustamos la variable accion que Usara el AccionEnum Declarado en la capa de Entidades Bajo la Accion de Crear
                var accion = (byte)AccionEnum.Crear;
                // Instancia para Crear y Mostrar la Pagina _MantenimientoMembresia
                _MantenimientoMembresia AgregFormulario = new _MantenimientoMembresia(null, accion);

                // Acciones al cerrar el formulario de mantenimiento.
                AgregFormulario.Closed += (s, args) =>
                {
                    // Actualizos el estado del Booliano a false refiriendo que la ventana esta Cerrada y Habilitamos los siguientes botones
                    MembresiaFormAbierto = false;
                    btnModificarMembresia.IsEnabled = true;
                    btnEliminarMembresia.IsEnabled = true;
                    btnVerMembresia.IsEnabled = true;
                    // Ademas de Habilitar los siguientes Botontes de la Ventana Principal
                    VentanaPrincipal.btnInicio.IsEnabled = true;
                    VentanaPrincipal.btnMembresia.IsEnabled = true;
                    VentanaPrincipal.btnLagout.IsEnabled = true;
                };
                // Mostrar el formulario de mantenimiento.
                AgregFormulario.Show();
            }
            else
            {
                // Ventana Emergente
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Abiertas", "Alerta una Ventana en Ejecucion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region Evento Click para Mostrar el Formulario de Modificar
        private void btnModificarMembresia_Click(object sender, RoutedEventArgs e)
        {
            // Validamos si el Formulario esta abierto
            if (!MembresiaFormAbierto)
            {
                // Validamos que si la seleccion del dgv es Diferente a null
                if (dgvMostrar_Membresias.SelectedItem != null)
                {
                    // Actualizos el estado del Booliano a true refiriendo que la ventana esta Abierta y Deshabilitamos los siguientes botones
                    MembresiaFormAbierto = true;
                    btnAgregarMembresia.IsEnabled = false;
                    btnEliminarMembresia.IsEnabled = false;
                    btnVerMembresia.IsEnabled = false;
                    // Ademas de Deshabilitar los siguientes Botontes de la Ventana Principal
                    VentanaPrincipal.btnInicio.IsEnabled = false;
                    VentanaPrincipal.btnMembresia.IsEnabled = false;
                    VentanaPrincipal.btnLagout.IsEnabled = false;

                    // Obtenemos la membresía seleccionada desde el DataGridView y extraemos su ID.
                    MembresiaEN MembresiaSeleccionada = (MembresiaEN)dgvMostrar_Membresias.SelectedItem;
                    int idMembresia = MembresiaSeleccionada.Id;

                    // Creamos una instancia de la Ventana _MantenimientoMembresia para mostrar la Informacion seleccionada utilizando su ID.
                    _MantenimientoMembresia ModiFormulario = new _MantenimientoMembresia(idMembresia);

                    // Acciones al cerrar el formulario de mantenimiento.
                    ModiFormulario.Closed += (s, args) =>
                    {
                        // Actualizos el estado del Booliano a false refiriendo que la ventana esta Cerrada y Habilitamos los siguientes botones
                        MembresiaFormAbierto = false;
                        btnAgregarMembresia.IsEnabled = true;
                        btnEliminarMembresia.IsEnabled = true;
                        btnVerMembresia.IsEnabled = true;
                        // Ademas de Habilitar los siguientes Botontes de la Ventana Principal
                        VentanaPrincipal.btnInicio.IsEnabled = true;
                        VentanaPrincipal.btnMembresia.IsEnabled = true;
                        VentanaPrincipal.btnLagout.IsEnabled = true;
                    };
                    // Mostrar el formulario de mantenimiento.
                    ModiFormulario.Show();
                }
                else
                {
                    // Ventana Emergente
                    MessageBox.Show("Debes Seleccionar Al menos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                // Ventana Emergente
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Abiertas", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region Evento Click para Mostrar el Formulario de Eliminar
        private void btnEliminarMembresia_Click(object sender, RoutedEventArgs e)
        {
            // Incrustamos la variable accion que Usara el AccionEnum Declarado en la capa de Entidades Bajo la Accion de Eliminar
            byte pAccion = (byte)AccionEnum.Eliminar;

            // Validamos si el Formulario esta abierto
            if (!MembresiaFormAbierto)
            {
                // Validamos que si la seleccion del dgv es Diferente a null
                if (dgvMostrar_Membresias.SelectedItem != null)
                {
                    // Actualizos el estado del Booliano a true refiriendo que la ventana esta Abierta y Deshabilitamos los siguientes botones
                    MembresiaFormAbierto = true;
                    btnModificarMembresia.IsEnabled = false;
                    btnAgregarMembresia.IsEnabled = false;
                    btnVerMembresia.IsEnabled = false;
                    // Ademas de Deshabilitar los siguientes Botontes de la Ventana Principal
                    VentanaPrincipal.btnInicio.IsEnabled = false;
                    VentanaPrincipal.btnMembresia.IsEnabled = false;
                    VentanaPrincipal.btnLagout.IsEnabled = false;

                    // Obtenemos la membresía seleccionada desde el DataGridView y extraemos su ID.
                    MembresiaEN MembresiaSeleccionada = (MembresiaEN)dgvMostrar_Membresias.SelectedItem;
                    int idMembresia = MembresiaSeleccionada.Id;

                    // Creamos una instancia de la Ventana _MantenimientoMembresia para mostrar la Informacion seleccionada utilizando su ID.
                    _MantenimientoMembresia ElimFormulario = new _MantenimientoMembresia(idMembresia, pAccion);

                    // Acciones al cerrar el formulario de mantenimiento.
                    ElimFormulario.Closed += (s, args) =>
                    {
                        // Actualizos el estado del Booliano a false refiriendo que la ventana esta Cerrada y Habilitamos los siguientes botones
                        MembresiaFormAbierto = false;
                        btnAgregarMembresia.IsEnabled = true;
                        btnModificarMembresia.IsEnabled = true;
                        btnVerMembresia.IsEnabled = true;
                        // Ademas de Habilitar los siguientes Botontes de la Ventana Principal
                        VentanaPrincipal.btnInicio.IsEnabled = true;
                        VentanaPrincipal.btnMembresia.IsEnabled = true;
                        VentanaPrincipal.btnLagout.IsEnabled = true;
                    };
                    // Mostrar el formulario de mantenimiento.
                    ElimFormulario.Show();
                }
                else
                {
                    // Ventana Emergente
                    MessageBox.Show("Debes Seleccionar Al menos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                // Ventana Emergente
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Abiertas", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region Evento Click para Mostrar el Formulario de Visualizar
        private void btnVerMembresia_Click(object sender, RoutedEventArgs e)
        {
            // Incrustamos la variable accion que Usara el AccionEnum Declarado en la capa de Entidades Bajo la Accion de Ver
            byte pAccion = (byte)AccionEnum.Ver;

            // Validamos si el Formulario esta abierto
            if (!MembresiaFormAbierto)
            {
                // Validamos que si la seleccion del dgv es Diferente a null
                if (dgvMostrar_Membresias.SelectedItem != null)
                {
                    // Actualizos el estado del Booliano a true refiriendo que la ventana esta Abierta y Deshabilitamos los siguientes botones
                    MembresiaFormAbierto = true;
                    btnModificarMembresia.IsEnabled = false;
                    btnAgregarMembresia.IsEnabled = false;
                    btnEliminarMembresia.IsEnabled = false;
                    // Ademas de Deshabilitar los siguientes Botontes de la Ventana Principal
                    VentanaPrincipal.btnInicio.IsEnabled = false;
                    VentanaPrincipal.btnMembresia.IsEnabled = false;
                    VentanaPrincipal.btnLagout.IsEnabled = false;

                    // Obtenemos la membresía seleccionada desde el DataGridView y extraemos su ID.
                    MembresiaEN MembresiaSeleccionada = (MembresiaEN)dgvMostrar_Membresias.SelectedItem;
                    int idMembresia = MembresiaSeleccionada.Id;

                    // Creamos una instancia de la Ventana _MantenimientoMembresia para mostrar la Informacion seleccionada utilizando su ID.
                    _MantenimientoMembresia VerFromulario = new _MantenimientoMembresia(idMembresia, pAccion);

                    // Acciones al cerrar el formulario de mantenimiento.
                    VerFromulario.Closed += (s, args) =>
                    {
                        // Actualizos el estado del Booliano a false refiriendo que la ventana esta Cerrada y Habilitamos los siguientes botones
                        MembresiaFormAbierto = false;
                        btnAgregarMembresia.IsEnabled = true;
                        btnModificarMembresia.IsEnabled = true;
                        btnEliminarMembresia.IsEnabled = true;
                        // Ademas de Habilitar los siguientes Botontes de la Ventana Principal
                        VentanaPrincipal.btnInicio.IsEnabled = true;
                        VentanaPrincipal.btnMembresia.IsEnabled = true;
                        VentanaPrincipal.btnLagout.IsEnabled = true;
                    };
                    // Mostrar el formulario de mantenimiento.
                    VerFromulario.Show();
                }
                else
                {
                    // Ventana Emergente
                    MessageBox.Show("Debes Seleccionar Al menos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                // Ventana Emergente
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Abiertas", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion

        #region Evento Click para buscar una Membresia
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            // Llamamos al metodo para Actualizar el DatGridView
            ActualizarDataGrid();

            // Le asignamos a la Variable busqueda el contenido del TextBox de la vista Grafica
            string busqueda = txtBuscarMembre.Text;

            if (!string.IsNullOrEmpty(busqueda))
            {
                // Creamos la una Variable para poder acceder a los metodos de Membresia
                var membresiaBl = new MembresiaBL();
                // Accedesmos al Metodo ObtenerMembresiaLike para buscar en base al contenido de la Variable busqueda y se lo asignamos a la variable Membresia
                var Membresia = membresiaBl.ObtenerMembresiaLike(busqueda);
                // En el DataGridView Mostramos los resultados obtenidos del la Variable Membresia
                dgvMostrar_Membresias.ItemsSource = Membresia;
            }
        }
        #endregion

        #region Evento Click para Recargar el DataGridView
        private void btnRecargar_Click(object sender, RoutedEventArgs e)
        {
            // Llamamo el Metodo para Actualizar el DataGridView
            ActualizarDataGrid();
        }
        #endregion
    }
}
