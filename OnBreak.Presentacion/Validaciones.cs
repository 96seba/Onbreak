using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Modelo;

namespace OnBreak.Presentacion
{
    public static class Validaciones
    {
        #region Validaciones AdminCliente
        public static bool ValidarRut(string rut)
        {
            if (!int.TryParse(rut, out int numero))
            {
                Mensaje.Mostrar("El rut debe ser un número");
                return false;
            }
            if (numero < 1)
            {
                Mensaje.Mostrar("El rut debe ser un número mayor que cero");
                return false;
            }
            return true;
        }
        public static bool ValidarActividad(EnumActividad actividad)
        {
            if (actividad == EnumActividad.NoSeleccionado)
            {
                Mensaje.Mostrar("El campo 'Acividad' es un campo obligatorio.");
                return false;
            }
            return true;
        }
        public static bool ValidarTipo(EnumTipo tipo)
        {
            if (tipo == EnumTipo.NoSeleccionado)
            {
                Mensaje.Mostrar("El campo 'Tipo' es un campo obligatorio.");
                return false;
            }
            return true;
        }

        public static bool ValidarTipoAct(EnumTipoEvento tipoAct)
        {
            if (tipoAct == EnumTipoEvento.NoSeleccionado)
            {
                Mensaje.Mostrar("El campo 'TipoAct' es un campo obligatorio.");
                return false;
            }
            return true;
        }

        public static bool ValidarCampoDeTextoObligatorio(string texto, string campo)
        {
            string mensaje = string.Format("El campo '{0}' es obligatorio, ", campo);

            if (string.IsNullOrEmpty(texto))
            {
                Mensaje.Mostrar(mensaje + "y no puede estar vacío.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(texto))
            {
                Mensaje.Mostrar(mensaje + "y no puede contener sólo espacios en blanco");
                return false;
            }
            return true;
        }
        #endregion Validaciones AdminCliente
        #region Validaciones VentanaDeBusqueda

        public static int ObtenerRutParaBusqueda(string rut)
        {
            if (string.IsNullOrEmpty(rut)) return 0;

            if (string.IsNullOrWhiteSpace(rut)) return 0;

            if (!int.TryParse(rut, out int numero))
            {
                Mensaje.Mostrar("El rut debe ser un número positivo mayor que cero.");
                return -1;
            }
            if (numero < 1)
            {
                Mensaje.Mostrar("El rut debe ser un número positivo mayor que cero.");
                return -1;
            }
            return Convert.ToInt32(rut);
        }

        public static int ObtenerNumeroContratoParaBusqueda(string nro)
        {
            if (string.IsNullOrEmpty(nro)) return 0;

            if (string.IsNullOrWhiteSpace(nro)) return 0;

            if (!int.TryParse(nro, out int numero))
            {
                Mensaje.Mostrar("El numero de contrato debe ser un número positivo mayor que cero.");
                return -1;
            }
            if (numero < 1)
            {
                Mensaje.Mostrar("El numero de contrato debe ser un número positivo mayor que cero.");
                return -1;
            }
            return Convert.ToInt32(nro);
        }
        #endregion Validaciones VentanaDeBusqueda
    }
}