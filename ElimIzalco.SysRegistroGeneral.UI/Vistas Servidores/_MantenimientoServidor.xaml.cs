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
// REFERENCIAS NECESARIAS PARA EL CORRECTO FUNCIONAMIENTO
using System.Windows;
using ElimIzalco.SysRegistroGeneral.BL.Membresia;
using static ElimIzalco.SysRegistroGeneral.EN.Acciones;
using ElimIzalco.SysRegistroGeneral.BL.Estatus;
using ElimIzalco.SysRegistroGeneral.BL.Privilegios;
using ElimIzalco.SysRegistroGeneral.BL.Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Membresia;
using System.IO;
using ElimIzalco.SysRegistroGeneral.BL.Estado_Civil;
using ElimIzalco.SysRegistroGeneral.BL.Sexo;
using ElimIzalco.SysRegistroGeneral.BL.Bautizmo_Del_Espiritu_Santo;
using ElimIzalco.SysRegistroGeneral.BL.Pastores;
using ElimIzalco.SysRegistroGeneral.BL.Supervisores;
using ElimIzalco.SysRegistroGeneral.BL.Celula;
using ElimIzalco.SysRegistroGeneral.BL.Distrito;
using ElimIzalco.SysRegistroGeneral.BL.Sector;
using ElimIzalco.SysRegistroGeneral.BL.Zona;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using ElimIzalco.SysRegistroGeneral.EN.Servidores;
using ElimIzalco.SysRegistroGeneral.EN.Celula;
using ElimIzalco.SysRegistroGeneral.EN.Estatus;
using ElimIzalco.SysRegistroGeneral.EN.Privilegios;
#endregion

