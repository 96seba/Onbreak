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
using MahApps.Metro;
using MahApps.Metro.Controls;
using OnBreak.Modelo;  


namespace OnBreak.Presentacion
{
    /// <summary>
    /// Lógica de interacción para AdminCliente.xaml
    /// </summary>
    public partial class AdminCliente : MetroWindow
    {
        #region Campos

        private ClienteCollection ListaClientes;

        private Cliente _ClienteSeleccionado;

        #endregion Campos

        #region Propiedades

        private Cliente ClienteSeleccionado
        {
            get
            {
                int rut = 0;

                int.TryParse(txtRut.Text, out rut);

                return new Cliente(
                       int.Parse(txtRut.Text),
                       txtRazonSocial.Text,
                       txtNomContacto.Text,
                       txtCorreoContacto.Text,
                       txtDireccion.Text,
                       txtTelefono.Text,
                       (EnumActividad)cmbActividad.SelectedItem,
                       (EnumTipo)cmbTipo.SelectedItem);
            }

            set
            {
                _ClienteSeleccionado = value;
            }
        }


        #endregion Propiedades

        #region Constructores

        public AdminCliente()
        {
            InitializeComponent();

            cmbActividad.ItemsSource = Enum.GetValues(typeof(EnumActividad));
            cmbTipo.ItemsSource = Enum.GetValues(typeof(EnumTipo));
            cmbActividad.SelectedItem = EnumActividad.NoSeleccionado;
            cmbTipo.SelectedItem = EnumTipo.NoSeleccionado;
        }

        public AdminCliente(ClienteCollection listaClientes)
        {
            InitializeComponent();

            ListaClientes = listaClientes;
            cmbActividad.ItemsSource = Enum.GetValues(typeof(EnumActividad));
            cmbTipo.ItemsSource = Enum.GetValues(typeof(EnumTipo));
            cmbActividad.SelectedItem = EnumActividad.NoSeleccionado;
            cmbTipo.SelectedItem = EnumTipo.NoSeleccionado;
        }

        #endregion Constructores

        #region Eventos

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancelar();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Buscar();
        }
        #endregion Eventos
        #region Metodos

        private void ConfigurarClienteEnPantalla(Cliente cliente)
        {
            txtRut.Text = cliente.Rut.ToString();
            txtRazonSocial.Text = cliente.RazonSocial;
            txtNomContacto.Text = cliente.NombreContacto;
            txtCorreoContacto.Text = cliente.MailContacto;
            txtDireccion.Text = cliente.Direccion;
            txtTelefono.Text = cliente.Telefono;
            cmbActividad.SelectedItem = cliente.Actividad;
            cmbTipo.SelectedItem = cliente.Tipo;
        }

        private bool ValidarFormulario()
        {
            if (txtRut.Text != "")
            {
                if (!Validaciones.ValidarRut(txtRut.Text)) return false;
            }
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtRazonSocial.Text, "Razón social")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtDireccion.Text, "Dirección")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtTelefono.Text, "Telefono")) return false;
            if (!Validaciones.ValidarActividad((EnumActividad)cmbActividad.SelectedItem)) return false;
            if (!Validaciones.ValidarTipo((EnumTipo)cmbTipo.SelectedItem)) return false;
            return true;
        }

        private ClienteCollection ObtenerCopiaListaClientes()
        {
            ClienteCollection lista = new ClienteCollection();
            foreach (var cliente in ListaClientes)
            {
                Cliente copiaCliente = new Cliente();
                copiaCliente.Rut = cliente.Rut;
                copiaCliente.RazonSocial = cliente.RazonSocial;
                copiaCliente.Direccion = cliente.Direccion;
                copiaCliente.NombreContacto = cliente.NombreContacto;
                copiaCliente.MailContacto = cliente.MailContacto;
                copiaCliente.Telefono = cliente.Telefono;
                copiaCliente.Actividad = cliente.Actividad;
                copiaCliente.Tipo = cliente.Tipo;
                lista.Add(cliente);
            }
            return lista;
        }

        public void Nuevo()
        {
            txtRut.Text = "";
            txtRazonSocial.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cmbActividad.SelectedItem = EnumActividad.NoSeleccionado;
            cmbTipo.SelectedItem = EnumTipo.NoSeleccionado;
        }

        private void Guardar()
        {
            if (!ValidarFormulario()) return;

            int num = int.Parse(txtRut.Text);

            bool existe = ListaClientes.Any(x => x.Rut.Equals(num));
            if (existe)
            {
                bool fueActualizado = ListaClientes.Actualizar(this.ClienteSeleccionado);
                Mensaje.ActualizacionCliente(fueActualizado);

            }
            if (!existe)
            {
                Cliente cliente = ListaClientes.Crear(this.ClienteSeleccionado);
                txtRut.Text = cliente.Rut.ToString();
                Mensaje.CreacionCliente();
            }

        }

        public void Buscar()
        {
            var ventana = new ListarClientes(ListaClientes);

            ventana.ShowDialog();

            if (ventana.ClienteSeleccionado != null)
            {
                ConfigurarClienteEnPantalla(ventana.ClienteSeleccionado);
                
            }

            ventana = null;
        }

        public void Eliminar()
        {
            if (txtRut.Text == "")
            {
                Mensaje.NoPuedeEliminarClienteEnCreacion();
            }
            else
            {
                if (!Validaciones.ValidarRut(txtRut.Text)) return;

                MessageBoxResult respuesta = Mensaje.SeguroDeseaEliminarElCliente();

                if (respuesta == MessageBoxResult.Yes)
                {
                    var eliminado = ListaClientes.Eliminar(Convert.ToInt32(txtRut.Text));

                    if (eliminado)
                    {
                        Nuevo();
                        Mensaje.ClienteEliminadoCorrectamente();
                        return;
                    }
                    Mensaje.NoSePuedoEliminarCliente();
                }
            }
        }

        public void Cancelar()
        {
            this.Close();
        }

        #endregion Metodos


    }
}