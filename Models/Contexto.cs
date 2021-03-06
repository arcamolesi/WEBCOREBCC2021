
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREBCC2021.Models.Dominio;
using WEBCOREBCC2021.Models.Mapeamento;
using WEBCOREBCC2021.Models.Consultas;

namespace WEBCOREBCC2021.Models
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Agricultor> Agricultores { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<InsumoArea> InsumosArea { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AgricultorMap());
            builder.ApplyConfiguration(new AreaMap());
            builder.ApplyConfiguration(new InsumoMap());
            builder.ApplyConfiguration(new InsumoAreaMap());
        }


        public DbSet<WEBCOREBCC2021.Models.Consultas.PivotInsumoArea> PivotInsumoArea { get; set; }


        //public DbSet<WEBCOREBCC2021.Models.Consultas.Itens> Itens { get; set; }


        //public DbSet<WEBCOREBCC2021.Models.Consultas.InsumosGrp> InsumosGrp { get; set; }
    }
}
