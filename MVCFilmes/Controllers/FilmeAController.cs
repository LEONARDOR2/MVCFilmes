using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFilmes.Data;
using MVCFilmes.Models;

namespace MVCFilmes.Controllers
{
    public class FilmeAController : Controller
    {
        private readonly MVCFilmesContext _context;

        public FilmeAController(MVCFilmesContext context)
        {
            _context = context;
        }

        // GET: FilmeA
        public async Task<IActionResult> Index(string Texto, string Genero)
        {


          

            // query genero
            IQueryable<string> generos = from m in _context.Filmes
                                         orderby m.Genero
                                         select m.Genero;

            // query filme
            var filmes = from m in _context.Filmes
                         select m;

            // filtro genero
            if(!string.IsNullOrWhiteSpace(Genero))

            {


                filmes = filmes.Where(s => s.Genero == Genero);

            }

            // filtro filme
            if (!string.IsNullOrWhiteSpace(Texto))
            {

                filmes = filmes.Where(s => s.Titulo!.Contains(Texto));

            }




            //ViewModel
            var filmeViewModel = new Models.FilmesViewModel
            {

                Filmes = await filmes.ToListAsync(),
                Generos = new SelectList(await generos.Distinct().ToListAsync())

            };


            return View(filmeViewModel);
                          
        }

        // GET: FilmeA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filmes == null)
            {
                return NotFound();
            }

            return View(filmes);
        }

        // GET: FilmeA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmeA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,DataLancamento,Genero,Preco")] Filmes filmes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmes);
        }

        // GET: FilmeA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return NotFound();
            }
            return View(filmes);
        }

        // POST: FilmeA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,DataLancamento,Genero,Preco,Pontos")] Filmes filmes)
        {
            if (id != filmes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmesExists(filmes.ID))
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
            return View(filmes);
        }

        // GET: FilmeA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filmes == null)
            {
                return NotFound();
            }

            return View(filmes);
        }

        // POST: FilmeA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filmes == null)
            {
                return Problem("Entity set 'MVCFilmesContext.Filmes'  is null.");
            }
            var filmes = await _context.Filmes.FindAsync(id);
            if (filmes != null)
            {
                _context.Filmes.Remove(filmes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmesExists(int id)
        {
          return (_context.Filmes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
