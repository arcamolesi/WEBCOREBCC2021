using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREBCC2021.Models.Consultas
{
    public class Itens
    {
        public int id { get; set; }
        public string agricultor { get; set; }
        public string bairroArea { get; set; }
        public float hectares { get; set; }
        public string insumo { get; set; }
        public float quantidade { get; set; }
        public float valor { get; set; }
        public float total { get; set; }

    }
}
