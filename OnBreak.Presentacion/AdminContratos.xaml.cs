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
    /// Lógica de interacción para AdminContratos.xamlde
    /// </summary>
    public partial class AdminContratos : MetroWindow
    {
        private ContratoCollection ListaContratos;

        private ClienteCollection ListaClientes;

        private Contrato _ContratoSeleccionado;

        private TipoEventoCollection ListaTipoEventos;



        float asistentesFloat = 0, personalAdi = 0, valorBase = 0;


        private Contrato ContratoSeleccionado
        {
            get
            {
                int numeroContrato = 0;

                cmbTipoEvento.SelectedValue.ToString();


                Cliente cliente = ListaClientes.First(r => r.Rut == int.Parse(txtRut.Text));
                Contrato contrato = new Contrato();

                contrato.MiCliente = cliente;
                cliente.MisContratos.Add(contrato);
                TipoEvento tipoEvento = ListaTipoEventos.First(r => r.Id == cmbTipoEvento.SelectedValue.ToString());
                contrato.MiTipoEvento = tipoEvento;

                int.TryParse(txtNroContrato.Text, out numeroContrato);
                

                return new Contrato(
                    txtNroContrato.Text,
                    cliente,
                     int.Parse(txtAsist.Text),
                    int.Parse(txtPersBase.Text),
                    DateTime.Now,
                    null,
                    dpInicio.SelectedDate.Value,
                    dpTermino.SelectedDate.Value,
                    txtDireccion.Text,
                    true,
                    tipoEvento,
                    txtObservaciones.Text);
            }



            set
            {
                _ContratoSeleccionado = value;
            }
        }

        public AdminContratos()
        {
            InitializeComponent();
        }

        public AdminContratos(ContratoCollection listaContratos, ClienteCollection listaClientes, TipoEventoCollection tipoEventos)
        {
            InitializeComponent();
            ListaContratos = listaContratos;
            ListaClientes = listaClientes;
            ListaTipoEventos = tipoEventos;

            cmbTipoEvento.Items.Clear();
            cmbTipoEvento.DisplayMemberPath = "Nombre";
            cmbTipoEvento.SelectedValuePath = "Id";
            cmbTipoEvento.ItemsSource = ListaTipoEventos;
            cmbTipoEvento.SelectedValue = "-1";
        }


        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnBuscaCli_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes ventana = new ListarClientes(ListaClientes);

            ventana.ShowDialog();

            if (ventana.ClienteSeleccionado != null)
            {
                txtRut.Text = ventana.ClienteSeleccionado.Rut.ToString();
                txtRazonSocial.Text = ventana.ClienteSeleccionado.RazonSocial;
                txtNomCont.Text = ventana.ClienteSeleccionado.NombreContacto;
                txtCorrCont.Text = ventana.ClienteSeleccionado.MailContacto;
            }

            ventana = null;
        }

        private void btnBuscaCont_Click(object sender, RoutedEventArgs e)
        {

            ListarContratos ListCont = new ListarContratos(ListaContratos, ListaClientes, ListaTipoEventos);

            ListCont.Show();

            if (ListCont.ContratoSeleccionado != null)
            {
                ConfigurarContratoEnPantalla(ListCont.ContratoSeleccionado);
            }
            ListCont = null;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btnTerCon_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
        }

        private void btnNuevoContrato_Click(object sender, RoutedEventArgs e)
        {
            NuevoContrato();
        }



        private bool ValidarFormulario()
        {
            if (txtNroContrato.Text != "")
            {
                if (!Validaciones.ValidarRut(txtNroContrato.Text)) return false;
            }
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtRazonSocial.Text, "Razón social")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtNomCont.Text, "Nombre Contacto")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtCorrCont.Text, "Correo Contacto")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtDireccion.Text, "Dirección")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtAsist.Text, "Asistentes")) return false;
            if (!Validaciones.ValidarCampoDeTextoObligatorio(txtPersAct.Text, "Personal Actuak")) return false;
            return true;
        }

        private void ConfigurarContratoEnPantalla(Contrato contrato)
        {
            txtNroContrato.Text = contrato.NumeroContrato.ToString();
            txtRazonSocial.Text = contrato.MiCliente.RazonSocial;
            txtNomCont.Text = contrato.MiCliente.NombreContacto;
            txtCorrCont.Text = contrato.MiCliente.MailContacto;
            txtDireccion.Text = contrato.Direcccion;
            txtValorBase.Text = contrato.MiTipoEvento.ValorBase.ToString();
            txtAsist.Text = contrato.Asistentes.ToString();

            if (contrato.EstaVigente == true)
                txtEstado.Text = "Vigente";
            else
                txtEstado.Text = "Terminado";
            txtPersBase.Text = contrato.MiTipoEvento.PersonalBase.ToString();
            txtPersAct.Text = contrato.PersonalAdicional.ToString();
            cmbTipoEvento.SelectedItem = contrato.MiTipoEvento.Nombre;
        }

        public void NuevoContrato()
        {
            txtNroContrato.Text = DateTime.Now.ToString("yyyyMMddHHmm");
            txtRut.Text = "";
            txtRazonSocial.Text = "";
            txtNomCont.Text = "";
            txtCorrCont.Text = "";
            txtDireccion.Text = "";
            txtValorBase.Text = "";
            txtAsist.Text = "";
            dpInicio.Text = "";
            dpTermino.Text = "";
            txtValorFinal.Text = "";
            txtEstado.Text = "";
            txtPersBase.Text = "";
            txtPersAct.Text = "";
            txtObservaciones.Text = "";
            cmbTipoEvento.SelectedValue = "-1";
        }

        private void Guardar()
        {
            if (!ValidarFormulario()) return;

            bool existe = ListaContratos.Any(x => x.NumeroContrato.Contains(txtNroContrato.Text));

            if (existe)
            {
                bool fueActualizado = ListaContratos.Actualizar(this.ContratoSeleccionado);
                Mensaje.ActualizacionContrato(fueActualizado);
            }
            if(!existe)
            {
                Contrato contrato = ListaContratos.Crear(this.ContratoSeleccionado);
                txtNroContrato.Text = contrato.NumeroContrato.ToString();
                Mensaje.CreacionContrato();
            }
        }








        public void Eliminar()
        {
            if (txtNroContrato.Text == "")
            {
                Mensaje.NoPuedeEliminarClienteEnCreacion();
            }
            else
            {
                if (!Validaciones.ValidarRut(txtNroContrato.Text)) return;

                MessageBoxResult respuesta = Mensaje.SeguroDeseaEliminarElContrato();

                if (respuesta == MessageBoxResult.Yes)
                {
                    var eliminado = ListaContratos.Eliminar(txtNroContrato.Text);

                    if (eliminado)
                    {
                        NuevoContrato();
                        Mensaje.ContratoEliminadoCorrectamente();
                        return;
                    }
                    Mensaje.NoSePuedoEliminarContrato();
                }
            }
        }

        public void Cancelar()
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }



        public void rapidin()
        {
            string lolaso;
            string onion;
            string carrot;


            lolaso = cmbTipoEvento.SelectedValue.ToString();




            if (lolaso == "CB001")
            {
                onion = "2";
                carrot = "3";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 3.0f;
            }

            if (lolaso == "CB002")
            {
                onion = "6";
                carrot = "8";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 8.0f;
            }

            if (lolaso == "CB003")
            {
                onion = "6";
                carrot = "12";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 12.0f;
            }

            if (lolaso == "CO001")
            {
                onion = "4";
                carrot = "6";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 6.0f;
            }

            if (lolaso == "CO002")
            {
                onion = "5";
                carrot = "10";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 10.0f;
            }

            if (lolaso == "CE001")
            {
                onion = "10";
                carrot = "25";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 25.0f;
            }

            if (lolaso == "CE002")
            {
                onion = "14";
                carrot = "35";
                txtPersBase.Text = onion;
                txtValorBase.Text = carrot;
                valorBase = 35.0f;
            }

            if (lolaso == "-1") { txtPersBase.Clear(); txtValorBase.Clear(); valorBase = 0; }

        }





        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            rapidin();
            sumarValorFinal();
        }





        public void obtenerUF()
        {
            if (txtAsist.Text != "")
            {

                int asis = 0;
                float recargoUF = 0.0f;
                int contador = 1;
                int i, x;

                asis = int.Parse(txtAsist.Text);

                if (asis > 0 && asis < 21)
                {

                    recargoUF = 2;

                }

                if (asis > 20 && asis < 51)
                {

                    recargoUF = 5;

                }

                for (i = 51; i < 5100; i = i + 20)
                {
                    for (x = 71; x < 7100; x = x + 20)
                    {
                        if (asis >= i && asis <= x)
                        {

                            recargoUF = (2 * contador) + 5;
                            x = 7101;
                            i = 5101;

                        }
                        else
                        {
                            contador += 1;
                        }
                    }
                }
                asistentesFloat = recargoUF;
            }
            else { txtValorFinal.Text = "";
                asistentesFloat = 0;
            }

        }


        public void ObtenerUfadicional()
        {

            if (txtPersAct.Text != "")
            {

                int onion = 0;
                int carrot = 1;
                float personalRecargoUf = 0.0f;
                int personalAd = 0;


               personalAd = int.Parse(txtPersAct.Text);


                if (personalAd == 2)
                {
                    personalRecargoUf = 2.0f;
                    personalAdi = personalRecargoUf;
                }

                if (personalAd == 3)
                {
                    personalRecargoUf = 3.0f;
                    personalAdi = personalRecargoUf;
                }

                if (personalAd == 4)
                {
                    personalRecargoUf = 3.5f;
                    personalAdi = personalRecargoUf;
                }

                if (personalAd > 4)
                {
                    for (onion = 5; onion < 100; onion++)
                    {
                        if (personalAd == onion)
                        {
                            personalRecargoUf = 3.5f + (0.5f * carrot);
                            onion = 181284214;
                            personalAdi = personalRecargoUf;
                        }
                        else
                        {

                            carrot = carrot + 1;
                        }
                    }
                }
            }
            else
            {
                txtValorFinal.Text = "";
                personalAdi = 0;

            }
        }


        public void sumarValorFinal()
        {

            string Suma = Convert.ToString(asistentesFloat + personalAdi + valorBase);
            txtValorFinal.Text = Suma;
        }



        



        

        private void TxtPersAct_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObtenerUfadicional();
            sumarValorFinal();
        }

        private void TxtAsist_TextChanged(object sender, TextChangedEventArgs e)
        {
            obtenerUF();
            sumarValorFinal();
        }









        void PrintText(object sender, SelectionChangedEventArgs args)
        {
           ComboBoxItem lbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            //tb.Text = "   You selected " + lbi.Content.ToString() + ".";
        }


        void CmbTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
           /* ComboBoxItem cbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            txtPrueba.Text = "   You selected " + cbi.Content.ToString() + ".";*/
        }


    }
}
