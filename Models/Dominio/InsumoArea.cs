using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREBCC2021.Models.Dominio
{
    public class InsumoArea
    {
        public int id { get; set; }
        public Area area { get; set; }
        public Insumo insumo { get; set; }
        public DateTime data { get; set; }
        public float quantidade { get; set; }
        public float valor { get; set; }
    }
}
