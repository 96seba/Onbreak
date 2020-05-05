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
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : MetroWindow
    {
        #region Campos
        int Switchdgr = 0;
        private ClienteCollection ListaCliente;
        #endregion Campos

        #region Propiedades

        public Cliente ClienteSeleccionado
        {
            get
            {
                if (dgrClientes.HasItems)
                {
                    if (dgrClientes.SelectedItem != null)
                    {
                        return (Cliente)dgrClientes.SelectedItem;
                    }
                }
                return null;
            }
        }

        #endregion Propiedades
        #region constructores
        public ListarClientes()
        {
            InitializeComponent();
            cmbActividad.ItemsSource = Enum.GetValues(typeof(EnumActividad));
            cmbTipo.ItemsSource = Enum.GetValues(typeof(EnumTipo));
            cmbActividad.SelectedItem = EnumActividad.NoSeleccionado;
            cmbTipo.SelectedItem = EnumTipo.NoSeleccionado;

            //this.Title = Mensaje.TituloParaVentanasDeDialogos;
        } 

        public ListarClientes(ClienteCollection listaClientes)
        {
            InitializeComponent();
            cmbActividad.ItemsSource = Enum.GetValues(typeof(EnumActividad));
            cmbTipo.ItemsSource = Enum.GetValues(typeof(EnumTipo));

            cmbActividad.SelectedItem = EnumActividad.NoSeleccionado;
            cmbTipo.SelectedItem = EnumTipo.NoSeleccionado;
            ListaCliente = listaClientes;
        }

        #endregion constructor
        

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Buscar();
            Switchdgr++;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancelar();
        }

        private void btnElim_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
        }

        #region metodos

        private void Buscar()
        {
            int rut = Validaciones.ObtenerRutParaBusqueda(txtRut.Text);

            if (rut == -1) return;

            List<Cliente> lista = ListaCliente.Buscar(
                  rut,
                  txtRazonSocial.Text,
                  txtDireccion.Text,
                  txtTelefono.Text,
                  (EnumActividad)cmbActividad.SelectedItem,
                  (EnumTipo)cmbTipo.SelectedItem);

            if (lista == null)
            {
                Mensaje.NoSeEncontraronClientes();
                return;
            }


            if (Switchdgr == 0) {
            dgrClientes.Items.Clear();
                 }

            dgrClientes.ItemsSource = lista;

        }

        private void Modificar()
        {
            if (this.ClienteSeleccionado == null)
            {
                Mensaje.ParaModificarDebeSeleccionarEnLaLista();
            }
            else
            {
                this.Close();
            }
        }

        public void Limpiar()
        {
            dgrClientes.ItemsSource = null;
            txtRut.Text = "";
            txtRazonSocial.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cmbActividad.SelectedItem = EnumActividad.NoSeleccionado;
            cmbTipo.SelectedItem = EnumTipo.NoSeleccionado;
        }
        private void Eliminar()
        {
            if (this.ClienteSeleccionado == null)
            {
                Mensaje.ParaEliminarDebeSeleccionarEnLaLista();
            }
            else
            {
                MessageBoxResult respuesta = Mensaje.SeguroDeseaEliminarElCliente();

                if (respuesta == MessageBoxResult.Yes)
                {
                    bool fueEliminado = ListaCliente.Eliminar(this.ClienteSeleccionado.Rut);

                    if (fueEliminado)
                    {
                        Buscar();
                        Mensaje.ClienteEliminadoCorrectamente();
                        return;
                    }
                    Mensaje.NoSePuedoEliminarCliente();
                }
            }
        }
        private void Cancelar()
        {
            dgrClientes.ItemsSource = null;
            this.Close();
        }
        #endregion metodos


    }
}
