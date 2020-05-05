using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Modelo
{
    public class TipoEvento
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public TipoEvento(string id, string nombre, int valorBase, int personalBase)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.ValorBase = valorBase;
            this.PersonalBase = personalBase;
        }
    }
}
