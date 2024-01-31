using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
#region REFERENCIAS
// REFERENCIAS NECESARIAS PARA EL FUNCIONAMIENTO
using System.Windows;
using System.Windows.Controls;
using static ElimIzalco.SysRegistroGeneral.EN.Acciones;
using ElimIzalco.SysRegistroGeneral.BL.Bautizmo_Del_Espiritu_Santo;
using ElimIzalco.SysRegistroGeneral.BL.Bautizmo_En_Agua;
using ElimIzalco.SysRegistroGeneral.BL.Celula;
using ElimIzalco.SysRegistroGeneral.BL.Distrito;
using ElimIzalco.SysRegistroGeneral.BL.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.BL.Estatus;
using ElimIzalco.SysRegistroGeneral.BL.Lista_de_Calendario;
using ElimIzalco.SysRegistroGeneral.BL.Pastores;
using ElimIzalco.SysRegistroGeneral.BL.Sector;
using ElimIzalco.SysRegistroGeneral.BL.Sexo;
using ElimIzalco.SysRegistroGeneral.BL.Supervisores;
using ElimIzalco.SysRegistroGeneral.BL.Zona;
using System.Windows.Media.Imaging;
using System.IO;
using ElimIzalco.SysRegistroGeneral.BL.Membresia;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using ElimIzalco.SysRegistroGeneral.EN.Sexo;
using ElimIzalco.SysRegistroGeneral.EN.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.EN.Profesion_u_Oficio;
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_En_Agua;
using ElimIzalco.SysRegistroGeneral.EN.Bautizmo_Del_Espiritu_Santo;
using ElimIzalco.SysRegistroGeneral.EN.Pastores;
using ElimIzalco.SysRegistroGeneral.EN.Supervisores;
using ElimIzalco.SysRegistroGeneral.EN.Lista_de_Calendario;
using ElimIzalco.SysRegistroGeneral.EN.Zona;
using ElimIzalco.SysRegistroGeneral.EN.Distrito;
using ElimIzalco.SysRegistroGeneral.EN.Sector;
using ElimIzalco.SysRegistroGeneral.EN.Celula;
using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using BarcodeStandard;
using SkiaSharp;
using Microsoft.Win32;
using ElimIzalco.SysRegistroGeneral.BL.Profesion_u_Oficio;
#endregion

