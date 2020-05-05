using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnBreak.Presentacion
{
    public static class Mensaje
    {
        public const string TituloParaVentanDeDialogos = "Sistema de ONBreak";


        #region Mensajes auxiliares

        public static void Mostrar(string mensaje)
        {
            MessageBox.Show(mensaje, TituloParaVentanDeDialogos, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        #endregion Mensajes auxiliares
        #region Mensajes MainWindow


        public static void ActualizacionCliente(bool fueActualizado)
        {
            if (fueActualizado)
            {
                Mostrar("El cliente fue actualizado correctamente.");
            }
            else
            {
                Mostrar("El cliente no pudo ser actualizado.");
            }
        }

        public static void CreacionCliente()
        {
            Mostrar("El cliente fue creado correctamente.");
        }

        public static MessageBoxResult SeguroDeseaEliminarElCliente()
        {
            return MessageBox.Show("¿Está seguro que desea eliminar el cliente?", TituloParaVentanDeDialogos
                , MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        public static void NoPuedeEliminarClienteEnCreacion()
        {
            Mensaje.Mostrar("No se puede eliminar un cliente que está recién siendo creado.");
        }

        public static void ClienteEliminadoCorrectamente()
        {
            Mostrar("El cliente fue eliminado correctamente.");
        }

        public static void NoSePuedoEliminarCliente()
        {
            Mostrar("El cliente no pudo ser eliminado.");
        }

        #endregion Mensajes

        #region Mensajes VentanaDeBusqueda



        public static void NoSeEncontraronClientes()
        {
            Mostrar("No se encontraron clientes para los criterios de búsqueda ingresados.");
        }

        public static void ParaModificarDebeSeleccionarEnLaLista()
        {
            Mostrar("Para modificar un registro, debe seleccionarlo primero en la lista.");
        }

        public static void ParaEliminarDebeSeleccionarEnLaLista()
        {
            Mostrar("Para eliminar un registro, debe seleccionarlo primero en la lista.");
        }

        #endregion Mensajes VentanaDeBusqueda

        #region Mensajes Contratos

        public static void CreacionContrato()
        {
            Mostrar("El contrato fue creado correctamente.");
        }


        public static void ActualizacionContrato(bool fueActualizado)
        {
            if (fueActualizado)
            {
                Mostrar("El contrato fue actualizado correctamente.");
            }
            else
            {
                Mostrar("El contrato no pudo ser actualizado.");
            }
        }

        public static MessageBoxResult SeguroDeseaEliminarElContrato()
        {
            return MessageBox.Show("¿Está seguro que desea eliminar el contrato?", TituloParaVentanDeDialogos
                , MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        public static void ContratoEliminadoCorrectamente()
        {
            Mostrar("El contrato fue eliminado correctamente.");
        }

        public static void NoSePuedoEliminarContrato()
        {
            Mostrar("El contrato no pudo ser eliminado.");
        }
        #endregion Mensajes Contratos
    }
}