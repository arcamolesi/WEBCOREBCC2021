using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREBCC2021.Models.Dominio
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID")]
        public int id { get; set; }
        
        [Display(Name ="Produtor Rural")]
        public Agricultor produtor { get; set; }
        
        [Display(Name ="Hectares")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode =true)]
        public float hectares { get; set; }

        public string municipio { get; set; }
        public string bairro { get; set; }
        public int gps { get; set; }
    }
}