namespace ElimIzalco.SysRegistroGeneral.UI.Vistas_Membresia
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoMembresia.xaml
    /// </summary>
    public partial class _MantenimientoMembresia : Window
    {
        // Esta variable privada almacena la ruta de la imagen. Se inicializa como una cadena vacía.
        private string? rutaImagen = string.Empty;

        #region Metodo de Inicializacion
        // Metodo Principal Para Inicializar
        public _MantenimientoMembresia(int? pId = null, byte? pAccion = null)
        {
            InitializeComponent();

            // Deshabilitamos el Boton de Maximizar
            this.ResizeMode = ResizeMode.CanMinimize;

            // Llamamos el metodo de ActualizarDataGrid para que se ejecute al iniciar la ventana
            ActualizarDataGrid();

            // Quitamos la Visibilidad del btnGuardarImg hasta que aparezca la img de Codebar ( El codigo de barras )
            btnGuardaImg.Visibility = Visibility.Collapsed;

            // Asigna el evento 'SelectedDateChanged' del control 'dtbFechaDeNacimiento' al manejador 'FechaNacimiento_SelectedDateChanged'.
            //dtbFechaDeNacimiento.SelectedDateChanged += FechaNacimiento_SelectedDateChanged;

            // Llamos los metodos para cargar los ComboBox para la vista  grafica al Inicializar
            CargarComboSexo();
            CargarComboEstadoCivil();
            CargarComboBautizmoEnAgua();
            CargarComboBautizmoEspirituSanto();
            CargarComboListaCalendario();
            CargarPastor();
            CargarSupervisor();
            CargarEstatus();
            CargarDistrito();
            CargarZona();
            CargarSector();
            CargarCelula();
            CargarProfesionUOficio();

            // Validamos que la variable pId sea diferente a null para que proceda
            if (pId != null)
            {
                // Llamamos el Metodo SetMembresia para que se ejecute en base al pId y la pAccion
                SetMembresia(pId, pAccion);
            }

            // Validamos que si pAccion es igual a Crear se Ejecute lo siguiente
            if (pAccion == (byte)AccionEnum.Crear)
            {
                // Procedemos a Vaciar todos los Campos para la accion de Crear
                txtNombre.Text = "";
                txtApellidos.Text = "";
                txtDui.Text = "";

                dtbFechaDeNacimiento.IsEnabled = true;
                dtbFechaDeNacimiento.SelectedDateFormat = DatePickerFormat.Long;

                txtEdad.Text = "";
                txtEdad.IsEnabled = false;
                cbxSexo.SelectedIndex = 0;
                cbxEstadoCivil.SelectedIndex = 0;
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                cbxProfesionUOficio.SelectedIndex = 0;
                txtLugarDeTrabajo.Text = "";
                txtTelefonoDelTrabajo.Text = "";

                dtFechaDeConversion.IsEnabled = true;
                dtFechaDeConversion.SelectedDateFormat = DatePickerFormat.Long;

                txtDireccionDeConversion.Text = "";
                cbxBautizmoEnAgua.SelectedIndex = 0;
                cbxBautizmoEnEspirituSanto.SelectedIndex = 0;
                cbxNombreDelPastor.SelectedIndex = 0;
                cbxNombreDelSupervisor.SelectedIndex = 0;
                txtNombreDelLider.Text = "";
                txtDigito.Text = "";
                cbxListaCalendario.SelectedIndex = 0;
                cbxZona.SelectedIndex = 0;
                cbxDistrito.SelectedIndex = 0;
                cbxSector.SelectedIndex = 0;
                cbxCelula.SelectedIndex = 0;
                cbxEstatus.SelectedIndex = 0;
                txtObservaciones.Text = "";

                dtFechaDeCreacion.SelectedDate = DateTime.Now;
                dtFechaDeCreacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaDeCreacion.IsEnabled = false;

                dtFechadeModificacion.SelectedDate = DateTime.Now;
                dtFechadeModificacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechadeModificacion.IsEnabled = false;

                // Inabilitamos los Botones Agenos a la Accion de Guardar o Crear
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
            }
        }
        #endregion

        #region Seccion de Carga de ComboBox's a La Vista Grafica
        // Metodo para Cargar el ComboBox
        private void CargarComboSexo()
        {
            var sexoBl = new SexoBL();
            var sexo = sexoBl.ObtenerSexo();

            cbxSexo.ItemsSource = sexo;
            cbxSexo.DisplayMemberPath = "Nombre";
            cbxSexo.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarComboEstadoCivil()
        {
            var estadiCivilBl = new EstadoCivilBL();
            var estadoCivil = estadiCivilBl.ObtenerEstadoCivil();

            cbxEstadoCivil.ItemsSource = estadoCivil;
            cbxEstadoCivil.DisplayMemberPath = "Nombre";
            cbxEstadoCivil.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarComboBautizmoEnAgua()
        {
            var bautizmoEnAguaBl = new BautizmoEnAguaBL();
            var bautizmoEnAgua = bautizmoEnAguaBl.ObtenerBautizmoEnAgua();

            cbxBautizmoEnAgua.ItemsSource = bautizmoEnAgua;
            cbxBautizmoEnAgua.DisplayMemberPath = "Nombre";
            cbxBautizmoEnAgua.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarComboBautizmoEspirituSanto()
        {
            var bautizmoEspirituSantoBl = new BautizmoDelEspirituSantoBL();
            var bautizmoEspirituSanto = bautizmoEspirituSantoBl.ObtenerBautizmoDelEspirituSanto();

            cbxBautizmoEnEspirituSanto.ItemsSource = bautizmoEspirituSanto;
            cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
            cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarComboListaCalendario()
        {
            var listaCalendarioBl = new ListaDeCalendarioBL();
            var listaCalendario = listaCalendarioBl.ObtenerListaCalendario();

            cbxListaCalendario.ItemsSource = listaCalendario;
            cbxListaCalendario.DisplayMemberPath = "Nombre";
            cbxListaCalendario.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarPastor()
        {
            var pastorBl = new PastoresBL();
            var pastor = pastorBl.ObtenerPastor();

            cbxNombreDelPastor.ItemsSource = pastor;
            cbxNombreDelPastor.DisplayMemberPath = "Nombre";
            cbxNombreDelPastor.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarSupervisor()
        {
            var supervisorBl = new SupervisoresBL();
            var supervisor = supervisorBl.ObtenerSupervisor();

            cbxNombreDelSupervisor.ItemsSource = supervisor;
            cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
            cbxNombreDelSupervisor.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarEstatus()
        {
            var estatusBl = new EstatusBL();
            var estatus = estatusBl.ObtenerEstatus();

            cbxEstatus.ItemsSource = estatus;
            cbxEstatus.DisplayMemberPath = "Nombre";
            cbxEstatus.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarDistrito()
        {
            var distritoBl = new DistritoBL();
            var distrito = distritoBl.ObtenerDistrito();

            cbxDistrito.ItemsSource = distrito;
            cbxDistrito.DisplayMemberPath = "Numero";
            cbxDistrito.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarZona()
        {
            var zonaBl = new ZonaBL();
            var zona = zonaBl.ObtenerZona();

            cbxZona.ItemsSource = zona;
            cbxZona.DisplayMemberPath = "Numero";
            cbxZona.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarSector()
        {
            var sectorBl = new SectorBL();
            var sector = sectorBl.ObtenerSector();

            cbxSector.ItemsSource = sector;

            cbxSector.DisplayMemberPath = "Numero";
            cbxSector.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarCelula()
        {
            var celulaBl = new CelulaBL();
            var celula = celulaBl.ObtenerCelula();

            cbxCelula.ItemsSource = celula;
            cbxCelula.DisplayMemberPath = "Numero";
            cbxCelula.SelectedValuePath = "Id";
        }
        // Metodo para Cargar el ComboBox
        private void CargarProfesionUOficio()
        {
            var profesionuoficioBl = new ProfesionUOficioBL();
            var profesionuoficio = profesionuoficioBl.ObtenerProfesionUOficio();

            cbxProfesionUOficio.ItemsSource = profesionuoficio;
            cbxProfesionUOficio.DisplayMemberPath = "Nombre";
            cbxProfesionUOficio.SelectedValuePath= "Id";
        }
        #endregion

        #region Metodo para Validar que Accion de Ver, Modificar y Elinminar se ejecuta Haciendo Uso del Parametro Id
        public void SetMembresia(int? pId, byte? pAccion)
        {
            //  Creamos una instancia de la clase MembresiaBL y Accedemos al Metodo ObtenerPorId
            var membresiaBl = new MembresiaBL();
            var membresia = membresiaBl.ObtenerPorId(pId);

            // Validamos que la variable membresia sea diferente de null que prociga
            if (membresia != null)
            {
                // Validamos que si la accion es Ver ejecute lo siguiente
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    // Procedemos a llenar todos los campos con el registro correspondiente en base al Id Proporcionado
                    // Ademas de Deshabilitar los campos para unicamente Visualizar el Registro.
                    txtIdMembresia.Text = Convert.ToString(membresia.Id);
                    txtNombre.Text = membresia.Nombre;
                    txtNombre.IsEnabled = false;
                    txtApellidos.Text =membresia.Apellido;
                    txtApellidos.IsEnabled = false;
                    txtDui.Text = membresia.Dui;
                    txtDui.IsEnabled = false;

                    dtbFechaDeNacimiento.SelectedDate = membresia.FechaNacimiento;
                    dtbFechaDeNacimiento.SelectedDateFormat = DatePickerFormat.Long;
                    dtbFechaDeNacimiento.IsEnabled = false;

                    txtEdad.Text = membresia.Edad;
                    txtEdad.IsEnabled = false;

                    cbxSexo.SelectedValue = membresia.Sexo.Id;
                    cbxSexo.DisplayMemberPath = "Nombre";
                    cbxSexo.SelectedValuePath = "Id";
                    cbxSexo.IsEnabled = false;
                    cbxEstadoCivil.SelectedValue = membresia.EstadoCivil.Id;
                    cbxEstadoCivil.DisplayMemberPath = "Nombre";
                    cbxEstadoCivil.SelectedValuePath = "Id";
                    cbxEstadoCivil.IsEnabled = false;

                    txtTelefono.Text = membresia.Telefono;
                    txtTelefono.IsEnabled = false;
                    txtDireccion.Text = membresia.Direccion;
                    txtDireccion.IsEnabled = false;

                    cbxProfesionUOficio.SelectedValue = membresia.ProfesionUOficio.Id;
                    cbxProfesionUOficio.DisplayMemberPath = "Nombre";
                    cbxProfesionUOficio.SelectedValuePath = "Id";
                    cbxProfesionUOficio.IsEnabled = false;
                    txtLugarDeTrabajo.Text = membresia.LugarDeTrabajo;
                    txtLugarDeTrabajo.IsEnabled = false;
                    txtTelefonoDelTrabajo.Text = membresia.TelefonoDelTrabajo;
                    txtTelefonoDelTrabajo.IsEnabled = false;

                    btnAgregarImg.IsEnabled = false;

                    dtFechaDeConversion.SelectedDate = membresia.FechaConversion;
                    dtFechaDeConversion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaDeConversion.IsEnabled = false;

                    txtDireccionDeConversion.Text = membresia.LugarDeConversion;
                    txtDireccionDeConversion.IsEnabled = false;

                    cbxBautizmoEnAgua.SelectedValue = membresia.BautizmoEnAgua.Id;
                    cbxBautizmoEnAgua.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnAgua.SelectedValuePath = "Id";
                    cbxBautizmoEnAgua.IsEnabled = false;
                    cbxBautizmoEnEspirituSanto.SelectedValue = membresia.BautizmoDelEspirituSanto.Id;
                    cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                    cbxBautizmoEnEspirituSanto.IsEnabled = false;
                    cbxNombreDelPastor.SelectedValue = membresia.Pastores.Id;
                    cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                    cbxNombreDelPastor.SelectedValuePath = "Id";
                    cbxNombreDelPastor.IsEnabled = false;
                    cbxNombreDelSupervisor.SelectedValue = membresia.Supervisor.Id;
                    cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                    cbxNombreDelSupervisor.SelectedValuePath = "Id";
                    cbxNombreDelSupervisor.IsEnabled = false;

                    txtNombreDelLider.Text = membresia.NombreLider;
                    txtNombreDelLider.IsEnabled = false;
                    txtDigito.Text = membresia.Digito;
                    txtDigito.IsEnabled = false;

                    cbxListaCalendario.SelectedValue = membresia.ListaCalendario.Id;
                    cbxListaCalendario.DisplayMemberPath = "Nombre";
                    cbxListaCalendario.SelectedValuePath = "Id";
                    cbxListaCalendario.IsEnabled = false;
                    cbxZona.SelectedValue = membresia.Zona.Id;
                    cbxZona.DisplayMemberPath = "Numero";
                    cbxZona.SelectedValuePath = "Id";
                    cbxZona.IsEnabled = false;
                    cbxDistrito.SelectedValue = membresia.Distrito.Id;
                    cbxDistrito.DisplayMemberPath = "Numero";
                    cbxDistrito.SelectedValuePath = "Id";
                    cbxDistrito.IsEnabled = false;
                    cbxSector.SelectedValue = membresia.Sector.Id;
                    cbxSector.DisplayMemberPath = "Numero";
                    cbxSector.SelectedValuePath = "Id";
                    cbxSector.IsEnabled = false;
                    cbxCelula.SelectedValue = membresia.Celula.Id;
                    cbxCelula.DisplayMemberPath = "Numero";
                    cbxCelula.SelectedValuePath = "Id";
                    cbxCelula.IsEnabled = false;
                    cbxEstatus.SelectedValue = membresia.Estatus.Id;
                    cbxEstatus.DisplayMemberPath = "Nombre";
                    cbxEstatus.SelectedValuePath = "Id";
                    cbxEstatus.IsEnabled = false;

                    txtObservaciones.Text = membresia.Observaciones;
                    txtObservaciones.IsEnabled = false;

                    dtFechaDeCreacion.SelectedDate = membresia.FechaCreacion;
                    dtFechaDeCreacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaDeCreacion.IsEnabled = false;
                    dtFechadeModificacion.SelectedDate = membresia.FechaModificacion;
                    dtFechadeModificacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechadeModificacion.IsEnabled = false;

                    btnGuardar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;

                    // Obtener los bytes de una imagen de la membresía (si existen).
                    byte[]? ImagenBytes = membresia.Fotografia;

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
                }
                // Validamos que si la Accion no es ver que Ejecute la siguiente accion
                else if(pAccion == (byte)AccionEnum.Eliminar)
                {
                    // Procedemos a llenar todos los campos con el registro correspondiente en base al Id Proporcionado
                    // Ademas de Deshabilitar los campos para unicamente Visualizar el Registro.
                    txtIdMembresia.Text = Convert.ToString(membresia.Id);
                    txtNombre.Text = membresia.Nombre;
                    txtNombre.IsEnabled = false;
                    txtApellidos.Text = membresia.Apellido;
                    txtApellidos.IsEnabled = false;
                    txtDui.Text = membresia.Dui;
                    txtDui.IsEnabled = false;

                    dtbFechaDeNacimiento.SelectedDate = membresia.FechaNacimiento;
                    dtbFechaDeNacimiento.SelectedDateFormat = DatePickerFormat.Long;
                    dtbFechaDeNacimiento.IsEnabled = false;

                    txtEdad.Text = membresia.Edad;
                    txtEdad.IsEnabled = false;

                    cbxSexo.SelectedValue = membresia.Sexo.Id;
                    cbxSexo.DisplayMemberPath = "Nombre";
                    cbxSexo.SelectedValuePath = "Id";
                    cbxSexo.IsEnabled = false;
                    cbxEstadoCivil.SelectedValue = membresia.EstadoCivil.Id;
                    cbxEstadoCivil.DisplayMemberPath = "Nombre";
                    cbxEstadoCivil.SelectedValuePath = "Id";
                    cbxEstadoCivil.IsEnabled = false;

                    txtTelefono.Text = membresia.Telefono;
                    txtTelefono.IsEnabled = false;
                    txtDireccion.Text = membresia.Direccion;
                    txtDireccion.IsEnabled = false;

                    cbxProfesionUOficio.SelectedValue = membresia.ProfesionUOficio.Id;
                    cbxProfesionUOficio.DisplayMemberPath = "Nombre";
                    cbxProfesionUOficio.SelectedValuePath = "Id";
                    cbxProfesionUOficio.IsEnabled = false;
                    txtLugarDeTrabajo.Text = membresia.LugarDeTrabajo;
                    txtLugarDeTrabajo.IsEnabled = false;
                    txtTelefonoDelTrabajo.Text = membresia.TelefonoDelTrabajo;
                    txtTelefonoDelTrabajo.IsEnabled = false;

                    btnAgregarImg.IsEnabled = false;

                    dtFechaDeConversion.SelectedDate = membresia.FechaConversion;
                    dtFechaDeConversion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaDeConversion.IsEnabled = false;

                    txtDireccionDeConversion.Text = membresia.LugarDeConversion;
                    txtDireccionDeConversion.IsEnabled = false;

                    cbxBautizmoEnAgua.SelectedValue = membresia.BautizmoEnAgua.Id;
                    cbxBautizmoEnAgua.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnAgua.SelectedValuePath = "Id";
                    cbxBautizmoEnAgua.IsEnabled = false;
                    cbxBautizmoEnEspirituSanto.SelectedValue = membresia.BautizmoDelEspirituSanto.Id;
                    cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                    cbxBautizmoEnEspirituSanto.IsEnabled = false;
                    cbxNombreDelPastor.SelectedValue = membresia.Pastores.Id;
                    cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                    cbxNombreDelPastor.SelectedValuePath = "Id";
                    cbxNombreDelPastor.IsEnabled = false;
                    cbxNombreDelSupervisor.SelectedValue = membresia.Supervisor.Id;
                    cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                    cbxNombreDelSupervisor.SelectedValuePath = "Id";
                    cbxNombreDelSupervisor.IsEnabled = false;

                    txtNombreDelLider.Text = membresia.NombreLider;
                    txtNombreDelLider.IsEnabled = false;
                    txtDigito.Text = membresia.Digito;
                    txtDigito.IsEnabled = false;

                    cbxListaCalendario.SelectedValue = membresia.ListaCalendario.Id;
                    cbxListaCalendario.DisplayMemberPath = "Nombre";
                    cbxListaCalendario.SelectedValuePath = "Id";
                    cbxListaCalendario.IsEnabled = false;
                    cbxZona.SelectedValue = membresia.Zona.Id;
                    cbxZona.DisplayMemberPath = "Numero";
                    cbxZona.SelectedValuePath = "Id";
                    cbxZona.IsEnabled = false;
                    cbxDistrito.SelectedValue = membresia.Distrito.Id;
                    cbxDistrito.DisplayMemberPath = "Numero";
                    cbxDistrito.SelectedValuePath = "Id";
                    cbxDistrito.IsEnabled = false;
                    cbxSector.SelectedValue = membresia.Sector.Id;
                    cbxSector.DisplayMemberPath = "Numero";
                    cbxSector.SelectedValuePath = "Id";
                    cbxSector.IsEnabled = false;
                    cbxCelula.SelectedValue = membresia.Celula.Id;
                    cbxCelula.DisplayMemberPath = "Numero";
                    cbxCelula.SelectedValuePath = "Id";
                    cbxCelula.IsEnabled = false;
                    cbxEstatus.SelectedValue = membresia.Estatus.Id;
                    cbxEstatus.DisplayMemberPath = "Nombre";
                    cbxEstatus.SelectedValuePath = "Id";
                    cbxEstatus.IsEnabled = false;

                    txtObservaciones.Text = membresia.Observaciones;
                    txtObservaciones.IsEnabled = false;

                    dtFechaDeCreacion.SelectedDate = membresia.FechaCreacion;
                    dtFechaDeCreacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaDeCreacion.IsEnabled = false;
                    dtFechadeModificacion.SelectedDate = membresia.FechaModificacion;
                    dtFechadeModificacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechadeModificacion.IsEnabled = false;

                    btnGuardar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                    btnGuardaImg.IsEnabled = false;

                    // Obtener los bytes de una imagen de la membresía (si existen).
                    byte[]? ImagenBytes = membresia.Fotografia;

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
                }
                // Si no se cumple ninguna de las Validaciones Anteriores que se ejecute la siguiente
                else
                {
                    // Procedemos a llenar todos los campos con el registro correspondiente en base al Id Proporcionado
                    // Ademas de Deshabilitar los campos para unicamente Visualizar el Registro.
                    txtIdMembresia.Text = Convert.ToString(membresia.Id);
                    txtNombre.Text = membresia.Nombre;
                    txtApellidos.Text = membresia.Apellido;
                    txtDui.Text = membresia.Dui;
                    txtDui.IsEnabled = false;

                    dtbFechaDeNacimiento.SelectedDate = membresia.FechaNacimiento;
                    dtbFechaDeNacimiento.SelectedDateFormat = DatePickerFormat.Long;

                    txtEdad.Text = membresia.Edad;
                    txtEdad.IsEnabled = false;

                    cbxSexo.SelectedValue = membresia.Sexo.Id;
                    cbxSexo.DisplayMemberPath = "Nombre";
                    cbxSexo.SelectedValuePath = "Id";
                    cbxEstadoCivil.SelectedValue = membresia.EstadoCivil.Id;
                    cbxEstadoCivil.DisplayMemberPath = "Nombre";
                    cbxEstadoCivil.SelectedValuePath = "Id";

                    txtTelefono.Text = membresia.Telefono;
                    txtDireccion.Text = membresia.Direccion;

                    cbxProfesionUOficio.SelectedValue = membresia.ProfesionUOficio.Id;
                    cbxProfesionUOficio.DisplayMemberPath = "Nombre";
                    cbxProfesionUOficio.SelectedValuePath = "Id";

                    txtLugarDeTrabajo.Text = membresia.LugarDeTrabajo;
                    txtTelefonoDelTrabajo.Text = membresia.TelefonoDelTrabajo;

                    dtFechaDeConversion.SelectedDate = membresia.FechaConversion;
                    dtFechaDeConversion.SelectedDateFormat = DatePickerFormat.Long;

                    txtDireccionDeConversion.Text = membresia.LugarDeConversion;

                    cbxBautizmoEnAgua.SelectedValue = membresia.BautizmoEnAgua.Id;
                    cbxBautizmoEnAgua.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnAgua.SelectedValuePath = "Id";
                    cbxBautizmoEnEspirituSanto.SelectedValue = membresia.BautizmoDelEspirituSanto.Id;
                    cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                    cbxNombreDelPastor.SelectedValue = membresia.Pastores.Id;
                    cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                    cbxNombreDelPastor.SelectedValuePath = "Id";
                    cbxNombreDelSupervisor.SelectedValue = membresia.Supervisor.Id;
                    cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                    cbxNombreDelSupervisor.SelectedValuePath = "Id";

                    txtNombreDelLider.Text = membresia.NombreLider;
                    txtDigito.Text = membresia.Digito;

                    cbxListaCalendario.SelectedValue = membresia.ListaCalendario.Id;
                    cbxListaCalendario.DisplayMemberPath = "Nombre";
                    cbxListaCalendario.SelectedValuePath = "Id";
                    cbxZona.SelectedValue = membresia.Zona.Id;
                    cbxZona.DisplayMemberPath = "Numero";
                    cbxZona.SelectedValuePath = "Id";
                    cbxDistrito.SelectedValue = membresia.Distrito.Id;
                    cbxDistrito.DisplayMemberPath = "Numero";
                    cbxDistrito.SelectedValuePath = "Id";
                    cbxSector.SelectedValue = membresia.Sector.Id;
                    cbxSector.DisplayMemberPath = "Numero";
                    cbxSector.SelectedValuePath = "Id";
                    cbxCelula.SelectedValue = membresia.Celula.Id;
                    cbxCelula.DisplayMemberPath = "Numero";
                    cbxCelula.SelectedValuePath = "Id";
                    cbxEstatus.SelectedValue = membresia.Estatus.Id;
                    cbxEstatus.DisplayMemberPath = "Nombre";
                    cbxEstatus.SelectedValuePath = "Id";

                    txtObservaciones.Text = membresia.Observaciones;

                    dtFechaDeCreacion.SelectedDate = membresia.FechaCreacion;
                    dtFechaDeCreacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaDeCreacion.IsEnabled = false;
                    dtFechadeModificacion.SelectedDate = DateTime.Now;
                    dtFechadeModificacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechadeModificacion.IsEnabled = false;

                    btnGuardar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                    btnGuardaImg.IsEnabled = false;

                    // Obtener los bytes de una imagen de la membresía (si existen).
                    byte[]? ImagenBytes = membresia.Fotografia;

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
                }
            }
        }
        #endregion

        // Creamos una instancia para la clase MembresiaBL y para la Vista BuscarVerMembresia ademas de la clase ProfesionUOficioBL
        MembresiaBL ObjMembresiaBL = new MembresiaBL();
        BuscarVerMembresia formMembresia = new BuscarVerMembresia();
        ProfesionUOficioBL ObjProfesionUOficio = new ProfesionUOficioBL();

        // Metodo para Actualizar el DataGridView al momento de Hacer alguna Accion de Guardar, Modificar, Eliminar o Ver
        public void ActualizarDataGrid()
        {
            formMembresia.dgvMostrar_Membresias.ItemsSource = null;
            formMembresia.dgvMostrar_Membresias.ItemsSource = ObjMembresiaBL.ObtenerMembresia();
        }

        #region Creacion de Codigo de Barras , Guardado , Mapeo de Byte[]? y Validacion para caracteres Especiales
        // metodo para Validar que unicamente se ingresen caracteres validos
        private string RemoveSpecialCharacters(string input)
        {
            // Utiliza una expresión regular para reemplazar los caracteres especiales por una cadena vacía
            return Regex.Replace(input, "[^a-zA-Z0-9.,-]", "");
        }

        // Metodo para el Mapeo de Byte[]?
        private BitmapSource ToBitmap(SKImage skImage)
        {
            using (var data = skImage.Encode()) // Codifica la imagen en formato SKData
            using (var stream = data.AsStream()) // Convierte SKData a Stream
            {
                var bitmapImage = new BitmapImage(); // Crea un nuevo objeto BitmapImage
                bitmapImage.BeginInit(); // Inicia la inicialización del objeto BitmapImage
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Establece la opción de caché en OnLoad
                bitmapImage.StreamSource = stream; // Establece el Stream de origen de la imagen
                bitmapImage.EndInit(); // Finaliza la inicialización del objeto BitmapImage
                return bitmapImage; // Devuelve el objeto BitmapImage convertido a BitmapSource
            }
        }

        // Metodo para Guardar el Codigo de Barras en Formato de PNG
        private void GuardarImagen()
        {
            // Se crea un cuadro de diálogo para guardar el archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen (*.png)|*.png";

            // Se concatena el nombre del archivo con txtDuiMembresia, txtNombre y txtApellido
            string fileName = "";
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                fileName += $"{txtNombre.Text}_";
            }
            if (!string.IsNullOrEmpty(txtApellidos.Text))
            {
                fileName += $"{txtApellidos.Text}_";
            }
            if (!string.IsNullOrEmpty(txtDui.Text))
            {
                fileName += $"{txtDui.Text}_";
            }
            if (fileName == "")
            {
                fileName = "codigo_de_barras.png"; // Si no se ingresó ningún valor en los campos, se usa un nombre predeterminado
            }
            else
            {
                fileName += "Cod.Barras.png";
            }

            saveFileDialog.FileName = fileName;

            // Si el usuario selecciona un archivo y hace clic en "Guardar"
            if (saveFileDialog.ShowDialog() == true)
            {
                // Se guarda la imagen en el archivo seleccionado
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgBarraCode.Source));
                    encoder.Save(fileStream);
                }
            }
        }

        // Evento TextChanged para que al momento de existe algun caracter en el campo txtDui se genere automaticamente el Codigo de Barras
        private void txtDui_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Se obtiene el texto ingresado y se eliminan los espacios en blanco al principio y al final
            string codigo = txtDui.Text.Trim();
            // Se eliminan los caracteres especiales, tildes, espacios y la letra "ñ"
            string cleanedCodigo = RemoveSpecialCharacters(codigo);

            // Se crea un objeto Barcode
            Barcode barcode = new Barcode();
            //Coniguracion del texto de las barras
            barcode.IncludeLabel = true;
            barcode.Alignment = AlignmentPositions.Center;
            //Dimensiones de la imagen
            int width = 446;
            int height = 119;

            // Si el texto ingresado contiene caracteres especiales, tildes, espacios o la letra "ñ"
            if (codigo != cleanedCodigo)
            {
                // Se borra la imagen del código de barras
                imgBarraCode.Source = null;
                //Ocultar botón de guardar imagen
                btnGuardaImg.Visibility = Visibility.Collapsed;
            }
            // Si el texto ingresado no contiene caracteres especiales, tildes, espacios o la letra "ñ"
            else if (!string.IsNullOrEmpty(cleanedCodigo))
            {
                // Se genera un código de barras Code 128 con el texto ingresado y se muestra en la imagen "imgBarraCode"
                SKImage barcodeImage = barcode.Encode(BarcodeStandard.Type.Code128, cleanedCodigo, width, height);
                imgBarraCode.Source = ToBitmap(barcodeImage);
                //Mostrar botón de guardar imagen
                btnGuardaImg.Visibility = Visibility.Visible;
            }
            // Si el cuadro de texto está vacío
            else
            {
                // Se borra la imagen del código de barras y se muestra un mensaje de advertencia en el label "lblWarning" con un color de fuente negro
                imgBarraCode.Source = null;
                //Ocultar botón de guardar imagen
                btnGuardaImg.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        // Evento Click para Guardar el Codigo de Barras Generado con CodeBarLab
        private void btnGuardaImg_Click(object sender, RoutedEventArgs e)
        {
            GuardarImagen();
        }

        #region Evento Click para Agregar una Imagen
        // Metodo para poder cargar una Imagen y Mapearlas a Byte[]?
        private void btnAgregarImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                rutaImagen = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(rutaImagen));
                imgFoto.Source = bitmap;
            }
        }
        #endregion

        #region Seccion para el calculo de edad en base a la Fecha de Nacimiento Proporcionada
        // Metodo para Calulcar la Edad en Base a la Fecha de Nacimiento
        private int CalcularEdad(DateTime fechaNacimiento, DateTime fechaActual)
        {
            int edad = fechaActual.Year - fechaNacimiento.Year;
            // Comprueba si aún no ha llegado su cumpleaños de este año
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }

        //Evento SelectDateChanged para Calcular automaticamente la Edad en base a la Fecha de Nacimiento
        private void dtbFechaDeNacimiento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime fechaNacimiento = dtbFechaDeNacimiento.SelectedDate ?? DateTime.MinValue;
            DateTime fechaActual = DateTime.Now;
            int edad = CalcularEdad(fechaNacimiento, fechaActual);
            txtEdad.Text = edad.ToString();
        }
        #endregion

        #region Evento Click Para guardar una nueva membresia
        // Metodo para Guardar una Membresia
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Inicializar un arreglo de bytes para almacenar una imagen, inicialmente como nulo.
            byte[]? ImagenBytes = null;

            // Validamos si la ruta de la imagen no está vacía o nula.
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                // Lee todos los bytes de la imagen en la ruta especificada.
                ImagenBytes = File.ReadAllBytes(rutaImagen);
            }

            // La Variable ObjMembresia almacenara los Atributos de la Entidad con los Datos Proporcionado en cada Campo de la Vista Grafica
            var ObjMembresia = new MembresiaEN
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellidos.Text,
                Dui = txtDui.Text,
                FechaNacimiento = dtbFechaDeNacimiento.SelectedDate.Value,
                Edad = txtEdad.Text,
                Sexo = new SexoEN
                {
                    Id = Convert.ToInt32(cbxSexo.SelectedValue),
                },
                EstadoCivil = new EstadoCivilEN
                {
                    Id = Convert.ToInt32(cbxEstadoCivil.SelectedValue),
                },
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                ProfesionUOficio = new ProfesionUOficioEN
                {
                    Id = Convert.ToInt32(cbxProfesionUOficio.SelectedValue),
                },
                LugarDeTrabajo = txtLugarDeTrabajo.Text,
                TelefonoDelTrabajo = txtTelefonoDelTrabajo.Text,
                FechaConversion = dtFechaDeConversion.SelectedDate.Value,
                LugarDeConversion = txtDireccionDeConversion.Text,
                BautizmoEnAgua = new BautizmoEnAguaEN
                {
                    Id = Convert.ToInt32(cbxBautizmoEnAgua.SelectedValue),
                },
                BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                {
                    Id = Convert.ToInt32(cbxBautizmoEnEspirituSanto.SelectedValue),
                },
                Pastores = new PastoresEN
                {
                    Id = Convert.ToInt32(cbxNombreDelPastor.SelectedValue),
                },
                Supervisor = new SupervisoresEN
                {
                    Id = Convert.ToInt32(cbxNombreDelSupervisor.SelectedValue),
                },
                NombreLider = txtNombreDelLider.Text,
                Digito = txtDigito.Text,
                ListaCalendario = new ListaDeCalendarioEN
                {
                    Id = Convert.ToInt32(cbxListaCalendario.SelectedValue),
                },
                Zona = new ZonaEN
                {
                    Id = Convert.ToInt32(cbxZona.SelectedValue),
                },
                Distrito = new DistritoEN
                {
                    Id = Convert.ToInt32(cbxDistrito.SelectedValue),
                },
                Sector = new SectorEN
                {
                    Id = Convert.ToInt32(cbxSector.SelectedValue),
                },
                Celula = new CelulaEN
                {
                    Id = Convert.ToInt32(cbxCelula.SelectedValue),
                },
                Estatus = new EstatusEN
                {
                    Id = Convert.ToInt32(cbxEstatus.SelectedValue),
                },
                Observaciones = txtObservaciones.Text,
                Fotografia = ImagenBytes,
                FechaCreacion = DateTime.Now,
            };

            // Validamos que ObjMembresia sea Diferente de NULL para continuar con lo siguiente
            if (ObjMembresia != null)
            {
                // Validamos los Campos a Ingresar O solo Numeros O Solo letras
                if (Regex.IsMatch(ObjMembresia.Nombre, ".*\\d+.*"))
                {
                    MessageBox.Show("El campo 'Nombre' no debe contener números.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtNombre.Focus();
                    return;
                }
                if (Regex.IsMatch(ObjMembresia.Apellido, ".*\\d+.*"))
                {
                    MessageBox.Show("El campo 'Apellido' no debe contener números.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtApellidos.Focus();
                    return;
                }
                if (Regex.IsMatch(ObjMembresia.NombreLider, ".*\\d+.*"))
                {
                    MessageBox.Show("El campo 'Nombre del Lider' no debe contener números.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtNombreDelLider.Focus();
                    return;
                }
                if (Regex.IsMatch(ObjMembresia.Dui, "[^0-9]"))
                {
                    MessageBox.Show("El campo 'Dui' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtDui.Focus();
                    return;
                }
                if (Regex.IsMatch(ObjMembresia.Telefono, "[^0-9]"))
                {
                    MessageBox.Show("El campo 'Telefono' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtTelefono.Focus();
                    return;
                }
                if (Regex.IsMatch(ObjMembresia.TelefonoDelTrabajo, "[^0-9]"))
                {
                    MessageBox.Show("El campo 'Telefono Del Trabajo' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtTelefonoDelTrabajo.Focus();
                    return;
                }
                if (Regex.IsMatch(ObjMembresia.Digito, "[^0-9]"))
                {
                    MessageBox.Show("El campo 'Tiempo de Congregarse' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtDui.Focus();
                    return;
                }
                // Accedemos al metodo de Validacion de Existencia de la Capa BL
                var ObjMembresiaBLL = new MembresiaBL();
                var resultt = ObjMembresiaBLL.ValidarExistenciaMembresia(ObjMembresia);

                // Validamos que si el resultado es Igual a '0' que prosiga con lo siguiente
                if (resultt == 0)
                {
                    // Mandamos una Ventande Interaccion para Confirmar Si el Dui es Correcto y proseguir con lo siguiente
                    MessageBoxResult messageBoxResult = MessageBox.Show($"El Numero de Dui ingresado es: ' {ObjMembresia.Dui} ' a Nombre de '{ObjMembresia.Nombre} {ObjMembresia.Apellido}' . " +
                        $"¿ESTAS SEGURO DE GUARDAR ESTA MEMBRESIA, NO PODRAS MODIFICAR ESTE DUI?", "Confirmación de Dui - Guardar Membresia", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

                    // Si se Preciono el boton Ok se ejecuta lo siguiente
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        // Procedemos a Guardar la Membresia en la Base de Datos
                        var ObjMembresiaBL = new MembresiaBL();
                        var result = ObjMembresiaBL.GuardarMembresia(ObjMembresia);

                        // Si result es diferente de 0 Muestra una Ventan al usuario
                        if (result != 0)
                        {
                            MessageBox.Show("Membresia agregada con éxito", "Guardado Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarDataGrid();
                            Close();
                        }
                    }
                    // Pero si se Preciona el Boton de Cancelar se ejecuta lo siguiente.
                    else if (messageBoxResult == MessageBoxResult.Cancel)
                    {
                        MessageBox.Show("Operación Cancelada, Revisa el Formulario", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                //Pero si es igual a ' 1 ' Procedemos con lo siguiente
                else
                {
                    MessageBox.Show("La Membresia que intentas agregar ya existe", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtDui.Focus();
                    return;
                }
            }
            // Si no Mostramos el Siguiente Mensaje
            else
            {
                MessageBox.Show("Uno o más campos están vacíos", "Valores Vacíos Detectados", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }
        #endregion

        #region Evento Click Para Modificar una Membresia Existente
        // Metodo para Modificar una Membresia
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener la imagen en formato BitmapSource desde el control de imagen 'imgFoto'.
            BitmapSource? bitmapSource = imgFoto.Source as BitmapSource;
            // Crear un flujo de memoria para almacenar los bytes de la imagen.
            using (MemoryStream ms = new MemoryStream())
            {
                // Crear un codificador de imagen JPEG.
                BitmapEncoder encoder = new JpegBitmapEncoder();
                // Agregar el fotograma de la imagen al codificador.
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                // Guardar la imagen codificada en el flujo de memoria.
                encoder.Save(ms);

                // Obtener los bytes de la imagen desde el flujo de memoria.
                byte[]? ImagenBytes = ms.ToArray();

                // Verificar si la ruta de la imagen no está vacía y leer los bytes desde el archivo si es así.
                if (!string.IsNullOrEmpty(rutaImagen))
                {
                    ImagenBytes = File.ReadAllBytes(rutaImagen);
                }

                // La Variable ObjMembresia almacenara los Atributos de la Entidad con los Datos Proporcionado en cada Campo de la Vista Grafica
                var ObjMembresia = new MembresiaEN
                {
                    Id = Convert.ToInt32(txtIdMembresia.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellidos.Text,
                    Dui = txtDui.Text,
                    FechaNacimiento = dtbFechaDeNacimiento.SelectedDate.Value,
                    Edad = txtEdad.Text,
                    Sexo = new SexoEN
                    {
                        Id = Convert.ToInt32(cbxSexo.SelectedValue),
                    },
                    EstadoCivil = new EstadoCivilEN
                    {
                        Id = Convert.ToInt32(cbxEstadoCivil.SelectedValue),
                    },
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    ProfesionUOficio = new ProfesionUOficioEN
                    {
                        Id = Convert.ToInt32(cbxProfesionUOficio.SelectedValue),
                    },
                    LugarDeTrabajo = txtLugarDeTrabajo.Text,
                    TelefonoDelTrabajo = txtTelefonoDelTrabajo.Text,
                    FechaConversion = dtFechaDeConversion.SelectedDate.Value,
                    LugarDeConversion = txtDireccionDeConversion.Text,
                    BautizmoEnAgua = new BautizmoEnAguaEN
                    {
                        Id = Convert.ToInt32(cbxBautizmoEnAgua.SelectedValue),
                    },
                    BautizmoDelEspirituSanto = new BautizmoDelEspirituSantoEN
                    {
                        Id = Convert.ToInt32(cbxBautizmoEnEspirituSanto.SelectedValue),
                    },
                    Pastores = new PastoresEN
                    {
                        Id = Convert.ToInt32(cbxNombreDelPastor.SelectedValue),
                    },
                    Supervisor = new SupervisoresEN
                    {
                        Id = Convert.ToInt32(cbxNombreDelSupervisor.SelectedValue),
                    },
                    NombreLider = txtNombreDelLider.Text,
                    Digito = txtDigito.Text,
                    ListaCalendario = new ListaDeCalendarioEN
                    {
                        Id = Convert.ToInt32(cbxListaCalendario.SelectedValue),
                    },
                    Zona = new ZonaEN
                    {
                        Id = Convert.ToInt32(cbxZona.SelectedValue),
                    },
                    Distrito = new DistritoEN
                    {
                        Id = Convert.ToInt32(cbxDistrito.SelectedValue),
                    },
                    Sector = new SectorEN
                    {
                        Id = Convert.ToInt32(cbxSector.SelectedValue),
                    },
                    Celula = new CelulaEN
                    {
                        Id = Convert.ToInt32(cbxCelula.SelectedValue),
                    },
                    Estatus = new EstatusEN
                    {
                        Id = Convert.ToInt32(cbxEstatus.SelectedValue),
                    },
                    Observaciones = txtObservaciones.Text,
                    Fotografia = ImagenBytes,
                    FechaModificacion = DateTime.Now,
                };

                // Validamos que ObjMembresia sea Diferente de NULL para continuar con lo siguiente
                if (ObjMembresia != null)
                {
                    // Validamos los Campos a Ingresar O solo Numeros O Solo letras
                    if (Regex.IsMatch(ObjMembresia.Nombre, ".*\\d+.*"))
                    {
                        MessageBox.Show("El campo 'Nombre' no debe contener números.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtNombre.Focus();
                        return;
                    }
                    if (Regex.IsMatch(ObjMembresia.Apellido, ".*\\d+.*"))
                    {
                        MessageBox.Show("El campo 'Apellido' no debe contener números.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtApellidos.Focus();
                        return;
                    }
                    if (Regex.IsMatch(ObjMembresia.NombreLider, ".*\\d+.*"))
                    {
                        MessageBox.Show("El campo 'Nombre del Lider' no debe contener números.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtNombreDelLider.Focus();
                        return;
                    }
                    if (Regex.IsMatch(ObjMembresia.Telefono, "[^0-9]"))
                    {
                        MessageBox.Show("El campo 'Telefono' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtTelefono.Focus();
                        return;
                    }
                    if (Regex.IsMatch(ObjMembresia.TelefonoDelTrabajo, "[^0-9]"))
                    {
                        MessageBox.Show("El campo 'Telefono Del Trabajo' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtTelefonoDelTrabajo.Focus();
                        return;
                    }
                    if (Regex.IsMatch(ObjMembresia.Digito, "[^0-9]"))
                    {
                        MessageBox.Show("El campo 'Tiempo de Congregarse' no debe contener letras ni otros caracteres que no sean Numeros", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtDigito.Focus();
                        return;
                    }

                    // Mandamos una Ventande Interaccion para Confirmar Si el Dui es Correcto y proseguir con lo siguiente
                    MessageBoxResult messageBoxResult = MessageBox.Show($"¿ESTAS SEGURO DE MODIFICAR ESTA MEMBRESIA? A Nombre de '{ObjMembresia.Nombre} {ObjMembresia.Apellido}' con Numero de Dui: ' {ObjMembresia.Dui} '",
                        "Confirmación de Dui - Guardar Membresia", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

                    // Si se Preciono el boton Ok se ejecuta lo siguiente
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        // Procedemos a Modificar la Membresia en la Base de Datos
                        var pMembresiaBL = new MembresiaBL();
                        pMembresiaBL.ModificarMembresia(ObjMembresia);
                        var pMembresiaActulizada = pMembresiaBL.ObtenerMembresia();

                        formMembresia.dgvMostrar_Membresias.ItemsSource = null;
                        formMembresia.dgvMostrar_Membresias.ItemsSource = pMembresiaActulizada;

                        // Mostramos una Ventana De Exito
                        MessageBox.Show("Membresia Modificada Con Exito", "Modificacion de Membresia", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarDataGrid();
                        Close();
                    }
                    // Pero si se Preciona el Boton de Cancelar se ejecuta lo siguiente.
                    else if (messageBoxResult == MessageBoxResult.Cancel)
                    {
                        MessageBox.Show("Operación Cancelada, Revisa el Formulario", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                // Si no Mostramos el Siguiente Mensaje
                else
                {
                    MessageBox.Show("Uno o más campos están vacíos", "Valores Vacíos Detectados", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }
        #endregion

        #region Evento Click Para Eliminar una Membresia Existente
        // Evento Click para Eliminar un Registro
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Obtenemos el Id del Registro a Eliminar
            var EliminarMembresia = new MembresiaEN
            {
                Id = int.Parse(txtIdMembresia.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellidos.Text,
                Dui = txtDui.Text
            };
            // Validamos que la variable EliminarMembresia sea Diferente a NULL
            if (EliminarMembresia != null)
            {
                // Mostramos una ventana Emergente para confimar si Estas seguro de eliminar dicho Registro
                MessageBoxResult messageBoxResult = MessageBox.Show($"¿ESTAS SEGURO DE ELIMINAR ESTA MEMBRESIA? A Nombre de '{EliminarMembresia.Nombre} {EliminarMembresia.Apellido}' con Numero de Dui: ' {EliminarMembresia.Dui} '",
                "Confirmación de Dui - Guardar Membresia", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

                // Validamos si La respuesta es Ok que Suceda lo siguiente
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    // Procedemos a Eliminar la Membresia en la Base de Datos
                    var pMembresia = new MembresiaBL();
                    pMembresia.EliminarMembresia(EliminarMembresia);
                    var MembresiaActualizada = pMembresia.ObtenerMembresia();

                    formMembresia.dgvMostrar_Membresias.ItemsSource = null;
                    formMembresia.dgvMostrar_Membresias.ItemsSource = MembresiaActualizada;

                    // Mostramos una Ventana De Exito
                    MessageBox.Show("Membresia Eliminada Con Exito", "Eliminar Membresia", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                // Pero si se Preciona el Boton de Cancelar se ejecuta lo siguiente.
                else if (messageBoxResult == MessageBoxResult.Cancel)
                {
                    MessageBox.Show("Operación Cancelada, Revisa el Formulario", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            // Se Procede a Cerrar el Formulario
            Close();
        }
        #endregion
    }
}
