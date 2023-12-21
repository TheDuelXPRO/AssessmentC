using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class JogadorsController : Controller
    {
        private readonly WebApplication2Context _context;

        public JogadorsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Jogadors
        public async Task<IActionResult> Index()
        {
              return _context.Jogador != null ? 
                          View(await _context.Jogador.ToListAsync()) :
                          Problem("Entity set 'WebApplication2Context.Jogador'  is null.");
        }

        // GET: Jogadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Posicao,Time")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogador);
        }

        // GET: Jogadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            return View(jogador);
        }

        // POST: Jogadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Posicao,Time")] Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
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
            return View(jogador);
        }

        // GET: Jogadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogador == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogador == null)
            {
                return Problem("Entity set 'WebApplication2Context.Jogador'  is null.");
            }
            var jogador = await _context.Jogador.FindAsync(id);
            if (jogador != null)
            {
                _context.Jogador.Remove(jogador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id)
        {
          return (_context.Jogador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
