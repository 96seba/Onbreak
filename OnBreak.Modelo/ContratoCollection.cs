using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Modelo
{
    public class ContratoCollection : List<Contrato>
    {
        public ContratoCollection()
        {

        }

        public Contrato Crear(Contrato contrato)
        {
            this.Add(contrato);
            return contrato;
        }

        public Contrato Leer(string numeroContrato)
        {
            return this.Where(r => r.NumeroContrato == numeroContrato).FirstOrDefault();
        }

        public List<Contrato> LeerTodos()
        {
            return this.ToList();
        }

        public bool Actualizar(Contrato contrato)
        {
            Contrato encontrado = this.Where(r => r.NumeroContrato == contrato.NumeroContrato).FirstOrDefault();
            if (encontrado == null) return false;

            encontrado.NumeroContrato = contrato.NumeroContrato;
            encontrado.MiCliente = contrato.MiCliente;
            encontrado.Asistentes = contrato.Asistentes;
            encontrado.PersonalAdicional = contrato.PersonalAdicional;
            encontrado.Creacion = contrato.Creacion;
            encontrado.Termino = contrato.Termino;
            encontrado.FechaHoraInicio = contrato.FechaHoraInicio;
            encontrado.FechaHoraTermino = contrato.FechaHoraTermino;
            encontrado.Direcccion = contrato.Direcccion;
            encontrado.EstaVigente = contrato.EstaVigente;
            encontrado.MiTipoEvento = contrato.MiTipoEvento;
            encontrado.Observaciones = contrato.Observaciones;

            return true;
        }

        public bool Eliminar(string numeroContrato)
        {
            var encontrado = Leer(numeroContrato);
            if (encontrado == null) return false;
            this.Remove(encontrado);
            return true;
        }



        public List<Contrato> Buscar(string numeroContrato, string razonSocial, int rut, string tipoEvento)
        {
            numeroContrato = numeroContrato.ToUpper();
            razonSocial = razonSocial.ToUpper();

            List<Contrato> lista = this.Where(r =>
                   (r.NumeroContrato.ToUpper().Contains(numeroContrato) || numeroContrato == "")
                && (r.MiCliente.RazonSocial.ToUpper().Contains(razonSocial) || razonSocial == "")
                && (r.MiCliente.Rut.Equals(rut) || rut == 0)
                && (r.MiTipoEvento.Id == tipoEvento || tipoEvento == "-1")
                ).ToList();
            return lista;
        }

    }
}
