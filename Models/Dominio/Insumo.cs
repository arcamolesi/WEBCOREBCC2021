using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREBCC2021.Models.Dominio
{
    public class Insumo
    {
        public enum TipoInsumo {Adubo, Semente, Combustivel, Lubrificante, Herbicida, Inseticida, Outros}

        public int id { get; set; }
        public string descricao { get; set; }
        public float quantidade { get; set; }
        public float valor { get; set; }

    }
}
