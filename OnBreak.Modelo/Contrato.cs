using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Modelo
{
    public class Contrato
    {
        public string NumeroContrato { get; set; }
        public Cliente MiCliente { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public DateTime Creacion { get; set; } // Fecha de creacion del contrato
        public DateTime? Termino { get; set; } // Fecha de termino del contrato
        public DateTime FechaHoraInicio { get; set; } // Fecha y hora en que comienza el evento
        public DateTime FechaHoraTermino { get; set; } // Fecha y hora en que termina el evento
        public string Direcccion { get; set; } // Direccion donde se realiza el evento
        public bool EstaVigente { get; set; } // Indica si el contrato esta vigente o no
        public TipoEvento MiTipoEvento { get; set; }
        public string Observaciones { get; set; }

        public Contrato()
        {

        }

        public Contrato(
            string numeroContrato,
            Cliente miCliente,
            int asistentes,
            int personalAdicional,
            DateTime creacion,
            DateTime? termino,
            DateTime fechaHoraInicio,
            DateTime fechaHoraTermino,
            string direcccion,
            bool estaVigente,
            TipoEvento miTipoEvento,
            string observaciones)
        {
            this.NumeroContrato = numeroContrato;
            this.MiCliente = miCliente;
            this.Asistentes = asistentes;
            this.PersonalAdicional = personalAdicional;
            this.Creacion = creacion;
            this.Termino = termino;
            this.FechaHoraInicio = fechaHoraInicio;
            this.FechaHoraTermino = fechaHoraTermino;
            this.Direcccion = direcccion;
            this.EstaVigente = estaVigente;
            this.MiTipoEvento = miTipoEvento;
            this.Observaciones = observaciones;
        }
    }




    //public int CalcularValorTotalEvento(int )

}
