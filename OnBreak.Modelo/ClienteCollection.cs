using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Modelo
{
    public class ClienteCollection : List<Cliente>
    {
        public ClienteCollection()
        {

        }

        public Cliente Crear(Cliente cliente)
        {
            this.Add(cliente);
            return cliente;
        }

        public Cliente Leer(int rut)
        {
            return this.Where(r => r.Rut == rut).FirstOrDefault();
        }

        public List<Cliente> LeerTodos()
        {
            return this.ToList();
        }

        public bool Actualizar(Cliente cliente)
        {
            Cliente encontrado = this.Where(r => r.Rut == cliente.Rut).FirstOrDefault();
            if (encontrado == null) return false;
            encontrado.RazonSocial = cliente.RazonSocial;
            encontrado.Direccion = cliente.Direccion;
            encontrado.Telefono = cliente.Telefono;
            encontrado.Actividad = cliente.Actividad;
            encontrado.Tipo = cliente.Tipo;
            return true;

        }

        public bool Eliminar(int rut)
        {
            var encontrado = Leer(rut);
            if (encontrado == null) return false;
            this.Remove(encontrado);
            return true;
        }

        public List<Cliente> Buscar(int rut, string razonSocial, string direccion,
            string telefono, EnumActividad actividad, EnumTipo tipo)
        {
            razonSocial = razonSocial.ToUpper();
            direccion = direccion.ToUpper();
            telefono = telefono.ToUpper();

            List<Cliente> lista = this.Where(r => (r.Rut == rut || rut == 0)
                    && (r.RazonSocial.ToUpper().Contains(razonSocial) || razonSocial == "")
                    && (r.Direccion.ToUpper().Contains(direccion) || direccion == "")
                    && (r.Telefono.ToUpper().Contains(telefono) || telefono == "")
                    && (r.Actividad == actividad || actividad == EnumActividad.NoSeleccionado)
                    && (r.Tipo == tipo || tipo == EnumTipo.NoSeleccionado)
                ).ToList();
            return lista;
        }
    }
}
