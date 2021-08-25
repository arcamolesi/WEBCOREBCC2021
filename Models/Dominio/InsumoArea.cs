using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WEBCOREBCC2021.Models.Dominio
{
   
    public class InsumoArea
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "ID")]
        public Area area { get; set; }  // objeto aplicação
        //[ForeignKey("Area")]
        public int areaID { get; set; } // usado pelo banco para relacionamento 

        [Display(Name = "ID")]
        public Insumo insumo { get; set; } //objeto trabalhar em memória, na app
        public int insumoID { get; set; } //usado no banco como chave estrangeira

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime data { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

    }
}