namespace ElimIzalco.SysRegistroGeneral.UI.Vistas_Servidores
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoServidor.xaml
    /// </summary>
    public partial class _MantenimientoServidor : Window
    {
        #region Metodo de Inicializacion
        // Metodo de Inicializacion para el Formulario
        public _MantenimientoServidor(int? pId = null, byte? pAccion = null)
        {
            InitializeComponent();
            ActualizarDataGridMembresia();
            CargarEstatus();
            CargarPrivilegio();
            CargarComboSexo();
            CargarComboEstadoCivil();
            CargarComboBautizmoEspirituSanto();
            CargarPastor();
            CargarSupervisor();
            CargarDistrito();
            CargarZona();
            CargarSector();
            CargarCelula();

            // Validamos que la variable pId sea diferente a null para que proceda
            if (pId != null)
            {
                // Llamamos el Metodo SetServidor para que se ejecute en base al pId y la pAccion
                SetServidores(pId, pAccion);
            }

            // Validamos que si pAccion es igual a Crear se Ejecute lo siguiente
            if (pAccion == (byte)AccionEnum.Crear)
            {
                // Procedemos a Vaciar todos los Campos para la accion de Crear
                cbxEstatus.SelectedIndex = 0;
                cbxPrivilegio.SelectedIndex = 0;

                // Inabilitamos los Botones Agenos a la Accion de Guardar o Crear
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
            }
        }
        #endregion

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
            cbxPrivilegio.SelectedValuePath = "Id";
        }
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
        private void CargarComboBautizmoEspirituSanto()
        {
            var bautizmoEspirituSantoBl = new BautizmoDelEspirituSantoBL();
            var bautizmoEspirituSanto = bautizmoEspirituSantoBl.ObtenerBautizmoDelEspirituSanto();

            cbxBautizmoEnEspirituSanto.ItemsSource = bautizmoEspirituSanto;
            cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
            cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
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
        #endregion

        #region Metodo para Validar que Accion de Ver, Modificar y Elinminar se ejecuta Haciendo Uso del Parametro Id
        // Metodo para Validar que Accion se ha de Ejecutar
        public void SetServidores(int? pId, byte? pAccion)
        {
            // Creamos una instancia de la clase ServidorBL y Accedemos al Metodo ObtenerPorId
            var servidorBl = new ServidoresBL();
            var servidor = servidorBl.ObtenerServidorPorId(pId);

            // Validamos que la variable servidor sea diferente de null que prociga
            if (servidor != null)
            {
                // Validamos que si la accion es Ver ejecute lo siguiente
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    // Procedemos a llenar todos los campos con el registro correspondiente en base al Id Proporcionado
                    // Ademas de Deshabilitar los campos para unicamente Visualizar el Registro.
                    txtIdServidor.Text = Convert.ToString(servidor.Id);
                    txtIdMembresia.Text = Convert.ToString(servidor.Membresia.Id);
                    txtNombre.Text = servidor.Membresia.Nombre;
                    txtApellidos.Text = servidor.Membresia.Apellido;
                    txtEdad.Text = servidor.Membresia.Edad;
                    txtDui.Text = servidor.Membresia.Dui;

                    cbxSexo.SelectedValue = servidor.Membresia.Sexo.Id;
                    cbxSexo.DisplayMemberPath = "Nombre";
                    cbxSexo.SelectedValuePath = "Id";
                    cbxEstadoCivil.SelectedValue = servidor.Membresia.EstadoCivil.Id;
                    cbxEstadoCivil.DisplayMemberPath = "Nombre";
                    cbxEstadoCivil.SelectedValuePath = "Id";
                    cbxBautizmoEnEspirituSanto.SelectedValue = servidor.Membresia.BautizmoDelEspirituSanto.Id;
                    cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                    cbxNombreDelPastor.SelectedValue = servidor.Membresia.Pastores.Id;
                    cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                    cbxNombreDelPastor.SelectedValuePath = "Id";
                    cbxNombreDelSupervisor.SelectedValue = servidor.Membresia.Supervisor.Id;
                    cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                    cbxNombreDelSupervisor.SelectedValuePath = "Id";
                    cbxZona.SelectedValue = servidor.Membresia.Zona.Id;
                    cbxZona.DisplayMemberPath = "Numero";
                    cbxZona.SelectedValuePath = "Id";
                    cbxDistrito.SelectedValue = servidor.Membresia.Distrito.Id;
                    cbxDistrito.DisplayMemberPath = "Numero";
                    cbxDistrito.SelectedValuePath = "Id";
                    cbxSector.SelectedValue = servidor.Membresia.Sector.Id;
                    cbxSector.DisplayMemberPath = "Numero";
                    cbxSector.SelectedValuePath = "Id";
                    cbxCelula.SelectedValue = servidor.Membresia.Celula.Id;
                    cbxCelula.DisplayMemberPath = "Numero";
                    cbxCelula.SelectedValuePath = "Id";

                    // Obtener los bytes de una imagen de la membresía (si existen).
                    byte[]? ImagenBytes = servidor.Membresia.Fotografia;

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

                    cbxEstatus.SelectedValue = servidor.Estatus.Id;
                    cbxEstatus.DisplayMemberPath = "Nombre";
                    cbxEstatus.SelectedValuePath = "Id";
                    cbxEstatus.IsEnabled = false;
                    cbxPrivilegio.SelectedValue = servidor.Privilegio.Id;
                    cbxPrivilegio.DisplayMemberPath = "Nombre";
                    cbxPrivilegio.DisplayMemberPath = "Id";
                    cbxPrivilegio.IsEditable = false;

                    txtBuscarMiembro.IsEnabled = false;
                    btnConfirmarMiembro.IsEnabled = false;

                    btnGuardar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                }
                // Validamos que si la Accion no es ver que Ejecute la siguiente accion
                else if (pAccion == (byte)AccionEnum.Eliminar)
                {
                    // Procedemos a llenar todos los campos con el registro correspondiente en base al Id Proporcionado
                    // Ademas de Deshabilitar los campos para unicamente Visualizar el Registro.
                    txtIdServidor.Text = Convert.ToString(servidor.Id);
                    txtIdMembresia.Text = Convert.ToString(servidor.Membresia.Id);
                    txtNombre.Text = servidor.Membresia.Nombre;
                    txtApellidos.Text = servidor.Membresia.Apellido;
                    txtEdad.Text = servidor.Membresia.Edad;
                    txtDui.Text = servidor.Membresia.Dui;

                    cbxSexo.SelectedValue = servidor.Membresia.Sexo.Id;
                    cbxSexo.DisplayMemberPath = "Nombre";
                    cbxSexo.SelectedValuePath = "Id";
                    cbxEstadoCivil.SelectedValue = servidor.Membresia.EstadoCivil.Id;
                    cbxEstadoCivil.DisplayMemberPath = "Nombre";
                    cbxEstadoCivil.SelectedValuePath = "Id";
                    cbxBautizmoEnEspirituSanto.SelectedValue = servidor.Membresia.BautizmoDelEspirituSanto.Id;
                    cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                    cbxNombreDelPastor.SelectedValue = servidor.Membresia.Pastores.Id;
                    cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                    cbxNombreDelPastor.SelectedValuePath = "Id";
                    cbxNombreDelSupervisor.SelectedValue = servidor.Membresia.Supervisor.Id;
                    cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                    cbxNombreDelSupervisor.SelectedValuePath = "Id";
                    cbxZona.SelectedValue = servidor.Membresia.Zona.Id;
                    cbxZona.DisplayMemberPath = "Numero";
                    cbxZona.SelectedValuePath = "Id";
                    cbxDistrito.SelectedValue = servidor.Membresia.Distrito.Id;
                    cbxDistrito.DisplayMemberPath = "Numero";
                    cbxDistrito.SelectedValuePath = "Id";
                    cbxSector.SelectedValue = servidor.Membresia.Sector.Id;
                    cbxSector.DisplayMemberPath = "Numero";
                    cbxSector.SelectedValuePath = "Id";
                    cbxCelula.SelectedValue = servidor.Membresia.Celula.Id;
                    cbxCelula.DisplayMemberPath = "Numero";
                    cbxCelula.SelectedValuePath = "Id";

                    // Obtener los bytes de una imagen de la membresía (si existen).
                    byte[]? ImagenBytes = servidor.Membresia.Fotografia;

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

                    cbxEstatus.SelectedValue = servidor.Estatus.Id;
                    cbxEstatus.DisplayMemberPath = "Nombre";
                    cbxEstatus.SelectedValuePath = "Id";
                    cbxEstatus.IsEnabled = false;
                    cbxPrivilegio.SelectedValue = servidor.Privilegio.Id;
                    cbxPrivilegio.DisplayMemberPath = "Nombre";
                    cbxPrivilegio.DisplayMemberPath = "Id";
                    cbxPrivilegio.IsEditable = false;

                    txtBuscarMiembro.IsEnabled = false;
                    btnConfirmarMiembro.IsEnabled = false;

                    btnGuardar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                }
                // Si no se cumple ninguna de las Validaciones Anteriores que se ejecute la siguiente
                else
                {
                    // Procedemos a llenar todos los campos con el registro correspondiente en base al Id Proporcionado
                    // Ademas de Deshabilitar los campos para unicamente Visualizar el Registro.
                    txtIdServidor.Text = Convert.ToString(servidor.Id);
                    txtIdMembresia.Text = Convert.ToString(servidor.Membresia.Id);
                    txtNombre.Text = servidor.Membresia.Nombre;
                    txtApellidos.Text = servidor.Membresia.Apellido;
                    txtEdad.Text = servidor.Membresia.Edad;
                    txtDui.Text = servidor.Membresia.Dui;

                    cbxSexo.SelectedValue = servidor.Membresia.Sexo.Id;
                    cbxSexo.DisplayMemberPath = "Nombre";
                    cbxSexo.SelectedValuePath = "Id";
                    cbxEstadoCivil.SelectedValue = servidor.Membresia.EstadoCivil.Id;
                    cbxEstadoCivil.DisplayMemberPath = "Nombre";
                    cbxEstadoCivil.SelectedValuePath = "Id";
                    cbxBautizmoEnEspirituSanto.SelectedValue = servidor.Membresia.BautizmoDelEspirituSanto.Id;
                    cbxBautizmoEnEspirituSanto.DisplayMemberPath = "Nombre";
                    cbxBautizmoEnEspirituSanto.SelectedValuePath = "Id";
                    cbxNombreDelPastor.SelectedValue = servidor.Membresia.Pastores.Id;
                    cbxNombreDelPastor.DisplayMemberPath = "Nombre";
                    cbxNombreDelPastor.SelectedValuePath = "Id";
                    cbxNombreDelSupervisor.SelectedValue = servidor.Membresia.Supervisor.Id;
                    cbxNombreDelSupervisor.DisplayMemberPath = "Nombre";
                    cbxNombreDelSupervisor.SelectedValuePath = "Id";
                    cbxZona.SelectedValue = servidor.Membresia.Zona.Id;
                    cbxZona.DisplayMemberPath = "Numero";
                    cbxZona.SelectedValuePath = "Id";
                    cbxDistrito.SelectedValue = servidor.Membresia.Distrito.Id;
                    cbxDistrito.DisplayMemberPath = "Numero";
                    cbxDistrito.SelectedValuePath = "Id";
                    cbxSector.SelectedValue = servidor.Membresia.Sector.Id;
                    cbxSector.DisplayMemberPath = "Numero";
                    cbxSector.SelectedValuePath = "Id";
                    cbxCelula.SelectedValue = servidor.Membresia.Celula.Id;
                    cbxCelula.DisplayMemberPath = "Numero";
                    cbxCelula.SelectedValuePath = "Id";

                    // Obtener los bytes de una imagen de la membresía (si existen).
                    byte[]? ImagenBytes = servidor.Membresia.Fotografia;

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

                    cbxEstatus.SelectedValue = servidor.Estatus.Id;
                    cbxEstatus.DisplayMemberPath = "Nombre";
                    cbxEstatus.SelectedValuePath = "Id";
                    cbxPrivilegio.SelectedValue = servidor.Privilegio.Id;
                    cbxPrivilegio.DisplayMemberPath = "Nombre";
                    cbxPrivilegio.DisplayMemberPath = "Id";

                    btnGuardar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                }
            }
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

        #region Metodo para Guardar
        // Metodo Click para Guardar un Nuevo Servidor
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // La Variable ObjServidor almacenara los Atributos de la Entidad con los Datos Proporcionado en la Vista Grafica
            var ObjServidor = new ServidoresEN
            {
                Membresia = new MembresiaEN
                {
                    Id = Convert.ToInt32(txtIdMembresia.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellidos.Text,
                },
                Estatus = new EstatusEN
                {
                    Id = Convert.ToInt32(cbxEstatus.SelectedValue),
                },
                Privilegio = new PrivilegiosEN
                {
                    Id = Convert.ToInt32(cbxPrivilegio.SelectedValue),
                    Nombre = cbxPrivilegio.Text
                },
            };
            // Validamos que el ObjServidor sea diferente a NULL para poder continuar con lo siguiente
            if (ObjServidor != null)
            {
                // Accedemos al Metodo de Validacion de Existencia de la Capa BL  
                var ObjServidorBLL = new ServidoresBL();
                var resultt = ObjServidorBLL.ValidarExistenciaServidor(ObjServidor);

                //Validamos si el Resultado es igual a '0' que prosiga a lo siguiente
                if (resultt == 0)
                {
                    // Mandamos una Ventande Interaccion para Confirmar Si el Dui es Correcto y proseguir con lo siguiente
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Membresia a Nombre de: ' {ObjServidor.Membresia.Nombre} {ObjServidor.Membresia.Apellido}' . " +
                      $"¿Estas Seguro de Asignarle el Privilegio de: {ObjServidor.Privilegio.Nombre}?", "Confirmación de Servidor - Guardar Servidor", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

                    // Si se Preciona el OK ejecuta lo siguiente
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        // Procedemos a Guardar en la Base de Datos
                        var ObjServidorBL = new ServidoresBL();
                        var result = ObjServidorBL.GuardarServidor(ObjServidor);

                        // Si result es diferente de 0 Muestra una Ventana al Usuario
                        if (result != 0)
                        {
                            MessageBox.Show("Servidor Agregado con éxito", "Guardado Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);
                            Close();
                        }
                    }
                    // Pero si se preciona el boton de cancelar ejecute lo siguiente
                    else if (messageBoxResult == MessageBoxResult.Cancel)
                    {
                        MessageBox.Show("Operación Cancelada, Revisa el Formulario", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                //Pero si es igual a ' 1 ' Procedemos con lo siguiente
                else
                {
                    MessageBox.Show("El Servidor que intentas agregar ya existe", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
