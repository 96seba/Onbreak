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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro;
using OnBreak.Modelo;

namespace OnBreak.Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ClienteCollection ListaClientes;

        ContratoCollection ListaContratos;

        TipoEventoCollection ListaTiposEventos;

        public void CrearDatosDePrueba()
        {
            ListaTiposEventos = new TipoEventoCollection();

            ListaTiposEventos.Add(new TipoEvento("CB001", "Coffee Break - Light Break", 3, 2));
            ListaTiposEventos.Add(new TipoEvento("CB002", "Coffee Break - Journal Break", 8, 6));
            ListaTiposEventos.Add(new TipoEvento("CB003", "Coffee Break - Day Break", 12, 6));
            ListaTiposEventos.Add(new TipoEvento("CO001", "Cocktail - Quick Cocktail", 6, 4));
            ListaTiposEventos.Add(new TipoEvento("CO002", "Cocktail - Ambient Cocktail", 10, 5));
            ListaTiposEventos.Add(new TipoEvento("CE001", "Cenas - Ejecutiva", 25, 10));
            ListaTiposEventos.Add(new TipoEvento("CE002", "Cenas - Celebración", 35, 14));
            ListaTiposEventos.Add(new TipoEvento("-1", "Seleccionar", 0, 0));
            ListaClientes = new ClienteCollection();

            Cliente soprole = new Cliente(1, "Soprole", "Ana", "ana@soprole.cl", "Santiago", "123", EnumActividad.Alimentos, EnumTipo.Limitada);
            Cliente agrosuper = new Cliente(2, "Agrosuper", "Juan", "juan@agrosuper.cl", "Viña", "456", EnumActividad.Alimentos, EnumTipo.Limitada);
            Cliente codelco = new Cliente(3, "Codelco", "María", "maria@codelco.cl", "El Salvador", "567", EnumActividad.Comercio, EnumTipo.SociedadAnonima);

            ListaClientes.Add(soprole);
            ListaClientes.Add(agrosuper);
            ListaClientes.Add(codelco);
       
            ListaContratos = new ContratoCollection();

            Contrato c1 = new Contrato("202004292011", soprole, 100, 5, new DateTime(2020, 04, 29), null, new DateTime(2020, 05, 02, 21, 00, 00), new DateTime(2020, 05, 03, 04, 00, 00), "Casa Piedra", true, ListaTiposEventos.First(r => r.Id == "CE002"), "Sin observaciones");
            Contrato c2 = new Contrato("202004292011", agrosuper, 200, 7, new DateTime(2020, 04, 29), null, new DateTime(2020, 05, 02, 21, 00, 00), new DateTime(2020, 05, 03, 04, 00, 00), "Casa Piedra", true, ListaTiposEventos.First(r => r.Id == "CE002"), "Sin observaciones");
            Contrato c3 = new Contrato("202004292011", codelco, 300, 10, new DateTime(2020, 04, 29), null, new DateTime(2020, 05, 02, 21, 00, 00), new DateTime(2020, 05, 03, 04, 00, 00), "Casa Piedra", true, ListaTiposEventos.First(r => r.Id == "CE002"), "Sin observaciones");

            ListaContratos.Add(c1);
            ListaContratos.Add(c2);
            ListaContratos.Add(c3);

            soprole.MisContratos.Add(c1);
            agrosuper.MisContratos.Add(c2);
            codelco.MisContratos.Add(c3);
        }


        public void CrearDatosDeContrato()
        {
            
        }





        public MainWindow()
        {
            InitializeComponent();

            CrearDatosDePrueba();

            ThemeManager.ChangeAppTheme(Application.Current, "BaseLight");
        }

        private void TswCambioDeTema_Click(object sender, RoutedEventArgs e)
        {
            if (!TswCambioDeTema.IsChecked.Value)
            {
                ThemeManager.ChangeAppTheme(Application.Current, "BaseLight");
            }
            else
            {
                ThemeManager.ChangeAppTheme(Application.Current, "BaseDark");
            }
        }

        private void verConfig_Click(object sender, RoutedEventArgs e)
        {
            flyConfig.IsOpen = true;
        }

        private void btnAdminCli_Click(object sender, RoutedEventArgs e)
        {
            AdminCliente adCli = new AdminCliente(ListaClientes);
            adCli.ShowDialog();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            flyConfig.IsOpen = true;
        }

        private void btnListCli_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes ListCli = new ListarClientes(ListaClientes);
            ListCli.ShowDialog(); 
        }

        private void btnListCont_Click(object sender, RoutedEventArgs e)
        {
            ListarContratos ListCont = new ListarContratos(ListaContratos, ListaClientes,ListaTiposEventos);
            ListCont.ShowDialog(); 
        }

        private void btnAdminCont_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos contrato = new AdminContratos(ListaContratos, ListaClientes, ListaTiposEventos);
            contrato.ShowDialog(); 
        }
    }
}
