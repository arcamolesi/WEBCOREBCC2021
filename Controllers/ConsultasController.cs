using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREBCC2021.Extra;
using WEBCOREBCC2021.Models;
using WEBCOREBCC2021.Models.Consultas;

namespace WEBCOREBCC2021.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Contexto contexto; 

        public ConsultasController(Contexto context)
        {
            contexto = context; 
        }


        public IActionResult PivotTabInsArea()
        {
            //gerar dados para a base do Pivot
            IEnumerable<InsumosGrp> lstInsByArea = from item in contexto.InsumosArea
                                                   .Include(a => a.area).Include(agr => agr.area.produtor)
                                                   .ToList()
                                                   group item by new { item.area.produtor.proprietario, item.area.bairro }
                                                   into grupo
                                                   orderby grupo.Key.proprietario, grupo.Key.bairro
                                                   select new InsumosGrp
                                                   {
                                                       agricultor = grupo.Key.proprietario,
                                                       area = grupo.Key.bairro,
                                                       total = grupo.Sum(it =>  it.valor)
                                                   };

            //Gerar Pivot
            var PivotTableInsArea = lstInsByArea.ToList().ToPivotTable(
                    pivo => pivo.area, //coluna
                    pivo => pivo.agricultor, //linha
                    pivos => (pivos.Any() ? pivos.Sum(x => Convert.ToSingle(x.total)): 0)); //valor das células

            //Converter DataTable do Pivot para Lista, permitir que o asp net core, imprima depois
            List<PivotInsumoArea> lista = new List<PivotInsumoArea>();
            lista = (from DataRow linha in PivotTableInsArea.Rows
                     select new PivotInsumoArea()
                     {
                         agricultor = linha[0].ToString(), 
                         Bairro1 = Convert.ToSingle(linha[1]),
                         Bairro2 = Convert.ToSingle(linha[2]),
                         Bairro3 = Convert.ToSingle(linha[3]),
                         Bairro4 = Convert.ToSingle(linha[4]),
                         Bairro5 = Convert.ToSingle(linha[5]),
                         Bairro6 = Convert.ToSingle(linha[6]),
                         Bairro7 = Convert.ToSingle(linha[7]),
                         Bairro8 = Convert.ToSingle(linha[8]),
                         Bairro9 = Convert.ToSingle(linha[9]),
                     }).ToList();

            return View(lista); 
        }

        public IActionResult agruparInsumoArea()
        {
            IEnumerable<InsumosGrp> lstInsByArea = from item in contexto.InsumosArea
                                                   .Include(a => a.area).Include(agr => agr.area.produtor)
                                                   .ToList()
                                                   group item by new { item.area.produtor.proprietario, item.area.bairro }
                                                   into grupo
                                                   orderby grupo.Key.proprietario, grupo.Key.bairro
                                                   select new InsumosGrp
                                                   {
                                                       agricultor = grupo.Key.proprietario,
                                                       area = grupo.Key.bairro,
                                                       total = grupo.Sum(it =>it.quantidade*it.valor)
                                                   };

            return View(lstInsByArea); 
        }

        [HttpGet("/Consultas/ListarItens/{idProdutor}")]
        public IActionResult ListarItensInsumoArea(int idProdutor)
        {
            IEnumerable<Itens> lstItens = from item in contexto.InsumosArea
                                          .Include(a => a.area).Include(agr=>agr.area.produtor).Include(i=>i.insumo)
                                          .ToList()
                                          .Where(i => i.area.produtorID == idProdutor)
                                          .OrderBy(agr => agr.area.produtor.proprietario)
                                          .ThenBy(a => a.area.bairro)
                                          .ThenBy(i => i.insumo.descricao)
                                          .ThenByDescending(q => q.quantidade)
                                          select new Itens
                                          {
                                              id = item.id, //insumo area
                                              agricultor = item.area.produtor.proprietario, //agricultor
                                              bairroArea = item.area.bairro, //area
                                              hectares = item.area.hectares, //area
                                              insumo = item.insumo.descricao, //insumo
                                              quantidade = item.quantidade, //insumoarea
                                              valor = item.valor, //insumoarea
                                              total = item.quantidade * item.insumo.valor //calculo usando dados de insumoarea
                                          };



            return View(lstItens); 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
