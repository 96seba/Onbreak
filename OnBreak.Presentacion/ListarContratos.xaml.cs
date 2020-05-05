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
using MahApps.Metro.Controls;
using MahApps.Metro;
using OnBreak.Modelo;
namespace OnBreak.Presentacion
{
    /// <summary>
    /// Lógica de interacción para ListarContratos.xaml
    /// </summary>
    public partial class ListarContratos : MetroWindow
    {
        private ContratoCollection ListaContratos;

        private ClienteCollection ListaClientes;

        private TipoEventoCollection ListaTipoEvento;

        int Switchdgr = 0;

        public Contrato ContratoSeleccionado
        {
            get
            {
                if (dgrContrato.HasItems)
                {
                    if (dgrContrato.SelectedItem != null)
                    {
                        return (Contrato)dgrContrato.SelectedItem;
                    }
                }
                return null;
            }
        }


        public ListarContratos()
        {
            InitializeComponent();
        }

        public ListarContratos(ContratoCollection listaContratos, ClienteCollection listaclientes, TipoEventoCollection listaTipoEvento)
        {
            InitializeComponent();
            ListaContratos = listaContratos;
            ListaClientes = listaclientes;
            ListaTipoEvento = listaTipoEvento;

            cmbTipoEvento.Items.Clear();
            cmbTipoEvento.DisplayMemberPath = "Nombre";
            cmbTipoEvento.SelectedValuePath = "Id";
            cmbTipoEvento.ItemsSource = ListaTipoEvento;
            cmbTipoEvento.SelectedValue = "-1";
        }


        private void BtnVolver_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
        }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Buscar();
            Switchdgr++;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancelar();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
        }

        private void Buscar()
        {
            int rut = Validaciones.ObtenerRutParaBusqueda(txtRut.Text);

            if (rut == -1) return;

            

            List<Contrato> lista = ListaContratos.Buscar(
                    txtNroCont.Text,
                    txtRazonSocial.Text,
                   rut,
                   cmbTipoEvento.SelectedValue.ToString());



            if (lista == null)
            {
                Mensaje.NoSeEncontraronClientes();
                return;
            }

            if (Switchdgr == 0)
            {
                dgrContrato.Items.Clear();
            }

            dgrContrato.ItemsSource = lista;
        }

        private void Modificar()
        {
            if (this.ContratoSeleccionado == null)
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
            dgrContrato.ItemsSource = null;
            txtNroCont.Text = "";
            txtRazonSocial.Text = "";
            cmbTipoEvento.SelectedItem = EnumTipoEvento.NoSeleccionado;
        }

        private void Eliminar()
        {
            if (this.ContratoSeleccionado == null)
            {
                Mensaje.ParaEliminarDebeSeleccionarEnLaLista();
            }
            else
            {
                MessageBoxResult respuesta = Mensaje.SeguroDeseaEliminarElCliente();

                if (respuesta == MessageBoxResult.Yes)
                {
                    bool fueEliminado = ListaContratos.Eliminar(this.ContratoSeleccionado.NumeroContrato);

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
            dgrContrato.ItemsSource = null;
            this.Close();
        }

    }
}
