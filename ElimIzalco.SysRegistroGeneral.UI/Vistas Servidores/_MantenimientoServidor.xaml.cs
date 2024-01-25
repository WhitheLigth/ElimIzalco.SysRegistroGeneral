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
#region REFERENCIAS
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Windows;
using ElimIzalco.SysRegistroGeneral.BL.Membresia;
using static ElimIzalco.SysRegistroGeneral.EN.Acciones;
using ElimIzalco.SysRegistroGeneral.BL.Estatus;
using ElimIzalco.SysRegistroGeneral.BL.Privilegios;
using ElimIzalco.SysRegistroGeneral.BL.Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using System.IO;
#endregion

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
            CargarEstatus();
            CargarPrivilegio();
        }

        #region Metodos para Cargar ComboBox's
        // Metodo para Cargar el Cbx de Estatus
        public void CargarEstatus()
        {
            var estatusBl = new EstatusBL();
            var estatus = estatusBl.ObtenerEstatus();

            cbxEstatus.ItemsSource = estatus;

            cbxEstatus.DisplayMemberPath = "Nombre";
            cbxEstatus.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el Cbx de Privilegio
        public void CargarPrivilegio()
        {
            var privilegioBl = new PrivilegiosBL();
            var privilegio = privilegioBl.ObtenerPrivilegio();

            cbxPrivilegio.ItemsSource = privilegio;

            cbxPrivilegio.DisplayMemberPath = "Nombre";
            cbxPrivilegio.SelectedValuePath = "Ids";
        }
        #endregion

        // Creacion de Instancias para Acceder a los metodos
        MembresiaBL ObjMembresia = new MembresiaBL();

        // Metodo para Cargar el DataGridView de Membresia
        public void ActualizarDataGridMembresia()
        {
            dgvListaMiembros.ItemsSource = null;
            dgvListaMiembros.ItemsSource = ObjMembresia.ObtenerMembresia();
        }

        #region Metodo para Buscar Usando el Metodo Like y Seleccionarlo con el Boton de Confirmacion
        // Metodo para Buscar un Miembro en base al contenido del textBox txtBuscarMiembro
        public void BuscarMiembroLike()
        {
            // Llamamos el metodo para actualizar el DataGridView 
            ActualizarDataGridMembresia();

            // Le asignamos a la Variable busqueda el contenido del TextBox de la vista Grafica
            string busqueda = txtBuscarMiembro.Text;

            if(!string.IsNullOrEmpty(busqueda))
            {
                // Creamos una variable para poder acceder a los metodos de Membresia
                var membresiaBl = new MembresiaBL();
                // Accedemos al metodo de ObtenerMembresiaLike para buscar en base a la variable busqueda y le asignamos la variable Membresia
                var Membresia = membresiaBl.ObtenerMembresiaLike(busqueda);
                // Mostramos en el DataGridView los resultados obtenidos en la Varibale Membresia
                dgvListaMiembros.ItemsSource = Membresia;
            }
        }
        // Evento TextChanged para buscar un Miembro bajo el metodo Like
        private void txtBuscarMiembro_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Llamamos el metodo BuscarMiembroLike
            BuscarMiembroLike();
        }
        // Metodo Click para Confirmar la Seleccion del DataGridView
        private void btnConfirmarMiembro_Click(object sender, RoutedEventArgs e)
        {
            // Validamos que la seleccion del DGV sea diferente de NULL
            if(dgvListaMiembros.SelectedItem != null)
            {
                // Obtenemos la Membresia seleccionada del DataGridView
                MembresiaEN membresiaSeleccionada = (MembresiaEN)dgvListaMiembros.SelectedItem;

                // Llenamos los TextBox y ComboBox con la informacion Obtenida
                txtIdMembresia.Text = Convert.ToString(membresiaSeleccionada.Id);
                txtNombre.Text = membresiaSeleccionada.Nombre;
                txtApellidos.Text = membresiaSeleccionada.Apellido;
                txtEdad.Text = membresiaSeleccionada.Edad;
                txtDui.Text = membresiaSeleccionada.Dui;

                cbxSexo.SelectedValue = membresiaSeleccionada.Sexo.Id;
                cbxSexo.DisplayMemberPath = "Nombre";
                cbxSexo.SelectedValuePath = "Id";
                cbxEstadoCivil.SelectedValue = membresiaSeleccionada.EstadoCivil.Id;
                cbxEstadoCivil.DisplayMemberPath = "Nombre";
                cbxEstadoCivil.SelectedValuePath = "Id";
                cbxBautizmoEnEspirituSanto.SelectedValue = membresiaSeleccionada.BautizmoDelEspirituSanto.Id;
                cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                cbxNombreDelPastor.SelectedValue = membresiaSeleccionada.Pastores.Id;
                cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                cbxNombreDelPastor.SelectedValuePath = "Id";
                cbxNombreDelSupervisor.SelectedValue = membresiaSeleccionada.Supervisor.Id;
                cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                cbxNombreDelSupervisor.SelectedValuePath = "Id";
                cbxZona.SelectedValue = membresiaSeleccionada.Zona.Id;
                cbxZona.DisplayMemberPath = "Numero";
                cbxZona.SelectedValuePath = "Id";
                cbxDistrito.SelectedValue = membresiaSeleccionada.Distrito.Id;
                cbxDistrito.DisplayMemberPath = "Numero";
                cbxDistrito.SelectedValuePath = "Id";
                cbxSector.SelectedValue = membresiaSeleccionada.Sector.Id;
                cbxSector.DisplayMemberPath = "Numero";
                cbxSector.SelectedValuePath = "Id";
                cbxCelula.SelectedValue = membresiaSeleccionada.Celula.Id;
                cbxCelula.DisplayMemberPath = "Numero";
                cbxCelula.SelectedValuePath = "Id";

                // Obtener los bytes de una imagen de la membresía (si existen).
                byte[]? ImagenBytes = membresiaSeleccionada.Fotografia;

                // Validamos si existen bytes de imagen y si la longitud es mayor que cero.
                if (ImagenBytes != null && ImagenBytes.Length > 0)
                {
                    // Crear un flujo de memoria a partir de los bytes de la imagen.
                    using (MemoryStream stream = new MemoryStream(ImagenBytes))
                    {
                        // Crear una nueva instancia de BitmapImage para mostrar la imagen.
                        BitmapImage bitmapImage = new BitmapImage();
                        // Iniciar la inicialización del BitmapImage.
                        bitmapImage.BeginInit();
                        // Establecer el flujo de memoria como origen para el BitmapImage.
                        bitmapImage.StreamSource = new MemoryStream(ImagenBytes);
                        // Finalizar la inicialización del BitmapImage.
                        bitmapImage.EndInit();
                        // Asignar la imagen al control de imagen 'imgFoto'.
                        imgFoto.Source = bitmapImage;
                    }
                }
                // Desseleccionamos todas las Filas del DataGridview
                dgvListaMiembros.UnselectAll();
                // Limpiamos el campo txtBuscarProfesionUOficio
                txtBuscarMiembro.Text = string.Empty;
            }
        }
        #endregion

    }
}
