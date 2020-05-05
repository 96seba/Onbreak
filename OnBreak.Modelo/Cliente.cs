using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Modelo
{
    public class Cliente
    {
        public int Rut { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public EnumActividad Actividad { get; set; }
        public EnumTipo Tipo { get; set; }
        public ContratoCollection MisContratos { get; set; }

        public Cliente()
        {

        }
        public Cliente(int rut, string razonSocial, string nombreContacto, string mailContacto, string direccion, string telefono, EnumActividad actividad,
            EnumTipo tipo)
        {
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.NombreContacto = nombreContacto;
            this.MailContacto = mailContacto;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Actividad = actividad;
            this.Tipo = tipo;
            MisContratos = new ContratoCollection();
        }

        public void AgregarContrato(Contrato contrato)
        {
            MisContratos.Add(contrato);
        }
    }
}
