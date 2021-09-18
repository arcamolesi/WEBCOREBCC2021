using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREBCC2021.Models;
using WEBCOREBCC2021.Controllers;
using Microsoft.EntityFrameworkCore;
using WEBCOREBCC2021.Models.Dominio;

namespace WEBCOREBCC2021.Controllers
{
    public class ProdutoresController : Controller
    {    
        private readonly Contexto _context;
        private object _contex;

        public ProdutoresController(Contexto context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Agricultores.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create([Bind("id, proprietario, bairro, municipio, idade, email, cpf")] Agricultor agricultor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agricultor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agricultor); 

        }
        

        public async Task<IActionResult> Edit (int ? id)
        {

            if (id == null)
            {
                return NotFound(); 
            }

            var agricultor = await _context.Agricultores.FindAsync(id); 
                if (agricultor == null) {
                  return NotFound();
                }
                return View(agricultor); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,proprietario,bairro,municipio,idade,email,cpf")] Agricultor agricultor)
        {
            if (id != agricultor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agricultor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgricultorExists(agricultor.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agricultor);
        }

        private bool AgricultorExists(int id)
        {
            return _context.Agricultores.Any(e => e.id == id);
        }

    }
}
